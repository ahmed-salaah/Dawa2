namespace GHQ.Logic.Models.Response
{
    public class ImageFile
    {
        public string FileID { get; set; }
        public string ErrorMessage { get; set; }
        public bool IsDone { get; set; }
        public object FileData { get; set; }
        public string FileName { get; set; }
    }

}
