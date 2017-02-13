using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using FreshMvvm;
using PropertyChanged;
using QrCodeScanner;
using RestaurantApp.Core.Interfaces;
using RestaurantApp.Core.Services;
using RestaurantApp.Data.Access;
using RestaurantApp.Data.Models;
using Xamarin.Forms;

namespace RestaurantApp.Core.ViewModels
{
    [ImplementPropertyChanged]
    public class BonusPointViewModel : BaseViewModel
    {
        private BonusPointModel _currenBonusPointModel;

        public BonusPointViewModel()
        {
            StartScanCommand = new Command(ScanQrCode);
            ItemTappedCommand = new Command<BonusPointModel>(ItemTapped);
            BonusPointList = new BonusPointCollection();
            
            
        }

        #region Public properties

        public BonusPointCollection BonusPointList { get; set; }

        #endregion

       

        private void ItemTapped(BonusPointModel bonusPoint)
        {
            if (!bonusPoint.IsActivated)
            {
                _currenBonusPointModel = bonusPoint;
                ScanQrCode();
            }
            else
            {
               ShowPopupInfo(bonusPoint);
            }
        }

        private void ShowPopupInfo(BonusPointModel bonusPoint)
        {
            UserInteractionService.DisplayAlert(null, bonusPoint.Description);
        }

        private void ScanQrCode()
        {
            var mainPage = FreshIOC.Container.Resolve<IApplicationContext>().BasicNavContainer.CurrentPage;
            var qrService = new QrCodeScannerService(mainPage);
            qrService.ScanPageTitle = "QR code scanner";
            qrService.StartScan();
            qrService.OnResultReady += QrService_OnResultReady;
        }

        private void QrService_OnResultReady(object sender, string result)
        {
            var index = BonusPointList.IndexOf(_currenBonusPointModel);
            _currenBonusPointModel.ActivationDate = DateTime.Now;
            _currenBonusPointModel.Description = result;
            _currenBonusPointModel.IsActivated = true;
            _currenBonusPointModel.IsLastInList = false;

            if (BonusPointList.ElementAt(index + 1) != null)
                BonusPointList[index + 1].IsLastInList = true;
        }

        #region Commands

        public Command StartScanCommand { get; set; }
        public Command<BonusPointModel> ItemTappedCommand { get; set; }

        #endregion
    }

    public class BonusPointCollection : ObservableCollection<BonusPointModel>
    {
        private int BonusPointCount = 10;
        private IRestaurantDataAccess _dataAccess;
        private int _position = 0;
        public BonusPointCollection()
        {
            _dataAccess = FreshIOC.Container.Resolve<IRestaurantDataAccess>();
            InitEmptyPlaces();
        }

        private void InitEmptyPlaces()
        {
            for (int i = 0; i < 10; i++)
            {
                base.Add(new BonusPointModel());
            }
            Items[0].IsLastInList = true;
        }

       
        new void Add(BonusPointModel bonusPoint)
        {
            _dataAccess.AddNewBonusPoint(bonusPoint);
            Items[_position] = bonusPoint;
            _position++;
        }

        //TODO
        new void Remove(BonusPointModel bonusPoint)
        {
            throw  new NotImplementedException("Not implenet yet");
        }

        //TODO
        public void SyncWithServer()
        {
            throw  new NotImplementedException("Not implenet yet");
        }

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