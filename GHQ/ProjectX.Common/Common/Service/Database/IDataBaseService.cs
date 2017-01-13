using SQLite.Net;
using System.Threading.Tasks;

namespace Service.Database
{
    public interface IDatabaseService
    {
        SQLiteConnection GetInstance();

        Task CopyDb();
    }
}
