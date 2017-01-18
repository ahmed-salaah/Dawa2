using System.Threading.Tasks;
using GHQ.Logic.Database.Entities;

namespace GHQ.Logic.Service.Account
{
    public interface IAccountService
    {
		Task<User> Login(string userName, string Password);
		Task<User> AddEditUser(User user);
    }
}
