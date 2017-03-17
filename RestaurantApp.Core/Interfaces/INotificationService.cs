using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.OneSignal.Abstractions;

namespace RestaurantApp.Core.Interfaces
{
   public interface INotificationService:IBaseService
   {
       void ReceiveNotification(OSNotification notification);
   }
}
