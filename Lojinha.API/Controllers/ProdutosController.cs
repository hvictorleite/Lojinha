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
    public async Task<IActionResult> CriarProduto([FromBody] CriarProdutoRequest request)
    {
        await _produtoApplicationService.CriarProduto(request);
        return StatusCode(StatusCodes.Status201Created, new { message = $"Produto '{request.Nome}' criado com sucesso." });
    }

    [HttpPut]
    public async Task<IActionResult> EditarProduto([FromBody] EditarProdutoRequest request)
    {
        await _produtoApplicationService.EditarProduto(request);
        return StatusCode(StatusCodes.Status200OK, new { message = $"Produto '{request.Nome}' atualizado com sucesso." });
    }

    [HttpGet]
    public async Task<IActionResult> BuscarTodos()
    {
        var produtos = await _produtoApplicationService.BuscarTodos();
        return StatusCode(StatusCodes.Status200OK, produtos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> BuscarPorId([FromRoute] Guid id)
    {
        var produto = await _produtoApplicationService.BuscarPorId(id);
        return StatusCode(StatusCodes.Status200OK, produto);
    }
}