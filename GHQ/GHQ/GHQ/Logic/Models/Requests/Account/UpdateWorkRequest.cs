using System.Collections.Generic;

namespace GHQ.Logic.Models.ServiceRegistration.Requests
{

    public class UpdateWorkRequest
    {
        public string WorkStatusID { get; set; }
        public string MaritalStatus { get; set; }
        public object CampaignAdminID { get; set; }
        public List<Work> Work { get; set; }
    }

    public class Work
    {
        public string WorkOrgTypeID { get; set; }
        public string WorkOrgCityID { get; set; }
        public string WorkOrganization { get; set; }
        public string WorkPosition { get; set; }
        public string WorkJobName { get; set; }
        public string WorkPhone1 { get; set; }
        public string WorkPhone2 { get; set; }
        public string WorkFax { get; set; }
        public string Salary { get; set; }
        public string EducationInstituteID { get; set; } //Student Only
        public string MilitaryEntityID { get; set; } //Military Only

    }

}
