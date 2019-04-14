using DD4_Sheet.Models;
using DD4_Sheet.View;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DD4_Sheet
{
    public partial class MainPage : ContentPage
    {
        public string toto { get; set; } = "toto";
        public MainPage()
        {
            InitializeComponent();
        }

        void FrameDescription_tapped(object sender, EventArgs e)
        {
            Debug.WriteLine("click !");
            Navigation.PushAsync(new CaracterePage ()); 
        }

        private void ImageButton_Clicked(object sender, EventArgs e)
        {
            Application.Current.Properties["name"] = App.MAIN.Name;
        }
    }
}
