using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
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
    public class BonusPointViewModel : BaseViewModel
    {
        #region Public properties

        public BonusPointCollection BonusPointList { get; set; }

        #endregion

        public BonusPointViewModel()
        {
            StartScanCommand = new Command(ScanQrCode);
            ItemTappedCommand = new Command<BonusPointModel>(ItemTapped);
            BonusPointList = new BonusPointCollection();
            for (int i = 0; i < 10; i++)
            {
                BonusPointList.Add(new BonusPointModel() {Id = i, IsActivated = i < 8, IsLastInList =i==8});

            }
            BonusPointList.CollectionChanged += BonusPointList_CollectionChanged;

        }

        private void BonusPointList_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            var s = sender;
        }

        private void ItemTapped(BonusPointModel pointModel)
        {
            if (!pointModel.IsActivated&&pointModel.IsLastInList)
            {
                _currenBonusPointModel = pointModel;
                ScanQrCode();
            }
        }

        private void ScanQrCode()
        {
            var mainPage = FreshIOC.Container.Resolve<IApplicationContext>().BasicNavContainer.CurrentPage;
            QrCodeScannerService qrService = new QrCodeScannerService(mainPage);
            qrService.ScanPageTitle = "QR code scanner";
            qrService.StartScan();
            qrService.OnResultReady += QrService_OnResultReady;
            
        }

        private void QrService_OnResultReady(object sender, string result)
        {
            int index = BonusPointList.IndexOf(_currenBonusPointModel);
            _currenBonusPointModel.Description = result;
            _currenBonusPointModel.ActivationDate = DateTime.Now;
            _currenBonusPointModel.IsActivated = true;
            _currenBonusPointModel.IsLastInList = false;
            BonusPointList[index] = _currenBonusPointModel;
            if (index < BonusPointList.Count)
            {
                BonusPointList[index + 1].IsLastInList = true;
            }
            
        }




        private BonusPointModel _currenBonusPointModel;

        #region Commands

        public Command StartScanCommand { get; set; }
        public Command<BonusPointModel> ItemTappedCommand { get; set; }

        #endregion
    }

    public class BonusPointCollection : ObservableCollection<BonusPointModel>
    {
       
        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            base.OnCollectionChanged(e);
        }

        protected override void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            base.OnPropertyChanged(e);
        }
    }

}
