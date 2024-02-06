using Lojinha.Domain.Entities;
using Lojinha.Domain.Integrations;
using Lojinha.Domain.Interfaces.Repositories;
using Lojinha.Domain.Interfaces.Services;

namespace Lojinha.Domain.Services;

public class ProdutoImagemDomainService : IProdutoImagemDomainService
{
    private readonly IProdutoImagemRepository _produtoImagemRepository;
    private readonly IProdutoDomainService _produtoDomainService;
    private readonly ISaveImage _saveImage;

    public ProdutoImagemDomainService(IProdutoImagemRepository produtoImagemRepository, IProdutoDomainService produtoDomainService, ISaveImage saveImage)
    {
        _produtoImagemRepository = produtoImagemRepository;
        _produtoDomainService = produtoDomainService;
        _saveImage = saveImage;
    }

    public async Task CriarAsync(ProdutoImagem produtoImagem)
    {
        await _produtoDomainService.BuscarPorIdAsync(produtoImagem.ProdutoId);
        await _produtoImagemRepository.CreateAsync(produtoImagem);
    }

    public async Task CriarESalvarImagemAsync(ProdutoImagem produtoImagem)
    {
        await _produtoDomainService.BuscarPorIdAsync(produtoImagem.ProdutoId);

        produtoImagem.Url = await _saveImage.SaveAndCreateUrlAsync(produtoImagem.Base64, produtoImagem.Id.ToString());

        await _produtoImagemRepository.CreateAsync(produtoImagem);
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
