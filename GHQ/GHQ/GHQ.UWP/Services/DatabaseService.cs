﻿using Service.Database;
using Service.DatabaseService;
using SQLite;
using System;
using System.IO;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.Storage;
using Xamarin.Forms;

[assembly: Dependency(typeof(DatabaseService))]

namespace Service.DatabaseService
{
    public class DatabaseService : IDatabaseService
    {
        public DatabaseService()
        {

        }
        public async Task CopyDb()
        {
            var sqliteFilename = @"GHQ\Logic\Database\Dawayaa.sqlite";
            var installedFolderPath = Path.Combine(Package.Current.InstalledLocation.Path, sqliteFilename);
            StorageFile seedFile = await StorageFile.GetFileFromPathAsync(installedFolderPath);
            StorageFolder local = null;
            try
            {
                local = await ApplicationData.Current.LocalFolder.GetFolderAsync("Database");
            }
            catch
            {
            }

            if (local == null)
            {
                local = await ApplicationData.Current.LocalFolder.CreateFolderAsync("Database");
                await seedFile.CopyAsync(local);
            }
        }

        public SQLiteConnection GetInstance()
        {
            CopyDb();
            var sqliteFilename = @"Database\Dawayaa.sqlite";
            string path = Path.Combine(ApplicationData.Current.LocalFolder.Path, sqliteFilename);
            return new SQLiteConnection(path);
        }
    }
}
