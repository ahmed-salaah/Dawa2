using Exceptions;
using GHQ.Logic.Models.Response;
using Models;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace GHQ.Logic.Translators
{
    static public class LookupTranslator
    {
        static public List<LookupData> Translate(List<LookupValueResponse> response)
        {
            try
            {
                var translatedMobile = new List<LookupData>();
                foreach (var data in response)
                {
                    translatedMobile.Add(new LookupData { Id = data.LookupValueID, ValueAr = data.LookupValueNameAr, ValueEn = data.LookupValueName,LookupValueParentID=data.LookupValueParentID });
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
