using Lojinha.Application.Interfaces;
using Lojinha.Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Lojinha.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProdutosController : ControllerBase, IDisposable
{
    private readonly IProdutoApplicationService _produtoApplicationService;

    public ProdutosController(IProdutoApplicationService produtoApplicationService)
    {
        _produtoApplicationService = produtoApplicationService;
    }

    [HttpPost]
    public async Task<IActionResult> CriarProdutoAsync([FromBody] CriarProdutoRequest request)
    {
        try
        {
            await _produtoApplicationService.CriarProdutoAsync(request);
            return StatusCode(StatusCodes.Status201Created, new { message = $"Produto '{request.Nome}' criado com sucesso." });
        }
        catch (FluentValidation.ValidationException ex)
        {
            return StatusCode(StatusCodes.Status400BadRequest, new { errors = ex.Errors });
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { exception = ex.GetType().Name, error = ex.Message });
        }
    }

    [HttpPut]
    public async Task<IActionResult> EditarProdutoAsync([FromBody] EditarProdutoRequest request)
    {
        try
        {
            await _produtoApplicationService.EditarProdutoAsync(request);
            return StatusCode(StatusCodes.Status200OK, new { message = $"Produto '{request.Nome}' atualizado com sucesso." });
        }
        catch (FluentValidation.ValidationException ex)
        {
            return StatusCode(StatusCodes.Status400BadRequest, new { errors = ex.Errors });
        }
        catch (NullReferenceException ex)
        {
            return StatusCode(StatusCodes.Status404NotFound, new { errorMessage = "ERROR: " + ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { exception = ex.GetType().Name, errors = ex.Message });
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoverProdutoAsync([FromRoute] Guid id)
    {
        try
        {
            await _produtoApplicationService.RemoverProdutoAsync(id);
            return StatusCode(StatusCodes.Status200OK, new { message = "Produto removido com sucesso." });
        }
        catch (NullReferenceException ex)
        {
            return StatusCode(StatusCodes.Status404NotFound, new { errorMessage = "ERROR: " + ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { exception = ex.GetType().Name, errors = ex.Message });
        }
    }

    [HttpGet]
    public async Task<IActionResult> BuscarTodosAsync()
    {
        try
        {
            var produtos = await _produtoApplicationService.BuscarTodosAsync();
            return StatusCode(StatusCodes.Status200OK, produtos);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { exception = ex.GetType().Name, errors = ex.Message });
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> BuscarPorIdAsync([FromRoute] Guid id)
    {
        try
        {
            var produto = await _produtoApplicationService.BuscarPorIdAsync(id);
            return StatusCode(StatusCodes.Status200OK, produto);
        }
        catch (NullReferenceException ex)
        {
            return StatusCode(StatusCodes.Status404NotFound, new { errorMessage = "ERROR: " + ex.Message });
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { exception = ex.GetType().Name, errors = ex.Message });
        }
    }

    public void Dispose()
    {
        _produtoApplicationService.Dispose();
    }
}