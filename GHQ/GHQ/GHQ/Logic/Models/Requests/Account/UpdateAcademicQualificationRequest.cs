using System;
using System.Collections.Generic;

namespace GHQ.Logic.Models.ServiceRegistration.Requests
{
    public class UpdateAcademicQualificationRequest
    {
        public string WorkStatusID { get; set; }
        public string MaritalStatus { get; set; }
        public object CampaignAdminID { get; set; }
        public List<Academicqualification> AcademicQualifications { get; set; }
    }

    public class Academicqualification
    {
        public string AcademicQualificationID { get; set; }
        public string AcademicCountryID { get; set; }
        public string EducationInstituteID { get; set; }
        public string MainSpecializationID { get; set; }
        public string SubSpecializationID { get; set; }
        public string JobLevel { get; set; }
        public DateTime GraduationDate { get; set; }
        public string Grade { get; set; }
        public string GPA { get; set; }
        public string Notes { get; set; }
        public bool ISEducationFinished { get; set; }
        public bool IsDeleted { get; set; }
    }

}
