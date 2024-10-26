

namespace parser_template.Parser.Loader;

public class HtmlLoader : IHtmlLoader
{
 

    public async Task<string> LoadPageByLink(string url)
    {
        string? html = "";
        using (var httpClient = new HttpClient())
        {
            try
            {
                var res = await httpClient.GetAsync(url);
                if (res is not null && res.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    html = await res.Content.ReadAsStringAsync();
                }
            }
            catch (HttpRequestException ex)
            {
                throw new Exception(ex.Message);
            }
        }
        return html;
    }
}
