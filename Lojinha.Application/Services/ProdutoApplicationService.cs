using AutoMapper;
using FluentValidation;
using Lojinha.Application.Commands;
using Lojinha.Application.Interfaces;
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

    public void CriarProduto(CriarProdutoCommand command)
    {
        var produto = _mapper.Map<CriarProdutoCommand, Produto>(command);

        var validate = produto.Validate;
        if (!validate.IsValid)
            throw new ValidationException(validate.Errors);

        _produtoDomainService.CriarProduto(produto);
    }

    public void Dispose()
    {
        _produtoDomainService.Dispose();
    }
}
