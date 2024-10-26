namespace parser_template.Parser.Loader;

public interface IHtmlLoader
{
    public Task<string> LoadPageByLink(string url);
}
