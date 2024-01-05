using Lojinha.Domain.Entities;

namespace Lojinha.Domain.Interfaces.Repositories;

public interface IProdutoRepository : IDisposable
{
    Task CreateAsync(Produto produto);
    Task UpdateAsync(Produto produto);
    Task DeleteAsync(Produto produto);

    Task<IEnumerable<Produto>> GetAllAsync();
    Task<Produto> GetByIdAsync(Guid id);
    Task<Produto> GetByNomeAsync(string nome);
}