namespace Lojinha.Application.Commands;

public class CriarProdutoRequest
{
    public string? Nome { get; set; }
    public decimal Preco { get; set; }
    public int Estoque { get; set; } = 0;
}
