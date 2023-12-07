using Lojinha.Domain.Entities;

namespace Lojinha.Domain.Interfaces.Services;

public interface IProdutoDomainService : IDisposable
{
    Task CriarProduto(Produto produto);
    Task EditarProduto(Produto produto);
    Task RemoverProduto(Produto produto);

    Task<IList<Produto>> BuscarTodos();
    Task<Produto> BuscarPorId(Guid id);
    Task<Produto> BuscarPorNome(string nome);
}