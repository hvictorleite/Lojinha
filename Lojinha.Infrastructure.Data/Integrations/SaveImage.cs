using Lojinha.Domain.Integrations;

namespace Lojinha.Infrastructure.Data.Integrations;

public class SaveImage : ISaveImage
{
    private readonly string _filePath;

    public SaveImage()
    {
        _filePath = "/Users/Public/Lojinha/imagens";
    }

    public async Task<string> SaveAndCreateUrlAsync(string imgBase64)
    {
        var fileExtension = imgBase64.Substring(imgBase64.IndexOf("/") + 1,
                                       ((imgBase64.IndexOf(";") - imgBase64.IndexOf("/")) - 1));

        var base64Code = imgBase64.Substring(imgBase64.IndexOf(",") + 1);
        var imgBytes = Convert.FromBase64String(base64Code);

        var fileName = Guid.NewGuid().ToString() + "." + fileExtension;

       if (!Directory.Exists(_filePath))
            Directory.CreateDirectory(_filePath);

        using (var imageFile = new FileStream(_filePath + "/" + fileName, FileMode.Create))
        {
            await imageFile.WriteAsync(imgBytes, 0, imgBytes.Length);
            await imageFile.FlushAsync();
        }

        return _filePath + "/" + fileName;
    }
}
