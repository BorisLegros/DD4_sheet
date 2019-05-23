using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DD4_Sheet.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddXpPopup : PopupPage
	{
        private bool isCancel = false;

		public AddXpPopup ()
		{
			InitializeComponent ();
		}

        private void Ok_Clicked(object sender, EventArgs e)
        {
            Navigation.PopPopupAsync();
        }

        private void Cancel_Clicked(object sender, EventArgs e)
        {
            isCancel = true;
            Navigation.PopPopupAsync();
        }

        protected override void OnAppearing()
        {
            isCancel = false;

            base.OnAppearing();
        }
        protected override void OnDisappearing()
        {
            if (isCancel == false)
            {
                string s = (this.entry_xpPlus as Entry).Text;
                if (!String.IsNullOrEmpty(s))
                {
                    App.MAIN.Xp += Int32.Parse(s);
                    App.save();
                    Debug.WriteLine(App.MAIN.Xp);
                }
            }

            base.OnDisappearing();
        }
    }
}