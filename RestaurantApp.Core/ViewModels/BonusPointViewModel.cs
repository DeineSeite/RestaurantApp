using System;
using System.Collections.Generic;
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
        private QrCodeScannerService _qrCodeService;
        

        #region ctor

        public BonusPointViewModel()
        {
            StartScanCommand = new Command(ScanQrCode);
            ItemTappedCommand = new Command<BonusPointModel>(ItemTapped);
            BonusPointList = new BonusPointCollection();
            BonusPointList.FillFromDatabase(BonusPointType.Dinner);
            InitScanPage();
        }

        #endregion

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

        private void InitScanPage()
        {
            var mainPage = FreshIOC.Container.Resolve<IApplicationContext>().BasicNavContainer.CurrentPage;
            _qrCodeService = new QrCodeScannerService(mainPage) {ScanPageTitle = "QR code scanner"};
            _qrCodeService.OnResultReady += QrService_OnResultReady;
        }

        private void ScanQrCode()
        {
            _qrCodeService.StartScan();
        }

        private void QrService_OnResultReady(object sender, string result)
        {
            var index = BonusPointList.IndexOf(_currenBonusPointModel);
            _currenBonusPointModel.ActivationDate = DateTime.Now;
            _currenBonusPointModel.Description = $"Activation Date:{DateTime.Now:yy-mm-dd} \n {result}";
            _currenBonusPointModel.IsActivated = true;
            _currenBonusPointModel.IsLastInList = false;
            BonusPointList.SyncItemWithServer(_currenBonusPointModel);

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
        private readonly IRestaurantDataAccess _dataAccess;
        private BonusPointService _bonusPointService;
        private int BonusPointCount = 10;

        public BonusPointCollection(IEnumerable<BonusPointModel> collection):base(collection)
        {
            
        }
        public BonusPointCollection()
        {
            _dataAccess = FreshIOC.Container.Resolve<IRestaurantDataAccess>();
            _bonusPointService = new BonusPointService();
            InitEmptyPlaces();
        }

        private void InitEmptyPlaces()
        {
            for (var i = 0; i < BonusPointCount; i++)
                Add(new BonusPointModel());
            Items[0].IsLastInList = true;
        }

        public void SyncItemWithServer(BonusPointModel bonusPoint)
        {
            _dataAccess.AddNewBonusPoint(bonusPoint);
            _bonusPointService.SyncBonusPointCollection(Items.Where(x=>x.IsActivated).ToList());
        }

        public void FillFromDatabase(BonusPointType type)
        {
            var bonusPoints =
                _dataAccess.GetAllBonusPoints(type).OrderByDescending(x => x).Take(Items.Count).Reverse().ToList();

            for (var i = 0; i < bonusPoints.Count; i++)
                Items[i] = bonusPoints[i];

            //Set last item as ScanButton
            if (bonusPoints.Count < Items.Count)
                Items[bonusPoints.Count].IsLastInList=true;
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