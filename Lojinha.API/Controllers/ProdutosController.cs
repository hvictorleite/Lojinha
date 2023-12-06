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
    public IActionResult CriarProduto([FromBody] CriarProdutoCommand command)
    {
        _produtoApplicationService.CriarProduto(command);
        return StatusCode(StatusCodes.Status201Created, new { message = $"Produto {command.Nome} criado com sucesso." });
    }
}
