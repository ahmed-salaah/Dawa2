using SQLite;
using System.Threading.Tasks;

namespace Service.Database
{
    public interface IDatabaseService
    {
        SQLiteAsyncConnection GetInstance();

        Task CopyDb();
    }
}
