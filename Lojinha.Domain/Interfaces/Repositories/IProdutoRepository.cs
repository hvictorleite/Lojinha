using Lojinha.Domain.Entities;

namespace Lojinha.Domain.Interfaces.Repositories;

public interface IProdutoRepository : IDisposable
{
    Task Create(Produto produto);
    Task Update(Produto produto);
    Task Delete(Produto produto);

    Task<IList<Produto>> GetAll();
    Task<Produto> GetById(Guid id);
    Task<Produto> GetByNome(string nome);
}