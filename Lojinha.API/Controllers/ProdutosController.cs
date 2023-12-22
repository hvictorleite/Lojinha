using Lojinha.Application.Commands;
using Lojinha.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Lojinha.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProdutosController : ControllerBase
{
    private readonly IProdutoApplicationService _produtoApplicationService;

    public ProdutosController(IProdutoApplicationService produtoApplicationService)
    {
        _produtoApplicationService = produtoApplicationService;
    }

    [HttpPost]
    public async Task<IActionResult> CriarProduto([FromBody] CriarProdutoRequest request)
    {
        try
        {
            await _produtoApplicationService.CriarProduto(request);
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
    public async Task<IActionResult> EditarProduto([FromBody] EditarProdutoRequest request)
    {
        try
        {
            await _produtoApplicationService.EditarProduto(request);
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
    public async Task<IActionResult> RemoverProduto([FromRoute] Guid id)
    {
        try
        {
            await _produtoApplicationService.RemoverProduto(id);
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
    public async Task<IActionResult> BuscarTodos()
    {
        try
        {
            var produtos = await _produtoApplicationService.BuscarTodos();
            return StatusCode(StatusCodes.Status200OK, produtos);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new { exception = ex.GetType().Name, errors = ex.Message });
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> BuscarPorId([FromRoute] Guid id)
    {
        try
        {
            var produto = await _produtoApplicationService.BuscarPorId(id);
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
}