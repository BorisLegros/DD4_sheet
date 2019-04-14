﻿using System;
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
	public partial class CaracterePage : ContentPage
	{
		public CaracterePage ()
		{
			InitializeComponent ();
            BindingContext = App.MAIN;
		}

        private void Name_Unfocused(object sender, FocusEventArgs e)
        {
            App.MAIN.Name = (sender as Entry).Text;
            Debug.WriteLine(App.MAIN.Name);
        }
    }
}