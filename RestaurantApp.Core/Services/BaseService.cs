using FreshMvvm;
using RestaurantApp.Core.Interfaces;

namespace RestaurantApp.Core.Services
{
  public abstract class BaseService:IBaseService
    {
        public IRequestProvider RequestProvider { get; }

        public BaseService()
        {
            RequestProvider = FreshIOC.Container.Resolve<IRequestProvider>();
        }
    }
}
