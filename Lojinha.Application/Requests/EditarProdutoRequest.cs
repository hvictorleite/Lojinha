namespace Lojinha.Application.Requests;

public class EditarProdutoRequest
{
    public Guid Id { get; set; }
    public string? Nome { get; set; }
    public decimal Preco { get; set; }
    public int Estoque { get; set; }
}
