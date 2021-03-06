﻿using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
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

        public override void Init(object data)
        {
            base.Init(data);
            BonusPointsList.FillFromDatabase((BonusPointType)Params);
        }

        public BonusPointViewModel()
        {
            StartScanCommand = new Command(ScanQrCode);
            ItemTappedCommand = new Command<BonusPointModel>(ItemTapped);
            FakeBonusCommand = new Command(FakeBonusPoint);

            BonusPointsList = new BonusPointCollection();
           

            InitScanPage();
        }

        #endregion

        #region Public properties

        public BonusPointCollection BonusPointsList { get; set; }

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
                ShowPopupInfo(null, bonusPoint);
            }
        }

        private void ShowPopupInfo(string title, BonusPointModel bonusPoint)
        {
            DisplayService.DisplayAlert(title, bonusPoint.Description);
        }

        private async void InitScanPage()
        {
            await Task.Run(() =>
            {
                var mainPage = FreshIOC.Container.Resolve<IMainPageModel>().CurrentPage;
                _qrCodeService = new QrCodeScannerService(mainPage) {ScanPageTitle = "QR code scanner"};
                _qrCodeService.OnResultReady += QrService_OnResultReady;
            });
        }

        private void ScanQrCode()
        {
            _qrCodeService.StartScan();
        }

        private void QrService_OnResultReady(object sender, string result)
        {
            var index = BonusPointsList.IndexOf(_currenBonusPointModel);
            _currenBonusPointModel.ActivationDate = DateTime.Now;
            _currenBonusPointModel.Description = result;
            _currenBonusPointModel.Hash = _currenBonusPointModel.GetHashCode().ToString();
            _currenBonusPointModel.IsActivated = true;
            _currenBonusPointModel.IsLastInList = false;
            BonusPointsList.SyncItemWithServer(_currenBonusPointModel);

            //Move the Plus button into next cell
            if (BonusPointsList.ElementAt(index + 1) != null)
                BonusPointsList[index + 1].IsLastInList = true;

            //Alert user
            ShowPopupInfo("Scanned", _currenBonusPointModel);
        }

        private void FakeBonusPoint()
        {
            _currenBonusPointModel = BonusPointsList.FirstOrDefault(x => x.IsLastInList);
            QrService_OnResultReady(null, "Fake Bonus");
        }

        #region Commands

        public Command StartScanCommand { get; set; }
        public Command<BonusPointModel> ItemTappedCommand { get; set; }
        public Command FakeBonusCommand { get; set; }

        #endregion
    }

    public class BonusPointCollection : ObservableCollection<BonusPointModel>
    {
        private readonly int BonusPointCount = 10;

        public BonusPointCollection()
        {
            InitEmptyPlaces();
        }

        private IBonusPointService _bonusPointService => FreshIOC.Container.Resolve<IBonusPointService>();
        private IRestaurantDataAccess _dataAccess => FreshIOC.Container.Resolve<IRestaurantDataAccess>();

        private void InitEmptyPlaces()
        {
            for (var i = 0; i < BonusPointCount; i++)
                Add(new BonusPointModel());
            Items[0].IsLastInList = true;
        }

        public void SyncItemWithServer(BonusPointModel bonusPoint)
        {
            try
            {
                _dataAccess.AddNewBonusPoint(bonusPoint);
                _bonusPointService.SyncBonusPointCollection(Items.Where(x => x.IsActivated).ToList());
            }
            catch (HttpRequestException e)
            {
                DisplayService.DisplayAlert("Sync error: ", e.Message);
            }
            catch (Exception e)
            {
                DisplayService.DisplayAlert("Error: ", e.Message);
            }
        }

        public void FillFromDatabase(BonusPointType type)
        {
            var bonusPoints =
                _dataAccess.GetAllBonusPoints(type)
                    .OrderByDescending(x => x.ActivationDate)
                    .Take(Items.Count)
                    .Reverse()
                    .ToList();

            for (var i = 0; i < bonusPoints.Count; i++)
                Items[i] = bonusPoints[i];

            //Set last item as ScanButton
            if (bonusPoints.Count < Items.Count)
                Items[bonusPoints.Count].IsLastInList = true;
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