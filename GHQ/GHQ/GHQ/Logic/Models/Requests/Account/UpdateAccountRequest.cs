namespace GHQ.Logic.Models.Account.Requests
{
    public class UpdateAccountRequest
    {
        public string op { get; set; }
        public string path { get; set; }
        public string value { get; set; }
    }
}
