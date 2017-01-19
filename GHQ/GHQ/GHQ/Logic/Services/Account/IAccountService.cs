using System.Threading.Tasks;
using GHQ.Logic.Database.Entities;
using GHQLogic.Models.Data;

namespace GHQ.Logic.Service.Account
{
    public interface IAccountService
    {
		NewUSer CurrentAccount { get; set; }
		Task<NewUSer> Login(string userName, string Password);
		Task<NewUSer> AddEditUser(NewUSer user);
		void GetLoggedInUser(int userId);
	}
}
