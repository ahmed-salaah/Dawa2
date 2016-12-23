using System.Text.RegularExpressions;
namespace Validations
{
    public static class Validation
    {
        static public bool ValidateEmiratesId(string emiratesId)
        {
            if (string.IsNullOrEmpty(emiratesId))
            {
                return false;
            }
            Regex regex = new Regex(@"^784-(19|20)[0-9]{2}-[0-9]{7}-[0-9]{1}$");
            Match match = regex.Match(emiratesId);
            if (match.Success)
                return true;
            else
                return false;
        }

        static public bool ValidateMail(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                return false;
            }
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            if (match.Success)
                return true;
            else
                return false;
        }

        static public bool ValidateEnglishName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return false;
            }
            Regex regex = new Regex(@"^[a-zA-Z ]+$");
            Match match = regex.Match(name);
            if (match.Success)
                return true;
            else
                return false;
        }

        static public bool ValidateArabicName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return false;
            }
            Regex regex = new Regex("^[\u0600-\u06ff]|[\u0750-\u077f]|[\ufb50-\ufc3f]|[\ufe70-\ufefc] +$");
            Match match = regex.Match(name);
            if (match.Success)
                return true;
            else
                return false;
        }

        static public bool ValidateHasSpecialCharchters(string name)
        {
            string specialCharacters = @"%!@#$%^&*()?/>.<,:;'\|}]{[_~`+=-" + "\"";
            char[] specialCharactersArray = specialCharacters.ToCharArray();

            int index = name.IndexOfAny(specialCharactersArray);
            //index == -1 no special characters
            if (index == -1)
                return false;
            else
                return true;
        }
    }
}
