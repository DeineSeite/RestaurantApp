using System.Collections.Generic;
using System.Threading.Tasks;
using RestaurantApp.Core.ViewModels;
using RestaurantApp.Data.Models;

namespace RestaurantApp.Core.Interfaces
{
    public interface IBonusPointService:IBaseService
    {
        BonusPointCollection GetAllBonusPoints();
        bool ActivateBonus(BonusPointModel bonusPointModel);
        BonusPointModel GetBonusPoint(int id);
        Task<List<BonusPointModel>> SyncBonusPointCollection(List<BonusPointModel> bonusPointCollection);
    }
}