using System;
using Xamarin.Forms;

namespace RestaurantApp.UserControls
{
    public interface ICanBeValidated
    {
        Color BorderColor { get; set; }

        double BorderWidth { get; set; }

        double BorderRadius { get; set; }
    }

    public class CustomDatePicker : DatePicker, ICanBeValidated
    {
        public static readonly BindableProperty BorderWidthProperty = BindableProperty.Create(
            "BorderWidth",
            typeof(double),
            typeof(CustomDatePicker),
            0.0);

        public static readonly BindableProperty BorderColorProperty = BindableProperty.Create(
            "BorderColor",
            typeof(Color),
            typeof(CustomDatePicker),
            Color.Transparent);

        public static readonly BindableProperty BorderRadiusProperty = BindableProperty.Create(
            "BorderRadius",
            typeof(double),
            typeof(CustomDatePicker),
            0.0);

        public static readonly BindableProperty PlaceHolderProperty = BindableProperty.Create(
            "PlaceHolder",
            typeof(string),
            typeof(CustomDatePicker),
            "");

        public static readonly BindableProperty MinimumAgeProperty = BindableProperty.Create(
            "MinimumAge",
            typeof(int),
            typeof(CustomDatePicker),
            18);

        public CustomDatePicker()
        {
            // It seems that all the picker need to validated
            IsValidated = false;
            BorderColor = Color.Transparent;
            DateSelected += CustomDatePicker_DateSelected;
        }

        public string PlaceHolder
        {
            get { return (string) GetValue(PlaceHolderProperty); }
            set { SetValue(PlaceHolderProperty, value); }
        }

        public int MinimumAge
        {
            get { return (int) GetValue(MinimumAgeProperty); }
            set { SetValue(MinimumAgeProperty, value); }
        }

        public Action<bool> ValidateChange { get; set; }

        public bool IsValidated { get; set; }

        public double BorderWidth
        {
            get { return (double) GetValue(BorderWidthProperty); }
            set { SetValue(BorderWidthProperty, value); }
        }

        public Color BorderColor
        {
            get { return (Color) GetValue(BorderColorProperty); }
            set { SetValue(BorderColorProperty, value); }
        }

        public double BorderRadius
        {
            get { return (double) GetValue(BorderRadiusProperty); }
            set { SetValue(BorderRadiusProperty, value); }
        }

        private void CustomDatePicker_DateSelected(object sender, DateChangedEventArgs e)
        {
            if (e.NewDate.Date != DateTime.Now.Date && e.NewDate.Year < DateTime.Now.Year - MinimumAge)
            {
                IsValidated = true;
                if (ValidateChange != null)
                    ValidateChange(true);
                BorderColor = Color.Transparent;
            }
            else
            {
                IsValidated = false;
                if (ValidateChange != null)
                    ValidateChange(false);
                BorderColor = Color.Transparent;
            }
        }
    }
}