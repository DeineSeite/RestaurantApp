using Xamarin.Forms;

namespace RestaurantApp.Core.Behaviors
{
    public class NumberValidationBehavior : Behavior<Entry>
    {
        private static readonly BindablePropertyKey IsValidPropertyKey = BindableProperty.CreateReadOnly("IsValid",
            typeof(bool), typeof(NumberValidationBehavior), false);

        public static readonly BindableProperty IsValidProperty = IsValidPropertyKey.BindableProperty;

        public bool IsValid
        {
            get { return (bool) GetValue(IsValidProperty); }
            private set { SetValue(IsValidPropertyKey, value); }
        }

        protected override void OnAttachedTo(Entry entry)
        {
            entry.TextChanged += OnEntryTextChanged;
            base.OnAttachedTo(entry);
        }


        protected override void OnDetachingFrom(Entry entry)
        {
            entry.TextChanged -= OnEntryTextChanged;
            base.OnDetachingFrom(entry);
        }


        private void OnEntryTextChanged(object sender, TextChangedEventArgs args)
        {
            int result;
            IsValid = int.TryParse(args.NewTextValue, out result);
            ((Entry) sender).TextColor = IsValid ? Color.Default : Color.Red;
        }
    }
}