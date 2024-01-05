using Lojinha.Domain.Core;
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

    public async Task CriarProdutoAsync(Produto produto)
    {
        await _produtoRepository.CreateAsync(produto);
    }

    public async Task EditarProdutoAsync(Produto produto)
    {
        var produtoSalvo = await _produtoRepository.GetByIdAsync(produto.Id);

        if (produtoSalvo == null)
            throw new NullReferenceException("Produto não encontrado.");

        produtoSalvo.Nome = produto.Nome;
        produtoSalvo.Preco = produto.Preco;

        if (produtoSalvo.Estoque != produto.Estoque)
        {
            produtoSalvo.RetirarDoEstoque(produtoSalvo.Estoque);
            produtoSalvo.AdicionarAoEstoque(produto.Estoque);
        }

        await _produtoRepository.UpdateAsync(produtoSalvo);
    }

    public async Task RemoverProdutoAsync(Guid id)
    {
        var produto = await _produtoRepository.GetByIdAsync(id);

        if (produto == null)
            throw new NullReferenceException("Produto não encontrado.");

        await _produtoRepository.DeleteAsync(produto);
    }

    public async Task<IEnumerable<Produto>> BuscarTodosAsync()
    {
        return await _produtoRepository.GetAllAsync();
    }

    public async Task<Produto> BuscarPorIdAsync(Guid id)
    {
        var produto = await _produtoRepository.GetByIdAsync(id);

        if (produto == null)
            throw new NullReferenceException("Produto não encontrado.");

        return produto;
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