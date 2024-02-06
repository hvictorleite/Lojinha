using Lojinha.Domain.Entities;

namespace Lojinha.Domain.Interfaces.Services;

public interface IProdutoDomainService : IDisposable
{
    Task CriarAsync(Produto produto);
    Task EditarAsync(Produto produto);
    Task RemoverAsync(Guid id);

    Task<IEnumerable<Produto>> BuscarTodosAsync();
    Task<Produto> BuscarPorIdAsync(Guid id);
    Task<Produto> BuscarPorNomeAsync(string nome);
}