using Android.OS;
using RestaurantApp.Core.Interfaces;

namespace RestaurantApp.Droid.Dependencies
{
    public class EnvironmentService : IEnvironmentService
    {
        #region IEnvironmentService implementation

        public bool IsRealDevice
        {
            get
            {
                var f = Build.Fingerprint;
                return !(f.Contains("vbox") || f.Contains("generic") || f.Contains("vsemu"));
            }
        }

        #endregion
    }
}