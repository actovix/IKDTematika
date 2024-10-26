using AngleSharp.Dom;
using AngleSharp.Html.Dom;

namespace IKDTematika.Services.Parsers.ISTUParser
{
    public class ISTUParser
    {
        public List<string> Parse(IHtmlDocument htmlDocument)
        {
            List<string> productList = new List<string>();

           ;
            
            var rows = htmlDocument.QuerySelectorAll(".tabcontrol-content-inner .istu-table tbody tr td:first-child");
         


            foreach (var item in rows)
            {
                productList.Add(item.Text());
            }

            return productList;

        }
    }
}
