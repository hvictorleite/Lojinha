using Lojinha.Domain.Entities;
using Lojinha.Domain.Interfaces.Repositories;
using Lojinha.Domain.Interfaces.Services;

namespace Lojinha.Domain.Services;

public class ProdutoDomainService : IProdutoDomainService
{
    private readonly IProdutoRepository _produtoRepository;

    public ProdutoDomainService(IProdutoRepository produtoRepository)
    {
        _produtoRepository = produtoRepository;
    }

    public async Task CriarAsync(Produto produto)
    {
        await _produtoRepository.CreateAsync(produto);
    }

    public async Task EditarAsync(Produto produto)
    {
        var produtoSalvo = await BuscarPorIdAsync(produto.Id);

        produtoSalvo.Nome = produto.Nome;
        produtoSalvo.Preco = produto.Preco;

        if (produtoSalvo.Estoque != produto.Estoque)
        {
            produtoSalvo.RetirarDoEstoque(produtoSalvo.Estoque);
            produtoSalvo.AdicionarAoEstoque(produto.Estoque);
        }

        await _produtoRepository.UpdateAsync(produtoSalvo);
    }

    public async Task RemoverAsync(Guid id)
    {
        var produto = await BuscarPorIdAsync(id);
        await _produtoRepository.DeleteAsync(produto);
    }

    public async Task<IEnumerable<Produto>> BuscarTodosAsync()
    {
        return await _produtoRepository.GetAllAsync();
    }

    public async Task<Produto> BuscarPorIdAsync(Guid id)
    {
        return await _produtoRepository.GetByIdAsync(id)
            ?? throw new NullReferenceException("Produto não encontrado.");
    }

    public async Task<Produto> BuscarPorNomeAsync(string nome)
    {
        return await _produtoRepository.GetByNomeAsync(nome);
    }

    public void Dispose()
    {
        _produtoRepository.Dispose();
    }
}