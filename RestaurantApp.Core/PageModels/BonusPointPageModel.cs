using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.Content.Res;
using FreshMvvm;
using RestaurantApp.Core.Interfaces;
using RestaurantApp.Core.Services;
using RestaurantApp.Data.Models;
using Xamarin.Forms;


namespace RestaurantApp.Core.PageModels
{
    public class BonusPointPageModel : BasePageModel
    {

        #region Public properties
        public  ObservableCollection<BonusPointModel> BonusPointList { get; set; } 
        #endregion

        public BonusPointPageModel()
        {
            StartScanCommand = new Command(ScanQrCode);
            ItemTappedCommand=new Command<BonusPointModel>(ItemTapped);
            BonusPointList=new ObservableCollection<BonusPointModel>();
            for (int i = 0; i < 10; i++)
            {
                BonusPointList.Add(new BonusPointModel() {Id =i,IsActivated = i<5});
            }
            _currenBonusPointModel=new BonusPointModel();
         
          
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
            QrCodeScannerService qrService = new QrCodeScannerService(CurrentPage);
            qrService.StartScan();
            qrService.OnResultReady += QrService_OnResultReady; ;
        }

        private void QrService_OnResultReady(object sender, string result)
        {
            int index = BonusPointList.IndexOf(_currenBonusPointModel);
            _currenBonusPointModel.Description = result;
            _currenBonusPointModel.ActivationDate=DateTime.Now;
            _currenBonusPointModel.IsActivated = true;
            BonusPointList[index] = _currenBonusPointModel;
            BonusPointList[index+1] = _currenBonusPointModel;
            BonusPointList[index+2] = _currenBonusPointModel;

        }

      

        private BonusPointModel _currenBonusPointModel;

        #region Commands
        public Command StartScanCommand { get; set; }
        public Command<BonusPointModel> ItemTappedCommand { get; set; }
        #endregion
    }
}
