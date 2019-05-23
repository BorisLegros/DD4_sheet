using DD4_Sheet.Models;
using Rg.Plugins.Popup.Extensions;
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
	public partial class FeatureAndSkillPage : ContentPage
	{
		public FeatureAndSkillPage ()
		{
			InitializeComponent ();
            //BindingContext = App.MAIN;
		}
        
        protected override void OnAppearing()
        {
            // PEUT MIEUX FAIRE AVEC DU BINDING //
            // ??? Text={Binding App.MAIN.Strenght.Value}" ??? //
            int i = 0;
            foreach(Feature f in App.MAIN.Features)
            {

                Button b = new Button { Text = f.Name, FontSize = 10, };
                b.AutomationId = f.Name;
                b.Clicked += Feature_Clicked;
                this.grid_Features.Children.Add(b, 0, i);
                this.grid_Features.Children.Add(new Label { Text = f.Value.ToString() }, 1, i);
                this.grid_Features.Children.Add(new Label { Text = f.BaseValue.ToString() }, 2, i);
                this.grid_Features.Children.Add(new Label { Text = f.Modificateur.ToString() }, 3, i);
                this.grid_Features.Children.Add(new Label { Text = f.BonusRace.ToString() }, 4, i);
                this.grid_Features.Children.Add(new Label { Text = f.ToStringAmends() }, 5, i);

                i++;
            }

            base.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            App.save();
            base.OnDisappearing();
        }

        private void Feature_Clicked(object sender, EventArgs e)
        { 
            Navigation.PushPopupAsync(new FeaturePopup((sender as Button).AutomationId));
        }
    }
}