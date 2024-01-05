using Lojinha.Domain.Entities;
using Lojinha.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Lojinha.Infrastructure.Data.Repositories;

public class ProdutoRepository : IProdutoRepository
{
    private readonly SqlServerContext _context;

    public ProdutoRepository(SqlServerContext context)
    {
        _context = context;
    }

    public async Task CreateAsync(Produto produto)
    {
        _context.Entry(produto).State = EntityState.Added;
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Produto produto)
    {
        _context.Entry(produto).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Produto produto)
    {
        _context.Entry(produto).State = EntityState.Deleted;
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Produto>> GetAllAsync()
    {
        return await _context.Set<Produto>().ToListAsync();
    }

    public async Task<Produto> GetByIdAsync(Guid id)
    {
        return await _context.Set<Produto>().FindAsync(id);
    }

    public async Task<Produto> GetByNomeAsync(string nome)
    {
        return await _context.Set<Produto>().FirstOrDefaultAsync(x => x.Nome == nome);
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
