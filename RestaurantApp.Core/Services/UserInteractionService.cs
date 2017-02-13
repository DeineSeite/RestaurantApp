using FreshMvvm;
using RestaurantApp.Core.Interfaces;

namespace RestaurantApp.Core.Services
{
    public static class UserInteractionService 
    {
        public static void DisplayAlert(string title, string content)
        {
            var mainPage = FreshIOC.Container.Resolve<IMainPageModel>();
            mainPage.CurrentPage.DisplayAlert(title, content,"OK");
        }
    }
}