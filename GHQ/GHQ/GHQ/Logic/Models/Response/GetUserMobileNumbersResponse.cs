namespace GHQ.Logic.Models.Response
{
    public class GetUserMobileNumbersResponse
    {
        public string MobileID { get; set; }
        public string MobileNumber { get; set; }
        public string UserAccountID { get; set; }
        public object UserAccount { get; set; }
    }

}
