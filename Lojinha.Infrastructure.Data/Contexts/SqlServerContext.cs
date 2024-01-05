using Lojinha.Domain.Entities;
using Lojinha.Infrastructure.Data.Mappings;
using Microsoft.EntityFrameworkCore;

public class SqlServerContext : DbContext
{
    public SqlServerContext(DbContextOptions<SqlServerContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ProdutoMap());
        modelBuilder.ApplyConfiguration(new ProdutoImagemMap());
    }

    public DbSet<Produto> Produtos { get; set; }
    public DbSet<ProdutoImagem> ProdutoImagens { get; set; }
}