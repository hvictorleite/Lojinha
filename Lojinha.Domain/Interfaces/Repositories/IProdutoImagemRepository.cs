using Lojinha.Domain.Entities;

namespace Lojinha.Domain.Interfaces.Repositories;

public interface IProdutoImagemRepository : IDisposable
{
    Task CreateAsync(ProdutoImagem produtoImagem);
    Task DeleteAsync(ProdutoImagem produtoImagem);

    Task<IEnumerable<ProdutoImagem>> GetAllAsync();
    Task<ProdutoImagem> GetByIdAsync(Guid id);
    Task<IEnumerable<ProdutoImagem>> GetByProdutoIdAsync(Guid produtoId);
}
