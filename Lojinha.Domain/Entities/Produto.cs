using FluentValidation.Results;
using Lojinha.Domain.Core;
using Lojinha.Domain.Validations;

namespace Lojinha.Domain.Entities;

public class Produto : IEntity<Guid>
{
    public Guid Id { get; set; }
    public string? Nome { get; set; }
    public decimal Preco { get; set; }
    public int Estoque { get; private set; } = 0;

    public void AdicionarAoEstoque(int quantidade) => Estoque += quantidade;

    public void RetirarDoEstoque(int quantidade){
        if (quantidade > Estoque) throw new DomainException("Estoque insuficiente.");
        
        Estoque -= quantidade;
    }

    public ValidationResult Validate
        => new ProdutoValidation().Validate(this);
}