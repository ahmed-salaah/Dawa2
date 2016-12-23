using System;
namespace GHQ.Logic.Models.Response
{

    //public class NotificationResponses
    //{
    //    public NotificationResponse[] Property1 { get; set; }
    //}

    public class NotificationResponse
    {
        public string ID { get; set; }
        public string Message { get; set; }
        public string Masked { get; set; }
        public bool SendSMS { get; set; }
        public bool SendEmail { get; set; }
        public bool SendPush { get; set; }
        public string Criteria { get; set; }
        public string Tag { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Type { get; set; }
        public string Source { get; set; }
        public bool IsRead { get; set; }
        public object[] NotificationCampaignsUsers { get; set; }
        public Searchfiltersobject SearchFiltersObject { get; set; }
        public string NotificationCampaignsUserID { get; set; }
    }

    public class Searchfiltersobject
    {
        public int AgeFrom { get; set; }
        public int AgeTo { get; set; }
        public object GenderID { get; set; }
        public object[] SelectedNationalities { get; set; }
    }

}
