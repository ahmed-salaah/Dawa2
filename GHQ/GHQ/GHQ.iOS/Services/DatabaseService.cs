using GHQ.ios.Services;
using Service.Database;
using SQLite;
using System;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Forms;

[assembly: Dependency(typeof(DatabaseService))]
namespace GHQ.ios.Services
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

        public SQLiteConnection GetInstance()
        {
            var sqliteFilename = "Dawayaa.sqlite";
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal); // Documents folder
            string libraryPath = Path.Combine(documentsPath, "..", "Library"); // Library folder
            var path = Path.Combine(libraryPath, sqliteFilename);

            // This is where we copy in the prepopulated database
            Console.WriteLine(path);
            if (!File.Exists(path))
            {
                File.Copy(sqliteFilename, path);
            }

            var conn = new SQLiteConnection(path);

            // Return the database connection 
            return conn;
        }



    }
}
