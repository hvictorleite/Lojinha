using Lojinha.Domain.Entities;

namespace Lojinha.Domain.Interfaces.Services;

public interface IProdutoDomainService : IDisposable
{
    Task CriarProdutoAsync(Produto produto);
    Task EditarProdutoAsync(Produto produto);
    Task RemoverProdutoAsync(Guid id);

    Task<IEnumerable<Produto>> BuscarTodosAsync();
    Task<Produto> BuscarPorIdAsync(Guid id);
    Task<Produto> BuscarPorNomeAsync(string nome);
}