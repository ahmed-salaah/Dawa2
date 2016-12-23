namespace GHQ.Logic.Models.Account.Requests
{
    public class VerifyMyCodeRequest
    {
        public string EmiratesID { get; set; }
        public string UnifiedNumber { get; set; }
        public string Channel { get; set; }
        public string VerificationCode { get; set; }
    }
}
