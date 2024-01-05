using Lojinha.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Lojinha.Infrastructure.Data.Mappings;

public class ProdutoImagemMap : IEntityTypeConfiguration<ProdutoImagem>
{
    public void Configure(EntityTypeBuilder<ProdutoImagem> builder)
    {
        builder.Property(pi => pi.Base64)
            .HasColumnType("text");

        builder.Property(pi => pi.Url)
            .HasMaxLength(150);

        builder.HasOne(pi => pi.Produto)
            .WithMany(p => p.Imagens)
            .HasForeignKey(pi => pi.ProdutoId);
    }
}
