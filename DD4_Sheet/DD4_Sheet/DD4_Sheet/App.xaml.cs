using DD4_Sheet.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace DD4_Sheet
{
    public partial class App : Application
    {

        public static Caractere MAIN;
        public string toto { get; set; }

        public static string XMLkey = "XmlSave";

        public App()
        {
            if (Application.Current.Properties.ContainsKey(App.XMLkey))
            {
                MAIN = Caractere.LoadFromXML(Current.Properties[App.XMLkey] as string);
            }
            else
            {
                MAIN = new Caractere();
            }
            

            this.toto = "TOTO";

            InitializeComponent();
            
            MainPage = new NavigationPage (new MainPage());
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
