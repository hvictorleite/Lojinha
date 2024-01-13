using Lojinha.Domain.Entities;

namespace Lojinha.Domain.Interfaces.Services;

public interface IProdutoImagemDomainService : IDisposable
{
    Task CriarAsync(ProdutoImagem produtoImagem);
    Task EditarAsync(ProdutoImagem produtoImagem);
    Task RemoverAsync(Guid id);

    Task<IEnumerable<ProdutoImagem>> BuscarTodosAsync();
    Task<ProdutoImagem> BuscarPorIdAsync(Guid id);
    Task<IEnumerable<ProdutoImagem>> BuscarPorProdutoIdAsync(Guid produtoId);
}
