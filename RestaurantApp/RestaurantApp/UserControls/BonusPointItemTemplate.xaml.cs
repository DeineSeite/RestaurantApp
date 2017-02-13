using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamanimation;
using Xamarin.Forms;

namespace RestaurantApp.UserControls
{
    public partial class BonusPointItemTemplate : ContentView
    {
       
        public BonusPointItemTemplate()
        {
            InitializeComponent();
            PulsButtonAnimation();
        }

        private async void PulsButtonAnimation()
        {
            while (true)
            {
                await ScannImage.Animate(new ScaleToAnimation() {Scale = 1.3, Duration = "700"});
                await ScannImage.Animate(new ScaleToAnimation() { Scale = 1, Duration = "700" });
            }
        }

        public Image ScannImageButton
        {
            get { return ScannImage; }
            set { ScannImage = value; }
        }
    }
}
