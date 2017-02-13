using RestaurantApp.Core.ViewModels;
using RestaurantApp.Data.Models;

namespace RestaurantApp.Core.Interfaces
{
    public interface IBonusPointService
    {
        BonusPointCollection GetAllBonusPoints();
        bool ActivateBonus(BonusPointModel bonusPointModel);
        BonusPointModel GetBonusPoint(int id);
    }
}