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
    /// <summary>
    /// 1. Set current Page into constructor
    /// 2.<seealso cref="StartScan()"/>
    /// 3.Get result from event <seealso cref="OnResultReady"/> 
    /// </summary>
    public class QrCodeScannerService
    {
        #region Public properties
        /// <summary>
        /// Occurs when code is scanned
        /// </summary>
        public event EventHandler<string> OnResultReady;
        public MobileBarcodeScanningOptions Options { get; set; }
        #endregion

        #region ctor
        public QrCodeScannerService(Page page)
        {
            _contentPage = page;
            //setup options
            Options = new MobileBarcodeScanningOptions
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
            _scannerPage = new ZXingScannerPage(Options);
            NavigationPage.SetHasNavigationBar(_scannerPage,false);
        }
        #endregion

        #region Private/Public members
        public async void StartScan()
        {
            // Navigate to our scanner page
            await _contentPage.Navigation.PushAsync(_scannerPage);
            _scannerPage.OnScanResult += ScanPage_OnScanResult;
        }

        private void ScanPage_OnScanResult(ZXing.Result result)
        {
            _scannerPage.IsScanning = false;
            Device.BeginInvokeOnMainThread(async () =>
            {
                await _contentPage.Navigation.PopAsync();
            });

            //fire result Event
            if (OnResultReady != null)
                OnResultReady(this, result.Text);
           
        }
        #endregion

        #region Private properties
        private Page _contentPage;
        private ZXingScannerPage _scannerPage;
        #endregion
    }
}
