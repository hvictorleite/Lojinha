namespace Lojinha.Application.Requests;

public class CriarProdutoRequest
{
    public string? Nome { get; set; }
    public decimal Preco { get; set; }
    public int Estoque { get; set; } = 0;
}
