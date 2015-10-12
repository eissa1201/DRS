using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace DRS
{
    public partial class SpecialtySearch : ContentPage
    {
        public SpecialtySearch(List<string> Specialties)
        {
            InitializeComponent();
            listView.ItemsSource = Specialties;


            listView.ItemSelected += (sender, e) =>
            {
                lol(e.SelectedItem.ToString());
            };

        }

        void lol(string SpecialtyName)
        {

            Application.Current.Properties["Specialty"] = SpecialtyName;

            Navigation.PopAsync();


        }
    }
}
