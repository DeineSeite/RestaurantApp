﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantApp.Localization;
using Xamarin.Forms;

namespace RestaurantApp.Pages
{
    public partial class InfoPage : ContentPage
    {
        public InfoPage()
        {
            InitializeComponent();
            Title = AppResources.Info;
        }
    }
}
