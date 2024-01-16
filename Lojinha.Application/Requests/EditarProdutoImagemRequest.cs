namespace Lojinha.Application.Requests;

public class EditarProdutoImagemRequest
{
    public Guid Id { get; set; }
    public string? Imagem { get; set; }
}
