using Lojinha.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lojinha.Infrastructure.Data.Mappings;

public class ProdutoMap : IEntityTypeConfiguration<Produto>
{
    public void Configure(EntityTypeBuilder<Produto> builder)
    {
        builder.HasIndex(x => x.Nome);

        builder.Property(x => x.Nome)
            .HasMaxLength(150);

        builder.Property(x => x.Preco)
            .HasColumnType("decimal(18,2)");
    }
}
