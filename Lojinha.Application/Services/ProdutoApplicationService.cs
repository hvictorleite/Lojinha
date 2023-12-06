using AutoMapper;
using FluentValidation;
using Lojinha.Application.Commands;
using Lojinha.Application.Interfaces;
using Lojinha.Application.Queries;
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

    public void CriarProduto(CriarProdutoRequest request)
    {
        var produto = _mapper.Map<CriarProdutoRequest, Produto>(request);

        var validate = produto.Validate;
        if (!validate.IsValid)
            throw new ValidationException(validate.Errors);

        _produtoDomainService.CriarProduto(produto);
    }

    public IList<ProdutoResponse> BuscarTodos()
    {
        return _mapper.Map<IList<Produto>, IList<ProdutoResponse>>(_produtoDomainService.BuscarTodos());
    }

    public void Dispose()
    {
        _produtoDomainService.Dispose();
    }
}
