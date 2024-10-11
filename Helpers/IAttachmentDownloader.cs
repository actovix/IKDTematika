namespace IKDTematika.Helpers
{
    public interface IAttachmentDownloader
    {
        public Task<Attachment> Download(string source);
    }
}
