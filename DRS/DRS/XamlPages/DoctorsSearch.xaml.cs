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
            Application.Current.Properties["City"] = "Choose City";
            Application.Current.Properties["Hospital"] = "Choose Hospital";
            Application.Current.Properties["Specialty"] = "Choose Specialty";
            
            username = User;
            InitializeComponent();



        }



        protected  override void OnAppearing()
        {


            var CityName = Application.Current.Properties["City"];

            City.Text = CityName.ToString();


            var HospitalName = Application.Current.Properties["Hospital"];

            Hospital.Text = HospitalName.ToString();


            var SpecialtyName = Application.Current.Properties["Specialty"];

            Specialty.Text = SpecialtyName.ToString();
        }


        async void SearchCity(object sender, EventArgs args)
        {
            await City.ScaleTo(0.95, 50, Easing.CubicOut);
            await City.ScaleTo(1, 50, Easing.CubicIn);
            CityLoad.IsVisible = true;
            City.Text = "";
              bool state = true;
            try
            {
           // here you fetch Data

                HttpClient client = new HttpClient();
                HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Get, "https://api.parse.com/1/classes/City?");
                message.Headers.Clear();
                message.Headers.Add("X-Parse-Application-Id", "2kWwje4PWZ980GmHQBk4EneY7DkENmlikDEZdwKt");
                message.Headers.Add("X-Parse-REST-API-Key", "3cZnB4kNlPYCChLXEp90tjuBbioTBcycnkMtV9qC");

               
                    HttpResponseMessage response = await client.SendAsync(message);
                    string content = await response.Content.ReadAsStringAsync();
                    DataToListForCity a = JsonConvert.DeserializeObject<DataToListForCity>(content);
                    foreach (var item in a.GetStringList())
                    {
                        MyCity.Add(item);

                    }
                 
            }
            catch (Exception e)
            {
                state = false;
            }
            if (state == false)
            {

                await DisplayAlert("Problem", "No internet connection", "ok");
                CityLoad.IsVisible = false;
                City.Text = "Choose City";

            }
            else
            {
                Application.Current.Properties["Hospital"] = "Choose Hospital";  // to reset hospital value if chosen before city.
                await Navigation.PushAsync(new CitySearch(MyCity));
                CityLoad.IsVisible = false;
                City.Text = "Choose City";
            }



          

        }
        async void SearchHospital(object sender, EventArgs args)
        {
            MyHospital.Clear();
            await Hospital.ScaleTo(0.95, 50, Easing.CubicOut);
            await Hospital.ScaleTo(1, 50, Easing.CubicIn);
            HospitalLoad.IsVisible = true;
            Hospital.Text = "";
            bool state = true;
         
             var HospitalName = Application.Current.Properties["Hospital"] as string;
             var CityName = Application.Current.Properties["City"] as string;
             if (CityName != "Choose City")
             {                                             ////////////////////////////////     search hospitals with a specific City
                 HttpClient client = new HttpClient();

                 HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Get, "https://api.parse.com/1/classes/Hospital?" + WebUtility.UrlEncode("where=" + JsonConvert.SerializeObject(new DataParserForEmployees() { City = CityName })));
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



                     }

                     // listView.ItemsSource = MyList;

                 }
                 catch (Exception e1)
                 {
                     state = false;

                 }
                 if (state == false)
                 {

                     await DisplayAlert("Problem", "No internet connection", "ok");
                     HospitalLoad.IsVisible = false;
                     Hospital.Text = "Choose Hospital";

                 }
                 else
                 {

                     await Navigation.PushAsync(new HospitalSearch(MyHospital));
                     HospitalLoad.IsVisible = false;
                     Hospital.Text = "Choose Hospital";
                 }
             }
             else         ////////////////////////////////     search hospitals without specific City
             {
               
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



                     }

                     // listView.ItemsSource = MyList;

                 }
                 catch (Exception e1)
                 {
                     state = false;

                 }
                 if (state == false)
                 {

                     await DisplayAlert("Problem", "No internet connection", "ok");
                     HospitalLoad.IsVisible = false;
                     Hospital.Text = "Choose Hospital";

                 }
                 else
                 {

                     await Navigation.PushAsync(new HospitalSearch(MyHospital));
                     HospitalLoad.IsVisible = false;
                     Hospital.Text = "Choose Hospital";
                 }


             }



        }
        async void SearchSpecialty(object sender, EventArgs args)
        {

            await Specialty.ScaleTo(0.95, 50, Easing.CubicOut);
            await Specialty.ScaleTo(1, 50, Easing.CubicIn);
            SpecialtyLoad.IsVisible = true;
            Specialty.Text = "";
            bool state = true;
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
                  


                }

                
                // listView.ItemsSource = MyList;

            }
            catch (Exception e1)
            {
                state = false;
            }
            if (state == false)
            {

                await DisplayAlert("Problem", "No internet connection", "ok");
                SpecialtyLoad.IsVisible = false;
                Specialty.Text = "Choose Specialty";

            }
            else
            {
                await Navigation.PushAsync(new SpecialtySearch(MySpecialty));
                SpecialtyLoad.IsVisible = false;
                Specialty.Text = "Choose Specialty";
            }

        }




        public async void Search(object sender, EventArgs args)
        {
            Application.Current.Properties["id"] = "Entered Picker";
            Cover.IsVisible = true;
            await SearchButton.ScaleTo(0.95, 50, Easing.CubicOut);
            await SearchButton.ScaleTo(1, 50, Easing.CubicIn);
            bool state = true;

            var CityName = Application.Current.Properties["City"];
            var HospitalName = Application.Current.Properties["Hospital"];
            var SpecialtyName = Application.Current.Properties["Specialty"];
            try
            {

               if (HospitalName.ToString() != "Choose Hospital" && SpecialtyName.ToString() != "Choose Specialty")
                {

                    ListOfDoctors.Clear();
                    HttpClient client = new HttpClient();
                    HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Get, "https://api.parse.com/1/classes/EmployeeData?" + WebUtility.UrlEncode("where=" + JsonConvert.SerializeObject(new DataParserForEmployees() { Hospital = HospitalName.ToString(), Specialty = SpecialtyName.ToString() })));
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
                        //loading.IsVisible = false;
                        Cover.IsVisible = false;
                        await Navigation.PushAsync(new ResultsC(ListOfDoctors, username));

                    }


                }

                else if (CityName.ToString() != "Choose City" && SpecialtyName.ToString() != "Choose Specialty")   
                {

                    ListOfDoctors.Clear();
                    HttpClient client = new HttpClient();
                    HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Get, "https://api.parse.com/1/classes/EmployeeData?" + WebUtility.UrlEncode("where=" + JsonConvert.SerializeObject(new DataParserForEmployees() { City = CityName.ToString(), Specialty = SpecialtyName.ToString() })));
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
                        //loading.IsVisible = false;
                        Cover.IsVisible = false;
                        await Navigation.PushAsync(new ResultsC(ListOfDoctors, username));

                    }


                }
                else if (CityName.ToString() != "Choose City" && HospitalName.ToString() != "Choose Hospital")  ///////////     important for repeated hospitals in diffrent cities
                {

                    ListOfDoctors.Clear();
                    HttpClient client = new HttpClient();
                    HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Get, "https://api.parse.com/1/classes/EmployeeData?" + WebUtility.UrlEncode("where=" + JsonConvert.SerializeObject(new DataParserForEmployees() { City = CityName.ToString(), Hospital = HospitalName.ToString() })));
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
                        //loading.IsVisible = false;
                        Cover.IsVisible = false;
                        await Navigation.PushAsync(new ResultsC(ListOfDoctors, username));

                    }


                }

                else if (CityName.ToString() != "Choose City")
                {

                    ListOfDoctors.Clear();
                    HttpClient client = new HttpClient();
                    HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Get, "https://api.parse.com/1/classes/EmployeeData?" + WebUtility.UrlEncode("where=" + JsonConvert.SerializeObject(new DataParserForEmployees() { City = CityName.ToString() })));
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
                        //loading.IsVisible = false;
                        Cover.IsVisible = false;
                        await Navigation.PushAsync(new ResultsC(ListOfDoctors, username));


                    }


                }
                else if (HospitalName.ToString() != "Choose Hospital")
                {

                    ListOfDoctors.Clear();
                    HttpClient client = new HttpClient();
                    HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Get, "https://api.parse.com/1/classes/EmployeeData?" + WebUtility.UrlEncode("where=" + JsonConvert.SerializeObject(new DataParserForEmployees() { Hospital = HospitalName.ToString() })));
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
                        //loading.IsVisible = false;
                        Cover.IsVisible = false;
                        await Navigation.PushAsync(new ResultsC(ListOfDoctors, username));


                    }


                }

                else if (SpecialtyName.ToString() != "Choose Specialty")
                {

                    ListOfDoctors.Clear();
                    HttpClient client = new HttpClient();
                    HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Get, "https://api.parse.com/1/classes/EmployeeData?" + WebUtility.UrlEncode("where=" + JsonConvert.SerializeObject(new DataParserForEmployees() { Specialty = SpecialtyName.ToString() })));
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
                        //loading.IsVisible = false;
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
                        //loading.IsVisible = false;
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
