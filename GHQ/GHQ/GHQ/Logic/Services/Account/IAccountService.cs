using Exceptions;
using GHQ.Logic.Models.Account.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GHQ.Logic.Service.Account
{
    public interface IAccountService
    {
        string AccessToken { get; set; }
        bool IsLogin { get; }

        void HandleUnAuthorizedException(UnAuthorizedException ex);

        Task<int> GetStepOfAccountCreationAsync(string emiratesID, string unifiedNumber);

        Task<NewAccountData> GetMOIUserInfoAsync(string emiratesID, string unifiedNumber);

        Task<List<UserMobileData>> GetUserMobileNumbersAsync(string emiratesID, string unifiedNumber);

        Task<bool> SendVerificationCodeBySMSAsync(string emiratesID, string unifiedNumber, string mobileId);

        Task<bool> SendVerificationCodeByEmailAsync(string emiratesID, string unifiedNumber, string email);

        Task<bool> IsEmailRequiredAsync(bool isWeb);

        Task<bool> VerifyMyCodeAsync(string emiratesID, string unifiedNumber, string channel, string vrificationCode);

        Task<int> AddUserAccountAsync(NewAccountData accountData);

        Task<UserData> GetUserByEmiratesId(string accessToken);
    }
}
