using System.Collections.Generic;
using System.Linq;
using RestaurantApp.Data.Models;

namespace RestaurantApp.Data.Access
{
    public class RestaurantDataAccess : BaseDataAccess, IRestaurantDataAccess
    {
        public override void CreateTables()
        {
            CreateTable<RestaurantModel>();
            CreateTable<UserModel>();
            CreateTable<BonusPointModel>();
        }

        /// <summary>
        ///     Will always take fist row from table because every time when you set new the old row will be deleted
        /// </summary>
        /// <returns></returns>
        public RestaurantModel GetCurrentRestaurant()
        {
            return GetTable<RestaurantModel>().FirstOrDefault();
        }

        /// <summary>
        ///     It will delete all restaurants in table and add new one
        /// </summary>
        /// <param name="restaurant"></param>
        /// <returns>Restaurant id</returns>
        public int SetCurrentRestaurant(RestaurantModel restaurant)
        {
            DeleteAllRows<RestaurantModel>();
            AddNewRow(restaurant);
            return restaurant.Id;
        }

        public IEnumerable<BonusPointModel> GetAllBonusPoints(BonusPointType type)
        {
          return  GetTable<BonusPointModel>().Where(x => x.Type == type);
        }
        public int AddNewBonusPoint(BonusPointModel bonusPoint)
        {
            AddNewRow(bonusPoint);
            return bonusPoint.Id;
        }

        public int UpdateBonusPoint(BonusPointModel bonusPoint)
        {
            UpdateRow(bonusPoint);
            return bonusPoint.Id;
        }

        /// <summary>
        ///     It will delete all users in table and add new one
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public int SetNewUser(UserModel user)
        {
            DeleteAllRows<RestaurantModel>();
            AddNewRow(user);
            return user.Id;
        }

        /// <summary>
        ///     Will always take fist row from table because every time when you set new the old row will be deleted
        /// </summary>
        /// <returns></returns>
        public UserModel GetCurrentUser()
        {
            return GetTable<UserModel>().FirstOrDefault();
        }
    }
}