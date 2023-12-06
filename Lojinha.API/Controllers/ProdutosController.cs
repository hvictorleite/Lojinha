using Lojinha.Application.Commands;
using Lojinha.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

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
    public IActionResult CriarProduto([FromBody] CriarProdutoRequest request)
    {
        _produtoApplicationService.CriarProduto(request);
        return StatusCode(StatusCodes.Status201Created, new { message = $"Produto '{request.Nome}' criado com sucesso." });
    }

    [HttpGet]
    public IActionResult BuscarTodos()
    {
        var produtos = _produtoApplicationService.BuscarTodos();
        return StatusCode(StatusCodes.Status200OK, produtos);
    }
}