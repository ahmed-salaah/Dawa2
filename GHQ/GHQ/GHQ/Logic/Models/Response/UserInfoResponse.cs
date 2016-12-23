using System;
using System.Collections.Generic;

namespace GHQ.Logic.Models.Response
{
    public class UserInfoResponse
    {
        public string ID { get; set; }
        public string EmiratesID { get; set; }
        public string UnifiedNumber { get; set; }
        public bool? IsMobileVerfied { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public bool? IsEmailVerfied { get; set; }
        public string FirstName_English { get; set; }
        public string FirstName_Arabic { get; set; }
        public string SecondName_English { get; set; }
        public string SecondName_Arabic { get; set; }
        public string ThirdName_English { get; set; }
        public string ThirdName_Arabic { get; set; }
        public string FourthName_English { get; set; }
        public string FourthName_Arabic { get; set; }
        public string FifthName_English { get; set; }
        public string FifthName_Arabic { get; set; }
        public string Password { get; set; }
        public object Status { get; set; }
        public object IsDeleted { get; set; }
        public object CreatedDate { get; set; }
        public object LastUpdatedDate { get; set; }
        public object IP { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Nationality { get; set; }
        public string NationalityDisplayName { get; set; }
        public string Gender { get; set; }
        public object RegistrationStatus { get; set; }
        public object CampaignID { get; set; }
        public List<GetUserMobileNumbersResponse> MobileNumbers { get; set; }
    }
}
