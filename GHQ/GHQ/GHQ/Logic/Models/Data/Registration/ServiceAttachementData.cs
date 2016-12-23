namespace GHQ.Logic.Models.Data.Registration
{
    public class ServiceAttachementData
    {
        public string ServiceAttachmentID { get; set; }
        public string AttachmentCode { get; set; }
        public string Name { get; set; }
        public string NameAr { get; set; }
        public string Description { get; set; }
        public string DescriptionAr { get; set; }
        public bool IsRequired { get; set; }
        public bool IsDeleted { get; set; }
        public string AllowedExtension { get; set; }
        public object AttachmentValue { get; set; }
        public Registrationattachment Attachment { get; set; }
        public bool CanDelete
        {
            get
            {
                return Attachment != null;
            }
        }

    }
}
