using Lojinha.Application.Commands;
using Lojinha.Application.Queries;

namespace Lojinha.Application.Interfaces;

public interface IProdutoApplicationService : IDisposable
{
    void CriarProduto(CriarProdutoRequest request);
    IList<ProdutoResponse> BuscarTodos();
}
