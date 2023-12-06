using Lojinha.Application.Commands;

namespace Lojinha.Application.Interfaces;

public interface IProdutoApplicationService : IDisposable
{
    void CriarProduto(CriarProdutoCommand command);
}
