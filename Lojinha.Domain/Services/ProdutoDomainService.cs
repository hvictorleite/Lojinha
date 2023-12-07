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

    public async Task CriarProduto(Produto produto)
    {
        await _produtoRepository.Create(produto);
    }

    public async Task EditarProduto(Produto produto)
    {
        var produtoSalvo = await _produtoRepository.GetById(produto.Id);

        if (produtoSalvo == null)
            throw new NullReferenceException("Produto não encontrado. Id inválido.");

        produtoSalvo.Nome = produto.Nome;
        produtoSalvo.Preco = produto.Preco;

        if (produtoSalvo.Estoque != produto.Estoque)
        {
            produtoSalvo.RetirarDoEstoque(produtoSalvo.Estoque);
            produtoSalvo.AdicionarAoEstoque(produto.Estoque);
        }

        await _produtoRepository.Update(produtoSalvo);
    }

    public async Task RemoverProduto(Produto produto)
    {
        await _produtoRepository.Delete(produto);
    }

    public async Task<IList<Produto>> BuscarTodos()
    {
        return await _produtoRepository.GetAll();
    }

    public async Task<Produto> BuscarPorId(Guid id)
    {
        return await _produtoRepository.GetById(id);
    }

    public async Task<Produto> BuscarPorNome(string nome)
    {
        return await _produtoRepository.GetByNome(nome);
    }

    public void Dispose()
    {
        _produtoRepository.Dispose();
    }
}