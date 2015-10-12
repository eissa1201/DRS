using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace DRS
{
    public partial class CitySearch : ContentPage
    {
        public CitySearch(List<string> Cities)
        {
            InitializeComponent();
            listView.ItemsSource = Cities;


            listView.ItemSelected += (sender, e) =>
            {
                lol(e.SelectedItem.ToString());
            };

        }

        void lol(string CityName)
        {

            Application.Current.Properties["City"] = CityName; 

         Navigation.PopAsync();


        }
    }
}
