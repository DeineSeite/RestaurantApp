﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FreshMvvm;

namespace RestaurantApp.Core.Interfaces
{
    public interface IApplicationContext
    {
        FreshNavigationContainer BasicNavContainer { get; set; }
        void ChangeCurrentCultureInfo(string langCode);
        CultureInfo CurrentCulture { get; set; }
    }
}
