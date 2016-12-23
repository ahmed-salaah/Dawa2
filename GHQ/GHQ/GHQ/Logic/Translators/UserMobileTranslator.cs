using Exceptions;
using GHQ.Logic.Models.Account.Data;
using GHQ.Logic.Models.Response;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace GHQ.Logic.Translators
{
    static public class UserMobileTranslator
    {
        static public List<UserMobileData> Translate(List<GetUserMobileNumbersResponse> response)
        {
            try
            {
                var translatedMobile = new List<UserMobileData>();
                foreach (var data in response)
                {
                    translatedMobile.Add(new UserMobileData { MobileID = data.MobileID, MobileNumber = data.MobileNumber });
                }
                return translatedMobile;
            }
            catch (System.Exception ex)
            {
                throw new ParsingException("Error Translating User Mobile", JsonConvert.SerializeObject(response));
            }
        }
    }
}
