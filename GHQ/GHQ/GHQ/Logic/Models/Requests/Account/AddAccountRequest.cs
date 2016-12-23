namespace GHQ.Logic.Models.Account.Requests
{
    public class AddAccountRequest
    {
        public string EmiratesID { get; set; }
        public string UnifiedNumber { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string FourthName { get; set; }
        public string FifthName { get; set; }
        public string Gender { get; set; }
        public string Nationality { get; set; }
        public string DateOfBirth { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
