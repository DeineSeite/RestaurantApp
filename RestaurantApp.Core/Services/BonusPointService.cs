using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantApp.Core.Interfaces;
using RestaurantApp.Core.ViewModels;
using RestaurantApp.Data.Models;

namespace RestaurantApp.Core.Services
{
  public  class BonusPointService:IBonusPointService
    {
        public BonusPointCollection GetAllBonusPoints()
        {
            return  new BonusPointCollection();
        }

        public bool ActivateBonus(BonusPointModel bonusPointModel)
        {
            return true;
        }

        public BonusPointModel GetBonusPoint(int id)
        {
            return  new BonusPointModel() {Id = id};
        }

        
    }
}
