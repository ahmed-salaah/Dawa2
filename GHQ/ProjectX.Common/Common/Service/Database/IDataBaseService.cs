using SQLite.Net;
using System.Threading.Tasks;

namespace ProjectX.Common.Common.Service.Database
{
    public interface IDatabaseService
    {
        SQLiteConnection GetInstance();

        Task CopyDb();
    }
}
