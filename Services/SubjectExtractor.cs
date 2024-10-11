using IKDTematika.Helpers;
using IKDTematika.Services.Analyser;
using IKDTematika.Services.Parsers;

namespace IKDTematika.Services
{
    public class SubjectExtractor
    {
        private readonly IAttachmentDownloader _attachmentDownloader;
        private readonly IParserAccumulator _parserAccumulator;
        private readonly ITextAnalyser _textAnalyser;

        public SubjectExtractor(IAttachmentDownloader attachmentDownloader, IParserAccumulator parserAccumulator, ITextAnalyser textAnalyser)
        {
            _attachmentDownloader = attachmentDownloader;
            _parserAccumulator = parserAccumulator;
            _textAnalyser = textAnalyser;
        }

    }
}
