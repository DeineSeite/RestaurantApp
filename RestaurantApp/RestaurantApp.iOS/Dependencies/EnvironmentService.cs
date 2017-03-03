using ObjCRuntime;
using RestaurantApp.Core.Interfaces;

namespace RestaurantApp.iOS.Dependencies
{
    public class EnvironmentService : IEnvironmentService
    {
        #region IEnvironmentService implementation

        public bool IsRealDevice => Runtime.Arch == Arch.DEVICE;

        #endregion
    }
}