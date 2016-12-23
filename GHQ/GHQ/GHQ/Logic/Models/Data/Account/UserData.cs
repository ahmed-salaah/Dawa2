using System;
using System.Globalization;

namespace GHQ.Logic.Models.Account.Data
{
    public class UserData
    {
        public string FullName { get; set; }
        public string BirthDate { get; set; }
        public bool IsRegistrationSubmitted { get; set; }
        
        public string FormatedBirthDate
        {
            get
            {
                DateTime formatedBD = DateTime.Now;
                DateTime.TryParse(BirthDate, out formatedBD);
                string bd = formatedBD.ToString("yyyy MMMMM dd", new CultureInfo("ar-AE"));
                return bd;
            }
        }
        public string RegStatus { get; set; }
    }
}
