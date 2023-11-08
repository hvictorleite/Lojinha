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

    public void CriarProduto(Produto produto)
    {
        _produtoRepository.Create(produto);
    }

    public void EditarProduto(Produto produto)
    {
        _produtoRepository.Update(produto);
    }

    public void RemoverProduto(Produto produto)
    {
        _produtoRepository.Delete(produto);
    }

    public IList<Produto> BuscarTodos(Produto produto)
    {
        return _produtoRepository.GetAll();
    }

    public Produto BuscarPorId(Guid id)
    {
        return _produtoRepository.GetById(id);
    }

    public void Dispose()
    {
        // _produtoRepository.Dispose();
    }
}