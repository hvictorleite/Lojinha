using Lojinha.Domain.Entities;

namespace Lojinha.Domain.Interfaces.Services;

public interface IProdutoDomainService : IDisposable
{
    void CriarProduto(Produto produto);
    void EditarProduto(Produto produto);
    void RemoverProduto(Produto produto);
    
    IList<Produto> BuscarTodos();
    Produto BuscarPorId(Guid id);
    Produto BuscarPorNome(string nome);
}