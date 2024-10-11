using IKDTematika.Models;

namespace IKDTematika.Services.Parsers
{
    public interface IParserAccumulator
    {
        public List<PDFText> GetPDFTexts();
    }
}
