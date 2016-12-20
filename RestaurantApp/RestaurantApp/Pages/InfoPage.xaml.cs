﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestaurantApp.Core.Localization;
using Xamarin.Forms;

namespace RestaurantApp.Pages
{
    public partial class InfoPage : BasePage
    {
        public InfoPage()
        {
            InitializeComponent();
            Title = AppResources.Info;
        }
    }
}
