using Xamarin.Forms;

namespace RestaurantApp.UserControls
{
    public class CustomTimePicker : TimePicker, ICanBeValidated
    {
        public static readonly BindableProperty BorderWidthProperty = BindableProperty.Create(
            "BorderWidth",
            typeof(double),
            typeof(CustomTimePicker),
            0.0);

        public static readonly BindableProperty BorderColorProperty = BindableProperty.Create(
            "BorderColor",
            typeof(Color),
            typeof(CustomTimePicker),
            Color.Transparent);

        public static readonly BindableProperty BorderRadiusProperty = BindableProperty.Create(
            "BorderRadius",
            typeof(double),
            typeof(CustomTimePicker),
            0.0);

        public static readonly BindableProperty PlaceHolderProperty = BindableProperty.Create(
            "PlaceHolder",
            typeof(string),
            typeof(CustomTimePicker),
            "");

        public static readonly BindableProperty MinimumAgeProperty = BindableProperty.Create(
            "MinimumAge",
            typeof(int),
            typeof(CustomTimePicker),
            18);

        public CustomTimePicker()
        {
            BorderColor = Color.Transparent;
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
    }
}