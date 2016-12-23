using Exceptions;
using GHQ.Logic.Models.Data.Registration;
using GHQ.Logic.Models.Response;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace GHQ.Logic.Translators
{
    static public class ServiceAttachementTranslator
    {
        static public List<ServiceAttachementData> Translate(List<GetServiceAttachementResponse> response)
        {
            try
            {
                var translatedMobile = new List<ServiceAttachementData>();
                foreach (var data in response)
                {
                    translatedMobile.Add(new ServiceAttachementData { AllowedExtension = data.AllowedExtension, AttachmentCode = data.AttachmentCode, AttachmentValue = data.AttachmentValue, Description = data.Description, DescriptionAr = data.DescriptionAr, IsRequired = data.IsRequired, Name = data.Name, NameAr = data.NameAr, ServiceAttachmentID = data.ServiceAttachmentID });
                }
                return translatedMobile;
            }
            catch (System.Exception ex)
            {
                throw new ParsingException("Error Translating Service Attachement", JsonConvert.SerializeObject(response));
            }
        }
    }
}
