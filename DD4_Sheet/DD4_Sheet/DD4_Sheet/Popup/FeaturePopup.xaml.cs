using DD4_Sheet.Models;
using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DD4_Sheet.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class FeaturePopup : PopupPage
    {
		public FeaturePopup (string fName)
		{
			InitializeComponent ();
            /*BindingContext = App.MAIN.Features[fName];

            // modifications personels
            foreach (Amend a in App.MAIN.Features[fName].Amends)
            {
                if (a.IsModifiable)
                {
                    var sth = new StackLayout { Orientation = StackOrientation.Horizontal };
                    sth.Children.Add(new Entry { Text = a.Value.ToString(), Keyboard = Keyboard.Numeric });
                    sth.Children.Add(new Entry { Text = a.Reason });

                    this.sl_amends_perso.Children.Add(sth);
                }
            }*/
		}
	}
}