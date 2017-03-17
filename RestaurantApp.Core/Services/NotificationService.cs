using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Com.OneSignal.Abstractions;
using FreshMvvm;
using RestaurantApp.Core.Interfaces;
using RestaurantApp.Data.Access;
using RestaurantApp.Data.Models;

namespace RestaurantApp.Core.Services
{
  public  class NotificationService:BaseService,INotificationService
    {
        public void ReceiveNotification(OSNotification notification)
        {
            var action = new ActionModel();
            action.Title = notification.payload.title;
            action.Description = notification.payload.body;
            action.Date = DateTime.Now;
            action.Image = notification.payload.largeIcon ?? "placeholder.png";
            DataAccess.AddAction(action);
        }
    }
}
