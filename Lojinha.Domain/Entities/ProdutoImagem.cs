using FluentValidation.Results;
using Lojinha.Domain.Core;
using Lojinha.Domain.Validations;

namespace Lojinha.Domain.Entities;

public class ProdutoImagem : IEntity<Guid>
{
    public Guid Id { get; set; }
    public Guid ProdutoId { get; set; }
    public string? Url { get; set; }
    public string? Base64 { get; set; }

    public Produto? Produto { get; set; }

    public ValidationResult Validate
        => new ProdutoImagemValidation().Validate(this);
}
