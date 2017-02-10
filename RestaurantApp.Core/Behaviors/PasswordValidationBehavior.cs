using System.Text.RegularExpressions;
using Xamarin.Forms;

namespace RestaurantApp.Core.Behaviors
{
    public class PasswordValidationBehavior : Behavior<Entry>
    {
        private const string emailRegex =
           @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
           @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";

        private static readonly BindablePropertyKey IsValidPropertyKey = BindableProperty.CreateReadOnly("IsValid",
            typeof(bool), typeof(PasswordValidationBehavior), false);

        public static readonly BindableProperty IsValidProperty = IsValidPropertyKey.BindableProperty;

        public bool IsValid
        {
            get { return (bool)GetValue(IsValidProperty); }
            private set { SetValue(IsValidPropertyKey, value); }
        }



        private const string passwordRegex = @"^(?=.*[A-Za-z])(?=.*\d)(?=.*[$@$!%*#?&])[A-Za-z\d$@$!%*#?&]{8,}$";


        protected override void OnAttachedTo(Entry bindable)
        {
            bindable.TextChanged += HandleTextChanged;
            base.OnAttachedTo(bindable);
        }


        private void HandleTextChanged(object sender, TextChangedEventArgs e)
        {
            IsValid = Regex.IsMatch(e.NewTextValue, passwordRegex);
            ((Entry) sender).TextColor = IsValid ? Color.Default : Color.Red;
        }


        protected override void OnDetachingFrom(Entry bindable)
        {
            bindable.TextChanged -= HandleTextChanged;
            base.OnDetachingFrom(bindable);
        }
    }
}