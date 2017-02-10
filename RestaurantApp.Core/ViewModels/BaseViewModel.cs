using System.ComponentModel;
using System.Runtime.CompilerServices;
using FreshMvvm;
using RestaurantApp.Core.Annotations;
using RestaurantApp.Core.Interfaces;

namespace RestaurantApp.Core.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public BaseViewModel()
        {
            NavigationContentService = FreshIOC.Container.Resolve<IContentNavigationService>();
        }

        public IBaseContentView CurrentContentView { get; set; }
        public IContentNavigationService NavigationContentService { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        public void Init(object data)
        {
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}