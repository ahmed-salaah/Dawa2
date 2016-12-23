using System.Collections.Generic;

namespace GHQ.Logic.Models.ServiceRegistration.Requests
{
    public class UpdateAttachmentRequest
    {
        public object CampaignAdminID { get; set; }
        public string WorkStatusID { get; set; }
        public string MaritalStatus { get; set; }
        public List<UpdateAttachment> RegistrationAttachments { get; set; }
    }

    public class UpdateAttachment
    {
        public string FileID { get; set; }
        public string FileName { get; set; }
        public string AttachmentCode { get; set; }
        public string URL { get; set; }
        public string ServiceAttachmentID { get; set; }
        public bool IsDeleted { get; set; }

    }


}
