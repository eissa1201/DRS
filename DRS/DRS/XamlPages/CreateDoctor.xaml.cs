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
    public partial class CreateDoctor : ContentPage
    {
        private List<string> MyCity = new List<string>();
        private List<string> MyHospital = new List<string>();
        private List<string> MySpecialty = new List<string>();
        public CreateDoctor()
        {
            InitializeComponent();
            GetCity();
            GetSpecialty();



            ListOfCities.SelectedIndexChanged += (sender, e) =>
            {
                if (ListOfCities.SelectedIndex != -1)
                {
                    thePicker2label.IsVisible = true;
                    Loading2.IsRunning = true;
                    GetHospitalWithCondition();

                }
            };


            ListOfHospitals.SelectedIndexChanged += (sender, e) =>
            {
                if (ListOfHospitals.SelectedIndex != -1)
                {

                    thePicker3label.IsVisible = true;
                    ListOfSpecialties.IsVisible = true;
                }
            };


     


        }









        public async void GetCity()
        {
            // here you fetch Data
            bool state = true;
            HttpClient client = new HttpClient();
            HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Get, "https://api.parse.com/1/classes/City?");
            message.Headers.Clear();
            message.Headers.Add("X-Parse-Application-Id", "2kWwje4PWZ980GmHQBk4EneY7DkENmlikDEZdwKt");
            message.Headers.Add("X-Parse-REST-API-Key", "3cZnB4kNlPYCChLXEp90tjuBbioTBcycnkMtV9qC");

            try
            {
                HttpResponseMessage response = await client.SendAsync(message);
                string content = await response.Content.ReadAsStringAsync();
                DataToListForCity a = JsonConvert.DeserializeObject<DataToListForCity>(content);
                foreach (var item in a.GetStringList())
                {
                    MyCity.Add(item);

                    ListOfCities.Items.Add(item);
                    //Debug.WriteLine(item);


                }

                Loading1.IsVisible = false;
                Loading1.IsEnabled = false;
                ListOfCities.IsVisible = true;
                ListOfCities.IsEnabled = true;


                // listView.ItemsSource = MyList;

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






        public async void GetCityWithCondition()
        {
            MyCity.Clear();
            ListOfCities.Items.Clear();

            // here you fetch Data
            string H = MyHospital[ListOfHospitals.SelectedIndex];
            HttpClient client = new HttpClient();
            HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Get, "https://api.parse.com/1/classes/Hospital?" + WebUtility.UrlEncode("where=" + JsonConvert.SerializeObject(new DataParserForHospital() { Hospital = H })));
            message.Headers.Clear();
            message.Headers.Add("X-Parse-Application-Id", "2kWwje4PWZ980GmHQBk4EneY7DkENmlikDEZdwKt");
            message.Headers.Add("X-Parse-REST-API-Key", "3cZnB4kNlPYCChLXEp90tjuBbioTBcycnkMtV9qC");

            try
            {
                HttpResponseMessage response = await client.SendAsync(message);
                string content = await response.Content.ReadAsStringAsync();
                DataToListForCity a = JsonConvert.DeserializeObject<DataToListForCity>(content);
                foreach (var item in a.GetStringList())
                {
                    MyCity.Add(item);

                    ListOfCities.Items.Add(item);


                }


                // listView.ItemsSource = MyList;

            }
            catch (Exception e1)
            {
                

            }
        }
        public async void GetHospital()
        {
            // here you fetch Data

            HttpClient client = new HttpClient();
            HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Get, "https://api.parse.com/1/classes/Hospital?");
            message.Headers.Clear();
            message.Headers.Add("X-Parse-Application-Id", "2kWwje4PWZ980GmHQBk4EneY7DkENmlikDEZdwKt");
            message.Headers.Add("X-Parse-REST-API-Key", "3cZnB4kNlPYCChLXEp90tjuBbioTBcycnkMtV9qC");

            try
            {
                HttpResponseMessage response = await client.SendAsync(message);
                string content = await response.Content.ReadAsStringAsync();
                DataToListForHospital a = JsonConvert.DeserializeObject<DataToListForHospital>(content);
                foreach (var item in a.GetStringList())
                {
                    MyHospital.Add(item);
                    ListOfHospitals.Items.Add(item);


                }

                // listView.ItemsSource = MyList;

            }
            catch (Exception e1)
            {
             

            }
        }
        public async void GetHospitalWithCondition()
        {



            MyHospital.Clear();
            ListOfHospitals.Items.Clear();
            // here you fetch Data
            int SelectedCity = ListOfCities.SelectedIndex;
            HttpClient client = new HttpClient();
            HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Get, "https://api.parse.com/1/classes/Hospital?" + WebUtility.UrlEncode("where=" + JsonConvert.SerializeObject(new DataParserForHospital() { City = MyCity[SelectedCity] })));
            message.Headers.Clear();
            message.Headers.Add("X-Parse-Application-Id", "2kWwje4PWZ980GmHQBk4EneY7DkENmlikDEZdwKt");
            message.Headers.Add("X-Parse-REST-API-Key", "3cZnB4kNlPYCChLXEp90tjuBbioTBcycnkMtV9qC");

            try
            {
                HttpResponseMessage response = await client.SendAsync(message);
                string content = await response.Content.ReadAsStringAsync();
                DataToListForHospital a = JsonConvert.DeserializeObject<DataToListForHospital>(content);
                foreach (var item in a.GetStringList())
                {
                    MyHospital.Add(item);
                    ListOfHospitals.Items.Add(item);


                }
                Loading2.IsRunning = false;

                ListOfHospitals.IsVisible = true;
               

            }
            catch (Exception e1)
            {
              

            }
        }

        public async void GetSpecialty()
        {

            // here you fetch Data

            HttpClient client = new HttpClient();
            HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Get, "https://api.parse.com/1/classes/Specialty?");
            message.Headers.Clear();
            message.Headers.Add("X-Parse-Application-Id", "2kWwje4PWZ980GmHQBk4EneY7DkENmlikDEZdwKt");
            message.Headers.Add("X-Parse-REST-API-Key", "3cZnB4kNlPYCChLXEp90tjuBbioTBcycnkMtV9qC");

            try
            {
                HttpResponseMessage response = await client.SendAsync(message);
                string content = await response.Content.ReadAsStringAsync();
                DataToListForSpecialty a = JsonConvert.DeserializeObject<DataToListForSpecialty>(content);
                foreach (var item in a.GetStringList())
                {
                    MySpecialty.Add(item);
                    ListOfSpecialties.Items.Add(item);


                }


                

            }
            catch (Exception e1)
            {
              

            }
        }

        public async void Picker(object sender, EventArgs args)
        {


            await CreateUser.ScaleTo(0.95, 50, Easing.CubicOut);
            await CreateUser.ScaleTo(1, 50, Easing.CubicIn);
            CreateLoading.IsRunning = true;

            // here you Create Data
            if (DoctorName.Text != null)
            {
                string Doctor = DoctorName.Text;
                string Doctor2 = Doctor.Trim();

                int CityNumber = ListOfCities.SelectedIndex;
                int HospitalNumber = ListOfHospitals.SelectedIndex;
                int SpecialtyNumber = ListOfSpecialties.SelectedIndex;
                if (CityNumber != -1 && HospitalNumber != -1 && SpecialtyNumber != -1 && Doctor2 != "")
                {

                    Debug.WriteLine("city selected was " + MyCity[CityNumber]);
                    Debug.WriteLine("hospital selected was " + MyHospital[HospitalNumber]);
                    Debug.WriteLine("Specialty selected was " + MySpecialty[SpecialtyNumber]);

                    ///////////////////////// CHECK IF DOCTOR ALREADY EXISTS

                    HttpClient client1 = new HttpClient();
                    HttpRequestMessage message1 = new HttpRequestMessage(HttpMethod.Get, "https://api.parse.com/1/classes/EmployeeData?" + JsonConvert.SerializeObject(new DataParserForEmployees() { Name = DoctorName.Text }));
                    message1.Headers.Clear();
                    message1.Headers.Add("X-Parse-Application-Id", "2kWwje4PWZ980GmHQBk4EneY7DkENmlikDEZdwKt");
                    message1.Headers.Add("X-Parse-REST-API-Key", "3cZnB4kNlPYCChLXEp90tjuBbioTBcycnkMtV9qC");
                    bool state = true;
                    try
                    {
                        HttpResponseMessage response = await client1.SendAsync(message1);
                        string content = await response.Content.ReadAsStringAsync();
                        DataToListForEmployees a = JsonConvert.DeserializeObject<DataToListForEmployees>(content);


                        if (a.GetStringList().Contains(DoctorName.Text))
                        {
                            CreateLoading.IsRunning = false;
                            await DisplayAlert("Problem", "Doctor already exists", "ok");

                            return;
                        }
                        // listView.ItemsSource = MyList;
                    }
                    catch (Exception e)
                    {
                        state = false;
                    }
                    if (state == false)
                    {

                        await DisplayAlert("Problem", "Issue with connection", "ok");

                    }














                    ////////////////////////////////////////////////////////////////////////////////////////////
                    HttpClient client = new HttpClient();
                    HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Post, "https://api.parse.com/1/classes/EmployeeData");
                    message.Headers.Clear();
                    message.Headers.Add("X-Parse-Application-Id", "2kWwje4PWZ980GmHQBk4EneY7DkENmlikDEZdwKt");
                    message.Headers.Add("X-Parse-REST-API-Key", "3cZnB4kNlPYCChLXEp90tjuBbioTBcycnkMtV9qC");
                    string json = JsonConvert.SerializeObject(new DataParserForEmployees() { Name = DoctorName.Text, Hospital = MyHospital[HospitalNumber], Specialty = MySpecialty[SpecialtyNumber], City = MyCity[CityNumber] });
                    message.Content = new StringContent(json, Encoding.UTF8, "application/json");
                    message.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    try
                    {
                        HttpResponseMessage response = await client.SendAsync(message);
                        string content = await response.Content.ReadAsStringAsync();
                        CreateLoading.IsRunning = false;
                        await DisplayAlert("Congratulations", DoctorName.Text + " was created !", "ok");
                        DoctorName.Text = "";
                    }
                    catch (Exception e1)
                    {

                    }
                }
                else
                {
                    CreateLoading.IsRunning = false;
                    await DisplayAlert("Problem", " Must fill all the blanks", "ok");
                }
            }
            else
            {
                CreateLoading.IsRunning = false;
                await DisplayAlert("Problem", " Must fill all the blanks", "ok");
            }
        }



    }
}
