using Lojinha.Application.Requests;
using Lojinha.Application.Responses;

namespace Lojinha.Application.Interfaces;

public interface IProdutoImagemApplicationService : IDisposable
{
    Task CriarAsync(CriarProdutoImagemRequest request);
    Task CriarESalvarImagemAsync(CriarProdutoImagemRequest request);
    Task RemoverAsync(Guid id);

    Task<IEnumerable<ProdutoImagemResponse>> BuscarTodosAsync();
    Task<ProdutoImagemResponse> BuscarPorIdAsync(Guid id);
    Task<IEnumerable<ProdutoImagemResponse>> BuscarPorProdutoIdAsync(Guid produtoId);
}
