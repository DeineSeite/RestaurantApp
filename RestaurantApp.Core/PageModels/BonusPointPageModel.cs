using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.Content.Res;
using RestaurantApp.Core.Services;
using Xamarin.Forms;

namespace RestaurantApp.Core.PageModels
{
  public class BonusPointPageModel: BasePageModel
    {
        public Command StartScanCommand { get; set; }

      public BonusPointPageModel()
      {
            StartScanCommand = new Command(ScanQrCode);
        }
        private void ScanQrCode()
      {
            QrCodeScannerService qrService = new QrCodeScannerService(CurrentPage);
            qrService.StartScan();
            qrService.OnResultReady += QrService_OnResultReady; ;
        }

        private void QrService_OnResultReady(ZXing.Result result)
        {
            // Pop the page and show the result
            Device.BeginInvokeOnMainThread(async () =>
            {
                await CurrentPage.Navigation.PopAsync();
                await CurrentPage.DisplayAlert("Scanned Barcode", result.Text, "OK");
            });
        }
    }
}
