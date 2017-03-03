using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantApp.Core.Interfaces;
using RestaurantApp.Core.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(CapabilityService))]

namespace RestaurantApp.Core.Services
{
    public class CapabilityService : ICapabilityService

    {

        readonly IEnvironmentService _EnvironmentService;



        public CapabilityService()

        {

            _EnvironmentService = DependencyService.Get<IEnvironmentService>();

        }



        #region ICapabilityService implementation



        public bool CanMakeCalls => _EnvironmentService.IsRealDevice || (Device.OS != TargetPlatform.iOS);



        public bool CanSendMessages => _EnvironmentService.IsRealDevice || (Device.OS != TargetPlatform.iOS);



        public bool CanSendEmail => _EnvironmentService.IsRealDevice || (Device.OS != TargetPlatform.iOS);



        #endregion

    }
}
