using System.Collections.Generic;

namespace GHQ.Logic.Models.ServiceRegistration.Requests
{
    public class UpdateAddressRequest
    {
        public string MaritalStatus { get; set; }
        public string WorkStatusID { get; set; }
        public object CampaignAdminID { get; set; }
        public List<Address> Addresses { get; set; }
    }

    public class Address
    {
        public string CityID { get; set; }
        public string RegionID { get; set; }
        public string StreetName { get; set; }
        public string StreetNumber { get; set; }
        public string BldgName { get; set; }
        public string BldgNumber { get; set; }
        public string FloorNumber { get; set; }
        public string Mobile1 { get; set; }
        public string Mobile2 { get; set; }
        public string HomePhone1 { get; set; }
        public string HomePhone2 { get; set; }
        public string GuardianNumber { get; set; }
        public string EmailCandidate { get; set; }
        public string POBox { get; set; }
        public string AddressText { get; set; }
        public object Source { get; set; }
    }


}
