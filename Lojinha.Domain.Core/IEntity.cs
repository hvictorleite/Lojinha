using FluentValidation.Results;

namespace Lojinha.Domain.Core;

public interface IEntity<TKey>
{
    public TKey Id { get; set; }

    ValidationResult Validate { get; }
}