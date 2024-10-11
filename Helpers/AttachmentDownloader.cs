namespace IKDTematika.Helpers;

public class AttachmentDownloader : IAttachmentDownloader
{
  
    private readonly IHttpClientFactory _httpClientFactory;
    public AttachmentDownloader( IHttpClientFactory httpClientFactory)
    {
      
        _httpClientFactory = httpClientFactory;
    }

    public async Task<Attachment> Download(string source) 
    {
        Attachment attachment = new();
        byte[] resp;
        using (var httpClient = _httpClientFactory.CreateClient())
        {
            resp = await httpClient.GetByteArrayAsync(source);
        }
        return new Attachment() {
            Data = resp,
            Extention = GetExtention(source)
        };
    }

    public string GetExtention(string link)
    {
        return Path.GetExtension(link).Replace(".", "");
    }
}
