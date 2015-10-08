using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace DRS
{
    public partial class SpecialitySearch : ContentPage
    {
        public SpecialitySearch()
        {
            InitializeComponent();
            specialityLogic obj = new specialityLogic();
            obj.Cell1 = "Allergy & Immunology";
            obj.Cell2 = "Dermatology";
            obj.Cell3 = "Gastroenterology";
            obj.Cell4 = "Hematology";
            obj.Cell5 = "Neurology";
            obj.Cell6 = "Plastic Surgery";
            obj.Cell7 = "Psychiatry";
            this.BindingContext = obj;
        
       }

        void Next(object sender, EventArgs args)
        {

            Navigation.PushAsync(new DoctorSearch());
        }
    }
}
