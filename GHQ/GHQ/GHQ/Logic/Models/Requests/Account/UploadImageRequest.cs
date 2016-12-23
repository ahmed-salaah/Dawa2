namespace GHQ.Logic.Models.Account.Requests
{
    public class UploadImageRequest
    {
        public string FileName { get; set; }
        public string AttachmentCode { get; set; }
        public byte[] File { get; set; }
    }
}
