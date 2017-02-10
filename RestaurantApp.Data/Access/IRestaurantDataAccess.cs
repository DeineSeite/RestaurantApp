using RestaurantApp.Data.Models;

namespace RestaurantApp.Data.Access
{
    public interface IRestaurantDataAccess : IDataAccess
    {
        RestaurantModel GetCurrentRestaurant();
        int SetCurrentRestaurant(RestaurantModel restaurant);
        int AddNewBonusPoint(BonusPointModel bonusPoint);
        int UpdateBonusPoint(BonusPointModel bonusPoint);
        int SetNewUser(UserModel user);
        UserModel GetCurrentUser();
    }
}