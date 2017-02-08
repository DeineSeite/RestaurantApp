using SQLite.Net;

namespace RestaurantApp.Data.Access
{
    public interface IDatabaseConnection
    {
        SQLiteConnection DbConnection();
    }
}