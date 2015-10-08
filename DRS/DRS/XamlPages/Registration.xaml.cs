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

namespace DRS
{
    public partial class Registration : ContentPage
    {
        public Registration()
        {
            InitializeComponent();
        }
        private async void Registered(object sender, EventArgs args)
        {
            bool state = true;
            try
            {

                if (!(String.IsNullOrEmpty(EntryTitle.Text) || String.IsNullOrEmpty(EntryTitle2.Text) || String.IsNullOrEmpty(EntryTitle3.Text) || String.IsNullOrEmpty(EntryTitle4.Text) || String.IsNullOrEmpty(EntryTitle5.Text)))
                {
                    // here you Create Data
                    HttpClient client = new HttpClient();
                    HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Post, "https://api.parse.com/1/classes/UserData");
                    message.Headers.Clear();
                    message.Headers.Add("X-Parse-Application-Id", "2kWwje4PWZ980GmHQBk4EneY7DkENmlikDEZdwKt");
                    message.Headers.Add("X-Parse-REST-API-Key", "3cZnB4kNlPYCChLXEp90tjuBbioTBcycnkMtV9qC");

                    if (EntryTitle2.Text.Contains("@") && EntryTitle2.Text.Contains(".com"))
                    {
                        if ((EntryTitle3.Text == EntryTitle4.Text) && (EntryTitle3.Text.Length <= 16 && EntryTitle3.Text.Length >= 8))
                        {
                            int value;
                            if (int.TryParse(EntryTitle5.Text, out value) && EntryTitle5.Text.Length == 10)
                            {
                                var MyList = new List<string>();
                                HttpClient client1 = new HttpClient();
                                HttpRequestMessage message1 = new HttpRequestMessage(HttpMethod.Get, "https://api.parse.com/1/classes/UserData?" + WebUtility.UrlEncode("where=" + JsonConvert.SerializeObject(new DataParser() { Email = EntryTitle2.Text })));
                                message1.Headers.Clear();
                                message1.Headers.Add("X-Parse-Application-Id", "2kWwje4PWZ980GmHQBk4EneY7DkENmlikDEZdwKt");
                                message1.Headers.Add("X-Parse-REST-API-Key", "3cZnB4kNlPYCChLXEp90tjuBbioTBcycnkMtV9qC");


                                HttpResponseMessage response = await client1.SendAsync(message1);
                                string content = await response.Content.ReadAsStringAsync();
                                DataToList a = JsonConvert.DeserializeObject<DataToList>(content);
                                foreach (var item in a.GetStringList())
                                {
                                    MyList.Add(item);
                                }

                                if (a.GetStringList().Contains(EntryTitle2.Text))
                                {

                                    await DisplayAlert("Mistake", "Email already exists", "ok");

                                    return;
                                }


                                string json = JsonConvert.SerializeObject(new DataParser() { Username = EntryTitle.Text, Email = EntryTitle2.Text, Password = EntryTitle3.Text, PhoneNumber = EntryTitle5.Text });
                                message.Content = new StringContent(json, Encoding.UTF8, "application/json");
                                message.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                                HttpResponseMessage response3 = await client.SendAsync(message);
                                string content3 = await response.Content.ReadAsStringAsync();
                                await DisplayAlert("Congratulations !", " Your Account has been Created", "ok");
                                await Navigation.PopAsync();


                            }
                            else
                            {

                                await DisplayAlert("Problem", "Put a proper Phone Number !", "ok");
                            }

                        }
                        else
                        {

                            await DisplayAlert("Problem", " - check if password is the same \n - must be more 8 and less than 16 characters", "ok");
                        }

                    }
                    else
                    {

                        await DisplayAlert("Problem", "Put a proper Email ! ", "ok");
                    }

                }
                else
                {
                    await DisplayAlert("Problem", "Must Fill all the blanks ! ", "ok");
                }
            }
            catch (Exception e)
            {
                state = false;
            }
            if (state == false)
            {

                await DisplayAlert("Problem", "No internet connection", "ok");
            }

        }

    }
}


