using Lojinha.Application.Interfaces;
using Lojinha.Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Lojinha.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProdutoImagemController : ControllerBase, IDisposable
{
    private readonly IProdutoImagemApplicationService _produtoImagemApplicationService;

    public ProdutoImagemController(IProdutoImagemApplicationService produtoImagemApplicationService)
    {
        _produtoImagemApplicationService = produtoImagemApplicationService;
    }

    [HttpPost]
    public async Task<IActionResult> CriarProdutoImagemAsync([FromBody] CriarProdutoImagemRequest request)
    {
        try
        {
            await _produtoImagemApplicationService.CriarAsync(request);
            return StatusCode(StatusCodes.Status201Created, new { message = $"ProdutoImagem criado com sucesso." });
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
            return StatusCode(StatusCodes.Status500InternalServerError, new { exception = ex.GetType().Name, error = ex.Message });
        }
    }

    [HttpPost]
    public async Task<IActionResult> CriarProdutoImagemESalvarImagemAsync([FromBody] CriarProdutoImagemRequest request)
    {
        try
        {
            await _produtoImagemApplicationService.CriarESalvarImagemAsync(request);
            return StatusCode(StatusCodes.Status200OK, new { message = $"ProdutoImagem criado e salvo com sucesso." });
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
    public async Task<IActionResult> RemoverProdutoImagemAsync([FromRoute] Guid id)
    {
        try
        {
            await _produtoImagemApplicationService.RemoverAsync(id);
            return StatusCode(StatusCodes.Status200OK, new { message = $"ProdutoImagem removido com sucesso." });
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
            var produtoImagens = await _produtoImagemApplicationService.BuscarTodosAsync();
            return StatusCode(StatusCodes.Status200OK, produtoImagens);

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
            var produtoImagem = await _produtoImagemApplicationService.BuscarPorIdAsync(id);
            return StatusCode(StatusCodes.Status200OK, produtoImagem);
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

    [HttpGet("{produtoId}")]
    public async Task<IActionResult> BuscarPorProdutoIdAsync([FromRoute] Guid produtoId)
    {
        try
        {
            var produtoImagens = await _produtoImagemApplicationService.BuscarPorProdutoIdAsync(produtoId);
            return StatusCode(StatusCodes.Status200OK, produtoImagens);
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
        _produtoImagemApplicationService.Dispose();
    }
}
