using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.Content.Res;
using Android.Views.Accessibility;
using Xamarin.Forms;
using ZXing.Mobile;
using ZXing.Net.Mobile.Forms;

namespace RestaurantApp.Core.Services
{
  public class QrCodeScannerService
  {
      private Page _contentPage;
      private ZXingScannerPage _scannerPage;
      public QrCodeScannerService(Page page)
      {
          _contentPage = page;
      }
      public event ZXingScannerPage.ScanResultDelegate OnResultReady;
      public async void StartScan()
      {
            //setup options
            var options = new MobileBarcodeScanningOptions
            {
                AutoRotate = false,
                UseFrontCameraIfAvailable = false,
                UseNativeScanning = true,

                TryHarder = true,
                PossibleFormats = new List<ZXing.BarcodeFormat>
                {
                    ZXing.BarcodeFormat.QR_CODE
                }
            };
            _scannerPage = new ZXingScannerPage(options);

            // Navigate to our scanner page
            await _contentPage.Navigation.PushAsync(_scannerPage);
            _scannerPage.OnScanResult += OnResultReady;
            _scannerPage.OnScanResult += ScanPage_OnScanResult;
      }

        private void ScanPage_OnScanResult(ZXing.Result result)
        {
            _scannerPage.IsScanning = false;
        }
    }
}
