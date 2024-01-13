using AutoMapper;
using FluentValidation;
using Lojinha.Application.Interfaces;
using Lojinha.Application.Queries;
using Lojinha.Application.Requests;
using Lojinha.Domain.Core;
using Lojinha.Domain.Entities;
using Lojinha.Domain.Interfaces.Services;

namespace Lojinha.Application.Services;

public class ProdutoApplicationService : IProdutoApplicationService
{
    private readonly IProdutoDomainService _produtoDomainService;
    private IMapper _mapper;

    public ProdutoApplicationService(IProdutoDomainService produtoDomainService, IMapper mapper)
    {
        _produtoDomainService = produtoDomainService;
        _mapper = mapper;
    }

    public async Task CriarProdutoAsync(CriarProdutoRequest request)
    {
        var produto = _mapper.Map<CriarProdutoRequest, Produto>(request);

        var validate = produto.Validate;
        if (!validate.IsValid)
            throw new ValidationException(validate.Errors);

        await _produtoDomainService.CriarProdutoAsync(produto);
    }

    public async Task EditarProdutoAsync(EditarProdutoRequest request)
    {
        var produto = _mapper.Map<EditarProdutoRequest, Produto>(request);

        var validate = produto.Validate;
        if (!validate.IsValid)
            throw new ValidationException(validate.Errors);

        await _produtoDomainService.EditarProdutoAsync(produto);
    }

    public async Task RemoverProdutoAsync(Guid id)
    {
        await _produtoDomainService.RemoverProdutoAsync(id);
    }

    public async Task<IEnumerable<ProdutoResponse>> BuscarTodosAsync()
    {
        return _mapper.Map<IEnumerable<Produto>, IEnumerable<ProdutoResponse>>(await _produtoDomainService.BuscarTodosAsync());
    }

    public async Task<ProdutoResponse> BuscarPorIdAsync(Guid id)
    {
        return _mapper.Map<Produto, ProdutoResponse>(await _produtoDomainService.BuscarPorIdAsync(id));
    }

    public void Dispose()
    {
        _produtoDomainService.Dispose();
    }
}
