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

    public IList<Produto> BuscarTodos()
    {
        return _produtoRepository.GetAll().Result;
    }

    public Produto BuscarPorId(Guid id)
    {
        return _produtoRepository.GetById(id).Result;
    }

    public Produto BuscarPorNome(string nome)
    {
        return _produtoRepository.GetByNome(nome).Result;
    }

    public void Dispose()
    {
        _produtoRepository.Dispose();
    }
}