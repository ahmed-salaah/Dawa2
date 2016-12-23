namespace GHQ.Logic.Models.Account.Requests
{
    public class SendVerificationCodeByEmailRequest
    {
        public string EmiratesID { get; set; }
        public string UnifiedNumber { get; set; }
        public string Email { get; set; }
    }
}
