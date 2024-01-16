namespace Lojinha.Application.Requests;

public class CriarProdutoImagemRequest
{
    public Guid ProdutoId { get; set; }
    public string? Imagem { get; set; }
}
