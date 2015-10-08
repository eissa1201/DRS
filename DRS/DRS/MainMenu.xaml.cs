using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace DRS
{
    public partial class MainMenu : ContentPage
    {
        public MainMenu()
        {
            InitializeComponent();
        }
        void Next(object sender, EventArgs args)
        {

            Navigation.PushAsync(new CitySearch());
        }
        void settings(object sender, EventArgs args)
        {

            Navigation.PushAsync(new SettingsPage());
        }
    }
}
