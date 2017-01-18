using System.Threading.Tasks;
using GHQ.Logic.Database.Entities;
using GHQLogic.Models.Data;

namespace GHQ.Logic.Service.Account
{
    public interface IAccountService
    {
		Task<NewUSer> Login(string userName, string Password);
		Task<NewUSer> AddEditUser(NewUSer user);
	}
}
