using FluentValidation;
using Lojinha.Domain.Entities;

namespace Lojinha.Domain.Validations;

public class ProdutoValidation : AbstractValidator<Produto>
{
    public ProdutoValidation()
    {
        RuleFor(p => p.Id)
            .NotEmpty().WithMessage("O campo Id é obrigatório.");

        RuleFor(p => p.Nome)
            .NotEmpty().WithMessage("O campo Nome é obrigatório.")
            .Length(6, 100).WithMessage("O campo Nome deve ter entre 6 e 100 caracteres.");

        RuleFor(p => p.Preco)
            .GreaterThan(0).WithMessage("O valor do campo Preco deve ser maior que zero.");
        
        RuleFor(p => p.Estoque)
            .GreaterThan(0).WithMessage("O valor do campo Estoque deve ser maior que zero.");
    }
}