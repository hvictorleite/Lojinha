namespace Lojinha.Application.Responses;

public class ProdutoImagemResponse
{
    public Guid Id { get; set; }
    public Guid ProdutoId { get; set; }
    public string? Url { get; set; }
    public string? Base64 { get; set; }
}
