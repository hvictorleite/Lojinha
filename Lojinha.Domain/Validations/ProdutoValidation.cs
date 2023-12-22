using FluentValidation;
using Lojinha.Domain.Entities;
using System.Text.RegularExpressions;

namespace Lojinha.Domain.Validations;

public class ProdutoValidation : AbstractValidator<Produto>
{
    public ProdutoValidation()
    {
        RuleFor(p => p.Id)
            .NotEmpty().WithMessage("O campo Id é obrigatório.");

        RuleFor(p => p.Nome)
            .NotEmpty().WithMessage("O campo Nome é obrigatório.")
            .Length(6, 150).WithMessage("O campo Nome deve ter entre 6 e 150 caracteres.");

        RuleFor(p => p.Preco)
            .NotEmpty().WithMessage("O campo Preco é obrigatório.")
            .GreaterThan(0).WithMessage("O valor do campo Preco deve ser maior que zero.");
        
        RuleFor(p => p.Estoque)
            .Must(isNumeroInteiro).WithMessage("O campo Estoque deve ser um número inteiro.")
            .GreaterThanOrEqualTo(0).WithMessage("O valor do campo Estoque deve ser maior ou igual a zero.");
    }

    private static bool isNumeroInteiro(int estoque)
        => Regex.IsMatch(estoque.ToString(), @"^\d+$");
}