using AutoMapper;
using FluentValidation;
using Lojinha.Application.Commands;
using Lojinha.Application.Interfaces;
using Lojinha.Application.Queries;
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

    public async Task CriarProduto(CriarProdutoRequest request)
    {
        var produto = _mapper.Map<CriarProdutoRequest, Produto>(request);

        var validate = produto.Validate;
        if (!validate.IsValid)
            throw new ValidationException(validate.Errors);

        await _produtoDomainService.CriarProduto(produto);
    }

    public async Task EditarProduto(EditarProdutoRequest request)
    {
        var produto = _mapper.Map<EditarProdutoRequest, Produto>(request);

        var validate = produto.Validate;
        if (!validate.IsValid)
            throw new ValidationException(validate.Errors);

        await _produtoDomainService.EditarProduto(produto);
    }

    public async Task RemoverProduto(Guid id)
    {
        await _produtoDomainService.RemoverProduto(id);
    }

    public async Task<IList<ProdutoResponse>> BuscarTodos()
    {
        return _mapper.Map<IList<Produto>, IList<ProdutoResponse>>(await _produtoDomainService.BuscarTodos());
    }

    public async Task<ProdutoResponse> BuscarPorId(Guid id)
    {
        return _mapper.Map<Produto, ProdutoResponse>(await _produtoDomainService.BuscarPorId(id));
    }

    public void Dispose()
    {
        _produtoDomainService.Dispose();
    }
}
