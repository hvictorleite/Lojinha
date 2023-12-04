using FluentAssertions;
using Lojinha.Domain.Entities;
using Xunit;

namespace Lojinha.UnitTests.Entities;

public class ProdutoTest
{
    [Fact]
    public void ValidarIdTest()
    {
        var produto = new Produto { Id = Guid.Empty };

        produto.Validate
            .Errors
            .FirstOrDefault(err => err.ErrorMessage.Contains("O campo Id é obrigatório."))
            .Should()
            .NotBeNull();
    }

    [Fact]
    public void ValidarNomeTest()
    {
        var produto = new Produto { Nome = string.Empty };

        produto.Validate
            .Errors
            .FirstOrDefault(err => err.ErrorMessage.Contains("O campo Nome deve ter entre 6 e 150 caracteres."))
            .Should()
            .NotBeNull();
    }

    [Fact]
    public void ValidarPrecoTest()
    {
        var produto = new Produto { Preco = decimal.Zero };

        produto.Validate
            .Errors
            .FirstOrDefault(err => err.ErrorMessage.Contains("O valor do campo Preco deve ser maior que zero."))
            .Should()
            .NotBeNull();
    }
}
