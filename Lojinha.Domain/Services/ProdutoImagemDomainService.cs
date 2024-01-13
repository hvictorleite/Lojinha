using Lojinha.Domain.Entities;
using Lojinha.Domain.Interfaces.Repositories;
using Lojinha.Domain.Interfaces.Services;

namespace Lojinha.Domain.Services;

public class ProdutoImagemDomainService : IProdutoImagemDomainService
{
    private readonly IProdutoImagemRepository _produtoImagemRepository;
    private readonly IProdutoDomainService _produtoDomainService;

    public ProdutoImagemDomainService(IProdutoImagemRepository produtoImagemRepository, IProdutoDomainService produtoDomainService)
    {
        _produtoImagemRepository = produtoImagemRepository;
        _produtoDomainService = produtoDomainService;
    }

    public async Task CriarAsync(ProdutoImagem produtoImagem)
    {
        await _produtoDomainService.BuscarPorIdAsync(produtoImagem.ProdutoId);
        await _produtoImagemRepository.CreateAsync(produtoImagem);
    }

    public async Task EditarAsync(ProdutoImagem produtoImagem)
    {
        var produtoImagemSalvo = await BuscarPorIdAsync(produtoImagem.Id);

        produtoImagemSalvo.Url = produtoImagem.Url;
        produtoImagemSalvo.Base64 = produtoImagem.Base64;

        await _produtoImagemRepository.UpdateAsync(produtoImagemSalvo);
    }

    public async Task RemoverAsync(Guid id)
    {
        var produtoImagemSalvo = await BuscarPorIdAsync(id);
        await _produtoImagemRepository.DeleteAsync(produtoImagemSalvo);
    }

    public async Task<IEnumerable<ProdutoImagem>> BuscarTodosAsync()
    {
        return await _produtoImagemRepository.GetAllAsync();
    }

    public async Task<ProdutoImagem> BuscarPorIdAsync(Guid id)
    {
        return await _produtoImagemRepository.GetByIdAsync(id)
            ?? throw new NullReferenceException("ProdutoImagem não encontrado.");
    }

    public async Task<IEnumerable<ProdutoImagem>> BuscarPorProdutoIdAsync(Guid produtoId)
    {
        return await _produtoImagemRepository.GetByProdutoIdAsync(produtoId)
            ?? throw new NullReferenceException("Não encontradas imagens vinculadas ao Produto.");
    }

    public void Dispose()
    {
        _produtoImagemRepository.Dispose();
    }
}
