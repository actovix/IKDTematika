using IKDTematika.Models;
using IKDTematika.Services.Parsers.PDFParsers;

namespace IKDTematika.Services.Parsers
{
    public class ParserAccumulator : IParserAccumulator
    {
        private readonly AnotationParser _anotationParser = new();
        private readonly RPDParser rPDParser = new();

        public ParserAccumulator() 
        {
            

        }
        public List<PDFText> GetPDFTexts()
        {
            
                
            throw new NotImplementedException();
        }
    }
}
