using System.Threading.Tasks;
using SQLite.Net;
using System;
using Service.Database;
using Xamarin.Forms;
using Service.FileHelper;

namespace Service.Dialog
{
    public class DatabaseService// : IDatabaseService
    {
        //static DatabaseService database;

        //public static DatabaseService Database
        //{
        //    get
        //    {
        //        if (database == null)
        //        {
        //            database = new DatabaseService(DependencyService.Get<IFileHelper>().GetLocalFilePath("TodoSQLite.db3"));
        //        }
        //        return database;
        //    }
        //}

        //public DatabaseService(string dbPath)
        //{
        //    database = new SQLiteAsyncConnection(dbPath);
        //    database.CreateTableAsync<TodoItem>().Wait();
        //}

        //public Task CopyDb()
        //{
        //    throw new NotImplementedException();
        //}

        //public SQLiteConnection GetInstance()
        //{
        //    throw new NotImplementedException();
        //}
    }
}
