using DD4_Sheet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DD4_Sheet.View
{
    public class FeatureToViewCell //: ViewCell
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public string Mod { get; set; }
        public string Base { get; set; }
        public string Race { get; set; }
        public string Lvl { get; set; }
        public string Amends { get; set; }

        public FeatureToViewCell (Feature f)
        {
            Name = f.Name;
            Value = f.Value.ToString();
            Mod = f.Modificateur.ToString();
            Base = f.BaseValue.ToString();
            Race = f.BonusRace.ToString();
            Lvl = "";
            Amends = "";
            foreach (Amend a in f.Amends)
            {
                string signe = (a.Value > 0) ? "+" : "";
                if (a.Reason == "Niveau")
                {
                    Lvl += signe + " : " + a.Reason + '\n';
                }
                else
                {
                    Amends += signe + " : " + a.Reason + '\n';
                }
            }
        }
}

	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Page1 : ContentPage
	{
		public Page1 ()
		{
			InitializeComponent ();

            List<FeatureToViewCell> featuresView = new List<FeatureToViewCell>();
            foreach (Feature f in App.MAIN.Features)
            {
                featuresView.Add(new FeatureToViewCell(f));
            }

            
            this.lv1.ItemsSource = featuresView;
        }
	}
}