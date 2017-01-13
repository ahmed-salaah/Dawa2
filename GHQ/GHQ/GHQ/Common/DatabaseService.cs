using Service.Database;
using Service.FileHelper;
using SQLite;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Service.DatabaseService
{
    public class DatabaseService : IDatabaseService
    {
        public DatabaseService()
        {

        }
        public Task CopyDb()
        {
            throw new NotImplementedException();
        }

        public SQLiteAsyncConnection GetInstance()
        {
            var dbPath = DependencyService.Get<IFileHelper>().GetLocalFilePath("Dawayaa.sqlite");
            var database = new SQLiteAsyncConnection(dbPath);
            return database;
        }
    }
}
