using Lojinha.Application.Queries;
using Lojinha.Application.Requests;

namespace Lojinha.Application.Interfaces;

public interface IProdutoApplicationService : IDisposable
{
    Task CriarAsync(CriarProdutoRequest request);
    Task EditarAsync(EditarProdutoRequest request);
    Task RemoverAsync(Guid id);

    Task<IEnumerable<ProdutoResponse>> BuscarTodosAsync();
    Task<ProdutoResponse> BuscarPorIdAsync(Guid id);
}
