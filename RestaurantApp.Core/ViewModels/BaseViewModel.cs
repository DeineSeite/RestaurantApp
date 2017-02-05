using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using RestaurantApp.Core.Annotations;
using RestaurantApp.Core.Interfaces;
using Xamarin.Forms;

namespace RestaurantApp.Core.ViewModels
{
  public abstract class BaseViewModel:INotifyPropertyChanged
    {
        public IBaseContentView CurrentContentView { get; set; }

        public void Init(object data)
        {
            
        }







        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
