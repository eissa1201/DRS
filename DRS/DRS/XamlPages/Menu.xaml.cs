using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DRS
{
    public partial class Menu : ContentPage
    {
        public string TheName;
        public string TheEmail;


        public Menu(string x, string y)
        {
            InitializeComponent();
            Class1 c = new Class1();

            Debug.WriteLine("your stored value is :"+c.Master);



            NavigationPage.SetHasNavigationBar(this, false);
            //Out.FadeTo(0, 1);
            //use.FadeTo(0, 1);
            Find.FadeTo(0, 1);
            Create.FadeTo(0, 1);
            Edit.FadeTo(0, 1);
            options.FadeTo(0, 1);
            var name = x.Split(' ');
            string SplitName = name[0];

            TheName = x;

            TheEmail = y;

            //use.Text = "Welcome " + SplitName.ToLower();
            Fade();


        }

        private async void Fade()
        {
            //await use.FadeTo(1, 300);
            await Find.FadeTo(1, 300);

            await Create.FadeTo(1, 300);
            await Edit.FadeTo(1, 300);
            await options.FadeTo(1, 300);
            //await Out.FadeTo(1, 300);
        }
        public async void moveTo(object sender, EventArgs args)
        {
            await Create.ScaleTo(0.95, 50, Easing.CubicOut);
            await Create.ScaleTo(1, 50, Easing.CubicIn);
            await Navigation.PushAsync(new CreateDoctor());
        }
        public async void FindDoctor(object sender, EventArgs args)
        {
            await Find.ScaleTo(0.95, 50, Easing.CubicOut);
            await Find.ScaleTo(1, 50, Easing.CubicIn);
            await Navigation.PushAsync(new DoctorsSearch(TheName));
        }
        public async void Profile(object sender, EventArgs args)
        {
            await Edit.ScaleTo(0.95, 50, Easing.CubicOut);
            await Edit.ScaleTo(1, 50, Easing.CubicIn);
            await Navigation.PushAsync(new Profile(TheEmail));
        }

        public async void Settings(object sender, EventArgs args)
        {

            await options.ScaleTo(0.95, 50, Easing.CubicOut);
            await options.ScaleTo(1, 50, Easing.CubicIn);
            await DisplayAlert("Sorry", " Settings page is still under development", "ok");
            //await Navigation.PushAsync(new Profile(TheEmail));
        }

        public async void SignOut(object sender, EventArgs args)
        {

            //await Out.ScaleTo(0.95, 50, Easing.CubicOut);
            //await Out.ScaleTo(1, 50, Easing.CubicIn);
            await Navigation.PopAsync();
            //await Navigation.PushAsync(new Profile(TheEmail));
        }
        public async void GroupChat(object sender, EventArgs args)
        {
            await Navigation.PushAsync(new GroupChat());

        }



    }
}
