﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace RestaurantApp.UserControls
{
    public partial class MenuItemCellTemplate : ContentView
    {
        public BoxView BackgroundBox
        {
            get { return BackgroundBoxView; }
            set { BackgroundBoxView = value; }
        }

        public MenuItemCellTemplate()
        {
            InitializeComponent();
        }
    }
}
