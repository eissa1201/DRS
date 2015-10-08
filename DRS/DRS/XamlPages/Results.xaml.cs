using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace DRS
{
    public partial class Results : ContentPage
    {
        public Results(List<string> D, String Userx)
        {
            InitializeComponent();
            listView.ItemsSource = D;


            listView.ItemSelected += (sender, e) =>
            {
                lol(e.SelectedItem.ToString(), Userx);
            };

        }

        void lol(string DoctorsName, string User)
        {



            Navigation.PushAsync(new DoctorRating(DoctorsName, User));


        }
    }
}
