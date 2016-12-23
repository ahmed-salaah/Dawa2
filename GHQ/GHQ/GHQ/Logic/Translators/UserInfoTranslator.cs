using Exceptions;
using GHQ.Logic.Models.Account.Data;
using GHQ.Logic.Models.Response;
using GHQ.Resources.Strings;
using Newtonsoft.Json;
using System.Linq;

namespace GHQ.Logic.Translators
{
    static public class UserInfoTranslator
    {
        static public NewAccountData Translate(UserInfoResponse response)
        {
            try
            {
                var translatedMobile = new NewAccountData();
                translatedMobile.NewAccountStep1 = new NewAccountDataStep1() { EmiratesID = response.EmiratesID, UnifiedNumber = response.UnifiedNumber };
                translatedMobile.NewAccountStep2 = new NewAccountDataStep2() { MobileNumberIsConfirmed = response.IsMobileVerfied.HasValue ? response.IsMobileVerfied.Value : false };
                translatedMobile.NewAccountStep3 = new NewAccountDataStep3() { Email = response.Email, EmailIsConfirmed = response.IsEmailVerfied.HasValue ? response.IsEmailVerfied.Value : false };
                translatedMobile.NewAccountStep4 = new NewAccountDataStep4()
                {
                    FirstName = response.FirstName_Arabic,
                    SecondName = response.SecondName_Arabic,
                    ThirdName = response.ThirdName_Arabic,
                    FourthName = response.FourthName_Arabic,
                    FifthName = response.FifthName_Arabic,
                    Gender = response.Gender,
                    Nationality = response.Nationality,
                    DOB = response.DateOfBirth,
                    Password = response.Password
                };
                translatedMobile.NewAccountStep2.UserMobileList = new System.Collections.ObjectModel.ObservableCollection<UserMobileData>();
                translatedMobile.NewAccountStep2.UserMobileList.Add(new UserMobileData() { MobileID = "-2", MobileNumber = AppResources.NewAccount_Combo_Placeholder });
                translatedMobile.NewAccountStep2.UserMobileList = new System.Collections.ObjectModel.ObservableCollection<UserMobileData>(translatedMobile.NewAccountStep2.UserMobileList.Concat(new System.Collections.ObjectModel.ObservableCollection<UserMobileData>(UserMobileTranslator.Translate(response.MobileNumbers))));
                translatedMobile.NewAccountStep2.UserMobileList.Add(new UserMobileData() { MobileID = "-1", MobileNumber = AppResources.NewAccount_Messages_NotExistingNumber });
                if (!string.IsNullOrEmpty(response.FirstName_Arabic) &&
                    !string.IsNullOrEmpty(response.SecondName_Arabic) &&
                    !string.IsNullOrEmpty(response.ThirdName_Arabic))
                {
                    translatedMobile.NewAccountStep4.MOIIsDown = false;
                }
                else
                {
                    translatedMobile.NewAccountStep4.MOIIsDown = true;
                }
                return translatedMobile;
            }
            catch (System.Exception ex)
            {
                throw new ParsingException("Error Translation User Info", JsonConvert.SerializeObject(response));
            }
        }
    }
}
