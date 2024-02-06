using Lojinha.Domain.Entities;
using Lojinha.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Lojinha.Infrastructure.Data.Repositories;

public class ProdutoImagemRepository : IProdutoImagemRepository
{
    private readonly SqlServerContext _context;

    public ProdutoImagemRepository(SqlServerContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(ProdutoImagem produtoImagem)
    {
        _context.Entry(produtoImagem).State = EntityState.Added;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(ProdutoImagem produtoImagem)
    {
        _context.Entry(produtoImagem).State = EntityState.Deleted;
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<ProdutoImagem>> GetAllAsync()
    {
        return await _context.Set<ProdutoImagem>().AsNoTracking().ToListAsync();
    }

    public async Task<ProdutoImagem> GetByIdAsync(Guid id)
    {
        return await _context.Set<ProdutoImagem>().FindAsync(id);
    }

    public async Task<IEnumerable<ProdutoImagem>> GetByProdutoIdAsync(Guid produtoId)
    {
        return await _context.Set<ProdutoImagem>()
            .AsNoTracking()
            .Where(pi => pi.ProdutoId == produtoId)
            .ToListAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
