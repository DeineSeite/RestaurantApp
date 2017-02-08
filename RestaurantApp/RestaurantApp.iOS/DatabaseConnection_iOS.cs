using System;
using System.IO;
using RestaurantApp.Data.Access;
using RestaurantApp.iOS;
using SQLite.Net;
using SQLite.Net.Platform.XamarinIOS;
using Xamarin.Forms;

[assembly: Dependency(typeof(DatabaseConnection_iOS))]

namespace RestaurantApp.iOS
{
    public class DatabaseConnection_iOS : IDatabaseConnection
    {
        public SQLiteConnection DbConnection()
        {
            var dbName = "RestaurantApp.db3";
            var personalFolder =
                Environment.
                    GetFolderPath(Environment.SpecialFolder.Personal);
            var libraryFolder =
                Path.Combine(personalFolder, "..", "Library");
            var path = Path.Combine(libraryFolder, dbName);
            return new SQLiteConnection(new SQLitePlatformIOS(), path);
        }
    }
}