using System.IO;
using Windows.Storage;
using RestaurantApp.Data.Access;
using RestaurantApp.UWP;
using SQLite.Net;
using SQLite.Net.Platform.WinRT;
using Xamarin.Forms;

[assembly: Dependency(typeof(DatabaseConnection_UWP))]

namespace RestaurantApp.UWP
{
    public class DatabaseConnection_UWP : IDatabaseConnection
    {
        public SQLiteConnection DbConnection()
        {
            var dbName = "RestaurantApp.db3";
            var path = Path.Combine(ApplicationData.
                Current.LocalFolder.Path, dbName);
            return new SQLiteConnection(new SQLitePlatformWinRT(), path);
        }
    }
}