using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreshMvvm;
using PropertyChanged;
using QrCodeScanner;
using RestaurantApp.Core.Interfaces;
using RestaurantApp.Data.Models;
using Xamarin.Forms;

namespace RestaurantApp.Core.ViewModels
{
    [ImplementPropertyChanged]
  public  class BonusPointViewModel:BaseViewModel
    {
        #region Public properties
        public ObservableCollection<BonusPointModel> BonusPointList { get; set; }
        #endregion

        public BonusPointViewModel()
        {
            StartScanCommand = new Command(ScanQrCode);
            ItemTappedCommand = new Command<BonusPointModel>(ItemTapped);
            BonusPointList = new ObservableCollection<BonusPointModel>();
            for (int i = 0; i < 10; i++)
            {
                BonusPointList.Add(new BonusPointModel() { Id = i, IsActivated = i < 5 });
            }
            


        }
        private void ItemTapped(BonusPointModel pointModel)
        {
            if (!pointModel.IsActivated)
            {
                _currenBonusPointModel = pointModel;
                ScanQrCode();
            }
        }
        private void ScanQrCode()
        {
            var mainPage = FreshIOC.Container.Resolve<IApplicationContext>().BasicNavContainer.CurrentPage;
            QrCodeScannerService qrService = new QrCodeScannerService(mainPage);
            qrService.StartScan();
            qrService.OnResultReady += QrService_OnResultReady; ;
        }

        private void QrService_OnResultReady(object sender, string result)
        {
            int index = BonusPointList.IndexOf(_currenBonusPointModel);
            _currenBonusPointModel.Description = result;
            _currenBonusPointModel.ActivationDate = DateTime.Now;
            _currenBonusPointModel.IsActivated = true;
            BonusPointList[index] = _currenBonusPointModel;
         

        }



        private BonusPointModel _currenBonusPointModel;

        #region Commands
        public Command StartScanCommand { get; set; }
        public Command<BonusPointModel> ItemTappedCommand { get; set; }
        #endregion
    }
}
