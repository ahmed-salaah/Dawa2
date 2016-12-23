namespace GHQ.Logic.Models.Account.Requests
{
    public class SendVerificationCodeBySMSRequest
    {
        public string EmiratesID { get; set; }
        public string UnifiedNumber { get; set; }
        public string MobileID { get; set; }
    }
}
