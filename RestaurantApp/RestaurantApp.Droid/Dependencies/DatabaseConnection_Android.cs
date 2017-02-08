using System;
using System.IO;
using RestaurantApp.Data.Access;
using RestaurantApp.Droid.Dependencies;
using SQLite.Net;
using SQLite.Net.Platform.XamarinAndroid;
using Xamarin.Forms;

[assembly: Dependency(typeof(DatabaseConnection_Android))]

namespace RestaurantApp.Droid.Dependencies
{
    public class DatabaseConnection_Android : IDatabaseConnection
    {
        public SQLiteConnection DbConnection()
        {
            var dbName = "RestaurantApp.db3";
            var path = Path.Combine(Environment.
                GetFolderPath(Environment.SpecialFolder.Personal), dbName);
            return new SQLiteConnection(new SQLitePlatformAndroid(), path);
        }
    }
}