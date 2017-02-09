namespace RestaurantApp.Core.Interfaces
{
    public interface IBasePage
    {
        string Title { get; set; }
        string SubTitle { get; set; }
        void GoBackButton();
    }
}