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
    public partial class Profile : ContentPage
    {
        private List<string> Users = new List<string>();
        private string theEmail;
        public Profile(string Email)
        {
            InitializeComponent();

            theEmail = Email;
            GetUser();
        }
        async void GetUser()
        {

            bool state = true;


            Users.Clear();
            HttpClient client = new HttpClient();
            HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Get, "https://api.parse.com/1/classes/UserData?" + WebUtility.UrlEncode("where=" + JsonConvert.SerializeObject(new DataParser() { Email = theEmail })));
            message.Headers.Clear();
            message.Headers.Add("X-Parse-Application-Id", "2kWwje4PWZ980GmHQBk4EneY7DkENmlikDEZdwKt");
            message.Headers.Add("X-Parse-REST-API-Key", "3cZnB4kNlPYCChLXEp90tjuBbioTBcycnkMtV9qC");

            try
            {
                HttpResponseMessage response = await client.SendAsync(message);
                string content = await response.Content.ReadAsStringAsync();
                DataToList a = JsonConvert.DeserializeObject<DataToList>(content);
                foreach (var item in a.GetStringList())
                {
                    Users.Add(item);


                }

                if (Users.Count == 0)
                {
                    await DisplayAlert("Problem", " No Doctor in database", "ok");
                }
                else
                {
                    Username.Text = Users[0];
                    Email.Text = Users[1];
                    Password.Text = Users[2];
                    Phonenumber.Text = Users[3];
                }
            }
            catch (Exception e)
            {
                state = false;
            }
            if (state == false)
            {

                await DisplayAlert("Problem", "Issue with connection", "ok");
            }


        }

        async void Submit(object sender, EventArgs args)
        {
            bool state = true;
            try
            {

                //////////////////////////////////////////////////////////////////  start posting modified data
                if (!(String.IsNullOrEmpty(Username.Text) || String.IsNullOrEmpty(Email.Text) || String.IsNullOrEmpty(Password.Text) || String.IsNullOrEmpty(Phonenumber.Text)))
                {
                    if ((Password.Text.Length <= 16 && Password.Text.Length >= 8))
                    {
                        int value;
                        if (int.TryParse(Phonenumber.Text, out value) && Phonenumber.Text.Length == 10)
                        {
                            if (Email.Text.Contains("@") && Email.Text.Contains(".com"))
                            {
                                HttpClient client1 = new HttpClient();
                                HttpRequestMessage message1 = new HttpRequestMessage(HttpMethod.Put, "https://api.parse.com/1/classes/UserData/" + Users[4]);
                                message1.Headers.Clear();
                                message1.Headers.Add("X-Parse-Application-Id", "2kWwje4PWZ980GmHQBk4EneY7DkENmlikDEZdwKt");
                                message1.Headers.Add("X-Parse-REST-API-Key", "3cZnB4kNlPYCChLXEp90tjuBbioTBcycnkMtV9qC");
                                string json2 = JsonConvert.SerializeObject(new DataParser() { Username = Username.Text, Email = Email.Text, Password = Password.Text, PhoneNumber = Phonenumber.Text });
                                message1.Content = new StringContent(json2, Encoding.UTF8, "application/json");
                                message1.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");




                                HttpResponseMessage response1 = await client1.SendAsync(message1);

                                await DisplayAlert("Success", " * Your profile has been modified", "ok");

                            }
                            else
                            {


                                await DisplayAlert("Problem", "Put a proper Email ! ", "ok");
                            }
                        }
                        else
                        {

                            await DisplayAlert("Problem", "Put a proper Phone Number !", "ok");
                        }
                    }
                    else
                    {
                        await DisplayAlert("Problem", " - Password must be more than 8 and less than 16 characters", "ok");
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

                await DisplayAlert("Problem", "Issue with connection", "ok");
            }


        }
    }
}


