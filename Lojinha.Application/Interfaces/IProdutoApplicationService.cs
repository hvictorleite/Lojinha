﻿using Lojinha.Application.Queries;
using Lojinha.Application.Requests;

namespace Lojinha.Application.Interfaces;

public interface IProdutoApplicationService : IDisposable
{
    Task CriarProdutoAsync(CriarProdutoRequest request);
    Task EditarProdutoAsync(EditarProdutoRequest request);
    Task RemoverProdutoAsync(Guid id);

    Task<IEnumerable<ProdutoResponse>> BuscarTodosAsync();
    Task<ProdutoResponse> BuscarPorIdAsync(Guid id);
}
