using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace DRS
{
    public partial class DoctorSearch : ContentPage
    {
        public DoctorSearch()
        {
            InitializeComponent();
            DoctorLogic obj = new DoctorLogic();
            obj.Cell1 = "Dr.Ahmed";
            obj.Cell2 = "Dr.Faisal";
            obj.Cell3 = "Dr.sultan";
            obj.Cell4 = "Dr.Mubark";
            obj.Cell5 = "Dr.Saud";
            obj.Cell6 = "Dr.muhammad";
            obj.Cell7 = "Dr.mansoor";
            this.BindingContext = obj;
        }
        void Next(object sender, EventArgs args)
        {

            Navigation.PushAsync(new WelcomePage());
        }

      
    }
}
