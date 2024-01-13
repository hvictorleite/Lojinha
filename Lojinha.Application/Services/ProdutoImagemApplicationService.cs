using AutoMapper;
using Lojinha.Application.Interfaces;
using Lojinha.Application.Requests;
using Lojinha.Application.Responses;
using Lojinha.Domain.Entities;
using Lojinha.Domain.Interfaces.Services;

namespace Lojinha.Application.Services;

public class ProdutoImagemApplicationService : IProdutoImagemApplicationService
{
    private readonly IProdutoImagemDomainService _produtoImagemDomainService;
    private readonly IMapper _mapper;

    public ProdutoImagemApplicationService(IProdutoImagemDomainService produtoImagemDomainService, IMapper mapper)
    {
        _produtoImagemDomainService = produtoImagemDomainService;
        _mapper = mapper;
    }

    public async Task CriarAsync(CriarProdutoImagemRequest request)
    {
        await _produtoImagemDomainService.CriarAsync(_mapper.Map<ProdutoImagem>(request));
    }

    public async Task EditarAsync(EditarProdutoImagemRequest request)
    {
        await _produtoImagemDomainService.EditarAsync(_mapper.Map<ProdutoImagem>(request));
    }

    public async Task RemoverAsync(Guid id)
    {
        await _produtoImagemDomainService.RemoverAsync(id);
    }

    public async Task<IEnumerable<ProdutoImagemResponse>> BuscarTodosAsync()
    {
        return _mapper.Map<IEnumerable<ProdutoImagemResponse>>(await _produtoImagemDomainService.BuscarTodosAsync());
    }

    public async Task<ProdutoImagemResponse> BuscarPorIdAsync(Guid id)
    {
        return _mapper.Map<ProdutoImagemResponse>(await _produtoImagemDomainService.BuscarPorIdAsync(id));
    }

    public async Task<IEnumerable<ProdutoImagemResponse>> BuscarPorProdutoIdAsync(Guid produtoId)
    {
        return _mapper.Map<IEnumerable<ProdutoImagemResponse>>(await _produtoImagemDomainService.BuscarPorProdutoIdAsync(produtoId));
    }

    public void Dispose()
    {
        _produtoImagemDomainService.Dispose();
    }
}
