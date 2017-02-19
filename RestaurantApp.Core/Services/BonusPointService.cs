using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreshMvvm;
using RestaurantApp.Core.Helpers;
using RestaurantApp.Core.Interfaces;
using RestaurantApp.Core.ViewModels;
using RestaurantApp.Data.Models;

namespace RestaurantApp.Core.Services
{
    public class BonusPointService :BaseService,IBonusPointService
    {
        
        public BonusPointCollection GetAllBonusPoints()
        {
            return new BonusPointCollection();
        }

        public bool ActivateBonus(BonusPointModel bonusPointModel)
        {
            return true;
        }

        public BonusPointModel GetBonusPoint(int id)
        {
            return new BonusPointModel() { Id = id };
        }

        public Task<List<BonusPointModel>> SyncBonusPointCollection(List<BonusPointModel> bonusPointCollection)
        {
            AddAppInfo(bonusPointCollection);

            var builder = new UriBuilder(Settings.AuthenticationEndpoint);
            builder.Path = $"api/BonusPoint/Sync/";
            var uri = builder.ToString();
            var newBonusPointCollection = RequestProvider.PostAsync(uri, bonusPointCollection);
            return newBonusPointCollection;
        }
    }
}
