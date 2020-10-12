using DD4_Sheet;
using DD4_Sheet.View;
using Rg.Plugins.Popup.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DD4_Sheet
{
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            InitializeComponent();
            BindingContext = App.MAIN;  
        }

        void FrameDescription_tapped(object sender, EventArgs e)
        {
            Debug.WriteLine("click !");
            Navigation.PushAsync(new CaracterePage());
        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {
        }

        private void btn_xp_Clicked(object sender, EventArgs e)
        {
            Navigation.PushPopupAsync(new AddXpPopup());
        }

        private void Carac_clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new FeatureAndSkillPage());
            //Navigation.PushAsync(new Page1());
        }
    }
}
