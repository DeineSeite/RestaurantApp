﻿using System.Collections.Generic;
using FreshMvvm;
using RestaurantApp.Core.Helpers;
using RestaurantApp.Core.Interfaces;
using RestaurantApp.Data.Access;
using RestaurantApp.Data.Models;

namespace RestaurantApp.Core.Services
{
    public abstract class BaseService : IBaseService
    {
        protected string AccessToken
        {
            get { return Settings.AccessToken; }
            set { Settings.AccessToken = value; }
        }
        protected string AuthenticationEndpoint => Settings.AuthenticationEndpoint;
        protected IRestaurantDataAccess DataAccess
         => FreshIOC.Container.Resolve<IRestaurantDataAccess>();
        public void AddAppInfo(RestaurantBaseModel model)
        {
            model.RestaurantId = 1;
            model.UserId = Settings.UserId;
        }

        public void AddAppInfo(IEnumerable<RestaurantBaseModel> listModels)
        {
            foreach (var model in listModels)
            {
                model.RestaurantId = Settings.RestaurantId;
                model.UserId = Settings.UserId;
            }
        }
    }
}