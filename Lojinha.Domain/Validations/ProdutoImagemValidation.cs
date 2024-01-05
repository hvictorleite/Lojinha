using FluentValidation;
using Lojinha.Domain.Entities;

namespace Lojinha.Domain.Validations;
public class ProdutoImagemValidation : AbstractValidator<ProdutoImagem>
{
    public ProdutoImagemValidation()
    {
        RuleFor(pi => pi.Id)
            .NotEmpty().WithMessage("O campo Id é obrigatório.");

        RuleFor(pi => pi.ProdutoId)
            .NotEmpty().WithMessage("O campo ProdutoId é obrigatório.");
    }
}
