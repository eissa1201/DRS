using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using Xamarin.Forms;
using System.Threading.Tasks;
using System.Diagnostics;


using System.IO;
using System.Net.Http.Headers;
using System.Threading;

namespace DRS
{
    public partial class WelcomePage : ContentPage
    {

        public List<string> MyList = new List<string>();
        public WelcomePage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            loading.IsVisible = false;


        }






        private async void Login(object sender, EventArgs args)
        {
            bool state = true;
            await sign.ScaleTo(0.95, 50, Easing.CubicOut);
            await sign.ScaleTo(1, 50, Easing.CubicIn);
            Cover.IsVisible = true;
            Cover2.IsVisible = true;

            loading.IsVisible = true;
            try
            {
                if (!(String.IsNullOrEmpty(EntryTitle.Text) || String.IsNullOrEmpty(EntryTitle2.Text)))
                {
                    // here you fetch Data
                    HttpClient client = new HttpClient();
                    client.Timeout = TimeSpan.FromSeconds(10);
                    HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Get, "https://api.parse.com/1/classes/UserData?" + WebUtility.UrlEncode("where=" + JsonConvert.SerializeObject(new DataParser() { Email = EntryTitle.Text, Password = EntryTitle2.Text })));
                    message.Headers.Clear();
                    message.Headers.Add("X-Parse-Application-Id", "2kWwje4PWZ980GmHQBk4EneY7DkENmlikDEZdwKt");
                    message.Headers.Add("X-Parse-REST-API-Key", "3cZnB4kNlPYCChLXEp90tjuBbioTBcycnkMtV9qC");
                   // var Timeout = Convert.ToInt32(TimeSpan.FromMilliseconds(5000));
                    HttpResponseMessage response = await client.SendAsync(message);
           // await WaitAndExecute(5000);
               
                    string content = await response.Content.ReadAsStringAsync();
                    DataToList a = JsonConvert.DeserializeObject<DataToList>(content);

                 



            

                    foreach (var item in a.GetStringList())
                    {
                        MyList.Add(item);
                    }



                    if (a.GetStringList().Contains(EntryTitle.Text))
                    {
                        loading.IsVisible = false;
                        Class1 c = new Class1();
                        c.Master = EntryTitle.Text;
                        await Navigation.PushAsync(new Menu(MyList[0], EntryTitle.Text));
                      //  EntryTitle.Text = "";
                        EntryTitle2.Text = "";
                        Cover.IsVisible = false;
                        Cover2.IsVisible = false;
                        MyList.Clear();

                    }
                    else
                    {

                        await DisplayAlert("Problem", "Wrong Username or Password!", "ok");
                        loading.IsVisible = false;
                        Cover.IsVisible = false;
                        Cover2.IsVisible = false;
                    }


                }
                else
                {

                    await DisplayAlert("Problem", "Fill in the blanks", "ok");
                    loading.IsVisible = false;

                    Cover.IsVisible = false;
                    Cover2.IsVisible = false;
                }
            }
            catch (Exception e)
            {
                state = false;

            }

            if (state == false)
            {
                Cover2.IsVisible = false;
                Cover.IsVisible = false;
                loading.IsVisible = false;
                await DisplayAlert("Problem", "Issue with connection", "ok");
            }


        }


        private async Task WaitAndExecute(int milisec){
        await Task.Delay(milisec);
        await DisplayAlert("Problem", "too long", "ok");
 }


        async void Registration(object sender, EventArgs args)
        {
            await signup.ScaleTo(0.95, 50, Easing.CubicOut);
            await signup.ScaleTo(1, 50, Easing.CubicIn);
            await Navigation.PushAsync(new Registration());
        }
    }
}
