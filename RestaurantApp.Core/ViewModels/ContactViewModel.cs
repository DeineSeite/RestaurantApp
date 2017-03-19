using System;
using System.IO;
using System.Net;
using System.Reflection;
using Plugin.Messaging;
using RestaurantApp.Core.Helpers;
using RestaurantApp.Data.Models;
using Xamarin.Forms;

namespace RestaurantApp.Core.ViewModels
{
    public class ContactViewModel : BaseViewModel
    {
        public ContactViewModel()
        {
            MessageNumberCommand = new Command(MessageNumber);
            DialNumberCommand = new Command(DialNumber);
            EmailCommand = new Command(SendEmail);
            NavigateToMap = new Command(NavigateTo);

            Restaurant = new RestaurantModel();
            Restaurant.Phone = "01/256 89 80";
            Restaurant.Email = "lokal@gastroapp.at";
            Restaurant.Street = "Wagramer Strasse";
            Restaurant.PostalCode = "1210";
            Restaurant.City = "Wien";
            Restaurant.Company = "Gastro App";
            Restaurant.Latitude = 48.2542395;
            Restaurant.Longitude = 16.4446964;
           
        }

        public Command NavigateToMap { get; set; }
        public Command MessageNumberCommand { get; set; }
        public Command DialNumberCommand { get; set; }
        public Command EmailCommand { get; set; }
        public RestaurantModel Restaurant { get; set; }

        private void MessageNumber()
        {
            if (string.IsNullOrWhiteSpace(Restaurant.Phone))
                return;

            var messageTask = MessagingPlugin.SmsMessenger;

            if (messageTask.CanSendSms)
                messageTask.SendSms(Restaurant.Phone.SanitizePhoneNumber());
        }

        private void DialNumber()
        {
            if (string.IsNullOrWhiteSpace(Restaurant.Phone))
                return;


            var phoneCallTask = MessagingPlugin.PhoneDialer;

            if (phoneCallTask.CanMakePhoneCall)
                phoneCallTask.MakePhoneCall(Restaurant.Phone.SanitizePhoneNumber());
        }

        public void SendEmail()
        {
            var emailTask = MessagingPlugin.EmailMessenger;

            if (emailTask.CanSendEmail)
                emailTask.SendEmail(Restaurant.Email);
        }

        public void NavigateTo()
        {
            var address = Restaurant.AddressString;

            switch (Device.OS)
            {
                case TargetPlatform.iOS:
                    Device.OpenUri(
                        new Uri(string.Format("http://maps.apple.com/?q={0}", WebUtility.UrlEncode(address))));
                    break;
                case TargetPlatform.Android:
                    Device.OpenUri(
                        new Uri(string.Format("geo:0,0?q={0}", WebUtility.UrlEncode(address))));
                    break;
                case TargetPlatform.Windows:
                case TargetPlatform.WinPhone:
                    Device.OpenUri(
                        new Uri(string.Format("bingmaps:?where={0}", Uri.EscapeDataString(address))));
                    break;
            }
        }
    }
}