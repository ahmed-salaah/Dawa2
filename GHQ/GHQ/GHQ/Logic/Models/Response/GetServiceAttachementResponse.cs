namespace GHQ.Logic.Models.Response
{
    public class GetServiceAttachementResponse
    {
        public string ServiceAttachmentID { get; set; }
        public string AttachmentCode { get; set; }
        public string Name { get; set; }
        public string NameAr { get; set; }
        public string Description { get; set; }
        public string DescriptionAr { get; set; }
        public bool IsRequired { get; set; }
        public bool ForWeb { get; set; }
        public bool ForMobile { get; set; }
        public bool ManagedbyAdmin { get; set; }
        public string AllowedExtension { get; set; }
        public bool IsDeleted { get; set; }
        public object AttachmentValue { get; set; }
    }

}
