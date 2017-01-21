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
            Regex regex = new Regex("^(\\s*[\u0621-\u064A\040])+$");
            Match match = regex.Match(name);
            if (match.Success)
                return true;
            else
                return false;
        }

        static public bool ValidateHasSpecialCharchters(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return false;
            }
            string specialCharacters = @"%!@#$%^&*()?/>.<,:;'\|}]{[_~`+=-" + "\"";
            char[] specialCharactersArray = specialCharacters.ToCharArray();

            int index = name.IndexOfAny(specialCharactersArray);
            //index == -1 no special characters
            if (index == -1)
                return false;
            else
                return true;
        }

        static public bool ValidateHasSpecialCharchtersExceptDotAndDash(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return false;
            }
            string specialCharacters = @"%!@#$%^&*()?/><:;'\|}]{[_~`+=" + "\"";
            char[] specialCharactersArray = specialCharacters.ToCharArray();

            int index = name.IndexOfAny(specialCharactersArray);
            //index == -1 no special characters
            if (index == -1)
                return false;
            else
                return true;
        }

        static public bool ValidateMobileNumber(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return false;
            }
            Regex regex = new Regex(@"^05[0-9]{6,8}$");
            Match match = regex.Match(name);
            if (match.Success)
                return true;
            else
                return false;
        }

        static public bool ValidateMobileNumber2(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return false;
            }
            Regex regex = new Regex(@"^[\+]?[(]?[0-9]{3}[)]?[-\s\.]?[0-9]{3}[-\s\.]?[0 - 9]{1,9}$");
            Match match = regex.Match(name);
            if (match.Success)
                return true;
            else
                return false;
        }
        
       

        static public bool ValidatePhoneNumber(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return false;
            }
            Regex regex = new Regex(@"^02[0-9]{6,7}$");
            Match match = regex.Match(name);
            if (match.Success)
                return true;
            else
                return false;

        }
    }
}
