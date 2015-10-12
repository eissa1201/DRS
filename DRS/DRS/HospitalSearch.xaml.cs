using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace DRS
{
    public partial class HospitalSearch : ContentPage
    {
        public HospitalSearch(List<string> Hospitals)
        {
            InitializeComponent();
            listView.ItemsSource = Hospitals;


            listView.ItemSelected += (sender, e) =>
            {
                lol(e.SelectedItem.ToString());
            };

        }

        void lol(string HospitalName)
        {

            Application.Current.Properties["Hospital"] = HospitalName;

            Navigation.PopAsync();


        }
    }
}
