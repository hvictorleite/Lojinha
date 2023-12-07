using Lojinha.Application.Commands;
using Lojinha.Application.Queries;

namespace Lojinha.Application.Interfaces;

public interface IProdutoApplicationService : IDisposable
{
    Task CriarProduto(CriarProdutoRequest request);
    Task EditarProduto(EditarProdutoRequest request);

    Task<IList<ProdutoResponse>> BuscarTodos();
    Task<ProdutoResponse> BuscarPorId(Guid id);
}
