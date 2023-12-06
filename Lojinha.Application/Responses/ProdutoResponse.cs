namespace Lojinha.Application.Queries;

public class ProdutoResponse
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public decimal Preco { get; set; }
    public int Estoque { get; set; }
}
