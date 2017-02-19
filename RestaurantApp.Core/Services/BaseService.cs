using System.Collections.Generic;
using FreshMvvm;
using RestaurantApp.Core.Helpers;
using RestaurantApp.Core.Interfaces;
using RestaurantApp.Data.Models;

namespace RestaurantApp.Core.Services
{
  public abstract class BaseService:IBaseService
    {
        public IRequestProvider RequestProvider { get; }

        public BaseService()
        {
            RequestProvider = FreshIOC.Container.Resolve<IRequestProvider>();
            RequestProvider.AccessToken = Settings.AccessToken;
        }

        public static void AddAppInfo(RestaurantBaseModel model)
        {
            model.RestaurantId = Settings.RestaurantId;
            model.UserId = Settings.UserId;
        }
        public static void AddAppInfo(IEnumerable<RestaurantBaseModel> listModels)
        {
            foreach (var model in listModels)
            {
                model.RestaurantId = Settings.RestaurantId;
                model.UserId = Settings.UserId;
            }
        }
    }
}
