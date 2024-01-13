namespace Lojinha.Application.Requests;

public class EditarProdutoImagemRequest
{
    public Guid Id { get; set; }
    public string? Url { get; set; }
    public string? Base64 { get; set; }
}
