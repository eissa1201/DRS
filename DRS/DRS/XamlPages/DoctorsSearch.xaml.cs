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

    public partial class DoctorsSearch : ContentPage
    {
        private List<string> MyCity = new List<string>();
        private List<string> MyHospital = new List<string>();
        private List<string> MySpecialty = new List<string>();
        private List<string> ListOfDoctors = new List<string>();
        public string username;
        public DoctorsSearch(string User)
        {
            username = User;
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


            ListOfSpecialties.SelectedIndexChanged += (sender, e) =>
            {
                if (ListOfSpecialties.SelectedIndex != -1)
                {


                }
            };


        }










        public async void GetCity()
        {


            bool state = true;
            try
            {



                // here you fetch Data

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
                catch (Exception e1)
                {
                    Debug.WriteLine("cant fetch data for City");

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
                Debug.WriteLine("cant fetch data for City");

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
                Debug.WriteLine("cant fetch data for City");

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
                // listView.ItemsSource = MyList;

            }
            catch (Exception e1)
            {
                Debug.WriteLine("cant fetch data for City");

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


                // listView.ItemsSource = MyList;

            }
            catch (Exception e1)
            {
                Debug.WriteLine("cant fetch data for City");

            }
        }






        public async void Picker(object sender, EventArgs args)
        {

            Cover.IsVisible = true;
            await Search.ScaleTo(0.95, 50, Easing.CubicOut);
            await Search.ScaleTo(1, 50, Easing.CubicIn);
            bool state = true;
            try
            {
                loading.IsVisible = true;
                int CityNumber = ListOfCities.SelectedIndex;
                int HospitalNumber = ListOfHospitals.SelectedIndex;
                int SpecialtyNumber = ListOfSpecialties.SelectedIndex;
                if (CityNumber != -1 && HospitalNumber != -1 && SpecialtyNumber != -1)
                {

                    Debug.WriteLine("city selected was " + MyCity[CityNumber]);
                    Debug.WriteLine("hospital selected was " + MyHospital[HospitalNumber]);
                    Debug.WriteLine("Specialty selected was " + MySpecialty[SpecialtyNumber]);

                    ///////////////////////// CHECK IF DOCTOR ALREADY EXISTS
                    ListOfDoctors.Clear();
                    HttpClient client = new HttpClient();
                    HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Get, "https://api.parse.com/1/classes/EmployeeData?" + WebUtility.UrlEncode("where=" + JsonConvert.SerializeObject(new DataParserForEmployees() { Hospital = MyHospital[HospitalNumber], Specialty = MySpecialty[SpecialtyNumber] })));
                    message.Headers.Clear();
                    message.Headers.Add("X-Parse-Application-Id", "2kWwje4PWZ980GmHQBk4EneY7DkENmlikDEZdwKt");
                    message.Headers.Add("X-Parse-REST-API-Key", "3cZnB4kNlPYCChLXEp90tjuBbioTBcycnkMtV9qC");


                    HttpResponseMessage response = await client.SendAsync(message);
                    string content = await response.Content.ReadAsStringAsync();
                    DataToListForEmployees a = JsonConvert.DeserializeObject<DataToListForEmployees>(content);
                    foreach (var item in a.GetStringList())
                    {

                        ListOfDoctors.Add(item);


                    }

                    if (ListOfDoctors.Count == 0)
                    {
                        await DisplayAlert("Problem", " No Doctor in database", "ok");
                        Cover.IsVisible = false;
                    }
                    else
                    {
                        loading.IsVisible = false;
                        Cover.IsVisible = false;
                        await Navigation.PushAsync(new ResultsC(ListOfDoctors, username));


                    }





                }
                else if (CityNumber != -1 && HospitalNumber != -1)
                {
                    
                    ListOfDoctors.Clear();
                    HttpClient client = new HttpClient();
                    HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Get, "https://api.parse.com/1/classes/EmployeeData?" + WebUtility.UrlEncode("where=" + JsonConvert.SerializeObject(new DataParserForEmployees() { Hospital = MyHospital[HospitalNumber] })));
                    message.Headers.Clear();
                    message.Headers.Add("X-Parse-Application-Id", "2kWwje4PWZ980GmHQBk4EneY7DkENmlikDEZdwKt");
                    message.Headers.Add("X-Parse-REST-API-Key", "3cZnB4kNlPYCChLXEp90tjuBbioTBcycnkMtV9qC");


                    HttpResponseMessage response = await client.SendAsync(message);
                    string content = await response.Content.ReadAsStringAsync();
                    DataToListForEmployees a = JsonConvert.DeserializeObject<DataToListForEmployees>(content);
                    foreach (var item in a.GetStringList())
                    {
                        ListOfDoctors.Add(item);


                    }

                    if (ListOfDoctors.Count == 0)
                    {
                        await DisplayAlert("Problem", " No Doctor in database", "ok");
                        Cover.IsVisible = false;
                    }
                    else
                    {
                        loading.IsVisible = false;
                        Cover.IsVisible = false;
                        await Navigation.PushAsync(new ResultsC(ListOfDoctors, username));

                    }


                }
                else if (CityNumber != -1)
                {

                    ListOfDoctors.Clear();
                    HttpClient client = new HttpClient();
                    HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Get, "https://api.parse.com/1/classes/EmployeeData?" + WebUtility.UrlEncode("where=" + JsonConvert.SerializeObject(new DataParserForEmployees() { City = MyCity[CityNumber] })));
                    message.Headers.Clear();
                    message.Headers.Add("X-Parse-Application-Id", "2kWwje4PWZ980GmHQBk4EneY7DkENmlikDEZdwKt");
                    message.Headers.Add("X-Parse-REST-API-Key", "3cZnB4kNlPYCChLXEp90tjuBbioTBcycnkMtV9qC");


                    HttpResponseMessage response = await client.SendAsync(message);
                    string content = await response.Content.ReadAsStringAsync();
                    DataToListForEmployees a = JsonConvert.DeserializeObject<DataToListForEmployees>(content);
                    foreach (var item in a.GetStringList())
                    {
                        ListOfDoctors.Add(item);


                    }

                    if (ListOfDoctors.Count == 0)
                    {
                        await DisplayAlert("Problem", " No Doctor in database", "ok");
                        Cover.IsVisible = false;
                    }
                    else
                    {
                        loading.IsVisible = false;
                        Cover.IsVisible = false;
                        await Navigation.PushAsync(new ResultsC(ListOfDoctors, username));


                    }


                }
                else
                {

                    ListOfDoctors.Clear();
                    HttpClient client = new HttpClient();
                    HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Get, "https://api.parse.com/1/classes/EmployeeData?");
                    message.Headers.Clear();
                    message.Headers.Add("X-Parse-Application-Id", "2kWwje4PWZ980GmHQBk4EneY7DkENmlikDEZdwKt");
                    message.Headers.Add("X-Parse-REST-API-Key", "3cZnB4kNlPYCChLXEp90tjuBbioTBcycnkMtV9qC");


                    HttpResponseMessage response = await client.SendAsync(message);
                    string content = await response.Content.ReadAsStringAsync();
                    DataToListForEmployees a = JsonConvert.DeserializeObject<DataToListForEmployees>(content);
                    foreach (var item in a.GetStringList())
                    {
                        ListOfDoctors.Add(item);


                    }

                    if (ListOfDoctors.Count == 0)
                    {
                        await DisplayAlert("Problem", " No Doctor in database", "ok");
                        Cover.IsVisible = false;
                    }
                    else
                    {
                        loading.IsVisible = false;
                        Cover.IsVisible = false;
                        await Navigation.PushAsync(new ResultsC(ListOfDoctors, username));


                    }





                }



            }
            catch (Exception e)
            {
                state = false;
            }
            if (state == false)
            {

                await DisplayAlert("Problem", "Issue with connection", "ok");
                Cover.IsVisible = false;
                state = true;
            }
        }
    }
}
