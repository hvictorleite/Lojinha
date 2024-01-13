namespace Lojinha.Application.Requests;

public class CriarProdutoImagemRequest
{
    public Guid ProdutoId { get; set; }
    public string? Url { get; set; }
    public string? Base64 { get; set; }
}
