namespace Lojinha.Domain.Integrations;

public interface ISaveImage
{
    Task<string> SaveAndCreateUrlAsync(string imgBase64);
}
