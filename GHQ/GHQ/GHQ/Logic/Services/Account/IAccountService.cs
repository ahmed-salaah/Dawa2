using System.Threading.Tasks;
using GHQLogic.Models.Data;

namespace GHQ.Logic.Service.Account
{
    public interface IAccountService
    {
		NewUser CurrentAccount { get; set; }
		Task<NewUser> Login(string userName, string Password);
		Task<NewUser> AddEditUser(NewUser user);
        NewUser GetUser(int userId);
	}
}
