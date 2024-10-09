namespace IKDTematika.Helpers;

public class AttachmentDownloader
{
    private readonly string _source = "";
    private readonly IHttpClientFactory _httpClientFactory;
    public AttachmentDownloader(string source, IHttpClientFactory httpClientFactory)
    {
        _source = source;
        _httpClientFactory = httpClientFactory;
    }

    public async Task<Attachment> Download()
    {
        Attachment attachment = new();
        byte[] resp;
        using (var httpClient = _httpClientFactory.CreateClient())
        {
            resp = await httpClient.GetByteArrayAsync(_source);
        }
        return new Attachment() {
            Data = resp,
            Extention = GetExtention(_source)
        };
    }

    public string GetExtention(string link)
    {
        return Path.GetExtension(link).Replace(".", "");
    }
}
