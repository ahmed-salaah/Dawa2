using System.Collections.Generic;

namespace GHQ.Logic.Models.ServiceRegistration.Requests
{
    public class UpdateRelativeRequest
    {
        public bool OnlySon { get; set; }
        public object CampaignAdminID { get; set; }
        public string WorkStatusID { get; set; }
        public string MaritalStatus { get; set; }
        public List<Relative> Relatives { get; set; }
    }

    public class Relative
    {
        public string FirstName_Arabic { get; set; }
        public string FirstName_English { get; set; }
        public string SecondName_Arabic { get; set; }
        public string SecondName_English { get; set; }
        public string ThirdName_Arabic { get; set; }
        public string ThirdName_English { get; set; }
        public string FourthName_Arabic { get; set; }
        public string FourthName_English { get; set; }
        public string FifthName_Arabic { get; set; }
        public string FifthName_English { get; set; }
        public string Nationality { get; set; }
        public string WorkPlace { get; set; }
        public string TribeID { get; set; }
        public string RelativeType { get; set; }
        public string RelativeTypeName { get; set; }
        public string ResidencePlaceID { get; set; }
        public string StatusOfRelative { get; set; }
        public string BirthPlace { get; set; }
        public string JobName { get; set; }
        public int? AgeOfRelative { get; set; }
        public bool? IsAlive { get; set; }
        public object isBrother { get; set; }
        public object HalfBrotherRelation { get; set; }
        public string GHQID { get; set; }
        public string A_Name { get; set; }
        public string E_Name { get; set; }
        public string Source { get; set; }
        public bool IsDeleted { get; set; } = false;
        public Tribe Tribe { get; set; }
        public Relativetypeobj RelativeTypeObj { get; set; }
    }

    public class Tribe
    {
        public string LookupValueID { get; set; }
        public object LookupValueName { get; set; }
        public string LookupValueNameAr { get; set; }
        public object LookupValueParentID { get; set; }
        public object MOIID { get; set; }
        public object DisplayOrders { get; set; }
    }

    public class Relativetypeobj
    {
        public string LookupValueID { get; set; }
        public object LookupValueName { get; set; }
        public string LookupValueNameAr { get; set; }
        public object LookupValueParentID { get; set; }
        public object MOIID { get; set; }
        public object DisplayOrders { get; set; }
    }

}
