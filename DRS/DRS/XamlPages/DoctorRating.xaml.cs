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

    public partial class DoctorRating : ContentPage
    {
        private List<string> ListOfUsers = new List<string>();
        private List<string> CommentsCollector = new List<string>();
        private List<string> TheDoctor = new List<string>();
        private List<string> CheckExisting = new List<string>();
        private List<string> Rater = new List<string>();
        private string usernameToComment;
        private string TheNameToComment;
        public DoctorRating(string TheName, string Username)
        {
            InitializeComponent();
       
            Rater.Add("Excellent");
            Rater.Add("Good");
            Rater.Add("Average");
            Rater.Add("OK");
            Rater.Add("Bad");
            foreach(var item in Rater)
            Rating.Items.Add(item);
         
            Comment.TextChanged += (sender, e) =>
            {

             
                

              
            };
         



            Rating.SelectedIndexChanged += (sender, e) =>
            {
                if (Rating.SelectedIndex != -1)
                {
                 RatingLable.IsVisible = false;
                    PostRating();

                }
            };
            

            usernameToComment = Username;

            TheNameToComment = TheName;



            DoctorInformation(TheName);


            GetComments(TheName);
        }


        public async void PostRating()
        {


            ////////////////////////////////////////////////////////////////////////////////////////////////////  to check if already rated 
            CheckExisting.Clear();
            CheckExisting.Clear();
            HttpClient client = new HttpClient();
            HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Get, "https://api.parse.com/1/classes/EmployeeRating?" + WebUtility.UrlEncode("where=" + JsonConvert.SerializeObject(new DataParserForEmployees() { Name = TheNameToComment, Username = usernameToComment })));
            message.Headers.Clear();
            message.Headers.Add("X-Parse-Application-Id", "2kWwje4PWZ980GmHQBk4EneY7DkENmlikDEZdwKt");
            message.Headers.Add("X-Parse-REST-API-Key", "3cZnB4kNlPYCChLXEp90tjuBbioTBcycnkMtV9qC");

            try
            {
                HttpResponseMessage response = await client.SendAsync(message);
                string content = await response.Content.ReadAsStringAsync();
                DataToListForEmployeesForRating2 a = JsonConvert.DeserializeObject<DataToListForEmployeesForRating2>(content);
                foreach (var item in a.GetStringList())
                {
                    CheckExisting.Add(item);


                }

                if (CheckExisting.Count == 0)
                {

////////////////////////////////////////////////////////////////////////////////////////////////////  to post new rating 
                      HttpClient client2 = new HttpClient();
                HttpRequestMessage message2= new HttpRequestMessage(HttpMethod.Post, "https://api.parse.com/1/classes/EmployeeRating");
                message2.Headers.Clear();
                message2.Headers.Add("X-Parse-Application-Id", "2kWwje4PWZ980GmHQBk4EneY7DkENmlikDEZdwKt");
                message2.Headers.Add("X-Parse-REST-API-Key", "3cZnB4kNlPYCChLXEp90tjuBbioTBcycnkMtV9qC");
                string json = JsonConvert.SerializeObject(new DataParserForUserRating() { Name = TheNameToComment, Username = usernameToComment, Rating = Rating.SelectedIndex + 1 });
                message2.Content = new StringContent(json, Encoding.UTF8, "application/json");
                message2.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
              
                    HttpResponseMessage response2 = await client2.SendAsync(message2);
      await DisplayAlert("Success", " * Your evaluation has been posted", "ok");


                }
                else
                {
 ////////////////////////////////////////////////////////////////////////////////////////////////////  to modify current rating 
                    HttpClient client1 = new HttpClient();
                    HttpRequestMessage message1 = new HttpRequestMessage(HttpMethod.Put, "https://api.parse.com/1/classes/EmployeeRating/" + CheckExisting[0]);
                    message1.Headers.Clear();
                    message1.Headers.Add("X-Parse-Application-Id", "2kWwje4PWZ980GmHQBk4EneY7DkENmlikDEZdwKt");
                    message1.Headers.Add("X-Parse-REST-API-Key", "3cZnB4kNlPYCChLXEp90tjuBbioTBcycnkMtV9qC");
                    string json2 = JsonConvert.SerializeObject(new DataParserForUserRating() { Rating = Rating.SelectedIndex +1 });
                    message1.Content = new StringContent(json2, Encoding.UTF8, "application/json");
                    message1.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    HttpResponseMessage response1 = await client1.SendAsync(message1);

                    await DisplayAlert("Success", " * Your original post has been modified", "ok");
                }
            }
            catch (Exception e1)
            {

            }









        }
        
        
    
          

    

        public async void DoctorInformation(string TheName)
        {
            loading.IsVisible = true;
            TheDoctor.Clear();
            HttpClient client = new HttpClient();
            HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Get, "https://api.parse.com/1/classes/EmployeeData?" + WebUtility.UrlEncode("where=" + JsonConvert.SerializeObject(new DataParserForEmployees() { Name = TheName })));
            message.Headers.Clear();
            message.Headers.Add("X-Parse-Application-Id", "2kWwje4PWZ980GmHQBk4EneY7DkENmlikDEZdwKt");
            message.Headers.Add("X-Parse-REST-API-Key", "3cZnB4kNlPYCChLXEp90tjuBbioTBcycnkMtV9qC");

            try
            {
                HttpResponseMessage response = await client.SendAsync(message);
                string content = await response.Content.ReadAsStringAsync();
                DataToListForEmployeesForRating a = JsonConvert.DeserializeObject<DataToListForEmployeesForRating>(content);
                foreach (var item in a.GetStringList())
                {
                    TheDoctor.Add(item);


                }

                if (TheDoctor.Count == 0)
                {
                    await DisplayAlert("Problem", " No Doctor in database", "ok");
                }
                else
                {


                    loading.IsVisible = false;
                    Information.Text = " Name : " + TheDoctor[0] + "\n Speciality : " + TheDoctor[4] + "\n Hospital : " + TheDoctor[2] + "\n City : " + TheDoctor[1];
               
                   // SpecialtyName.Text = " Speciality : " + TheDoctor[2];

                 //   CityName.Text = " City : " + TheDoctor[1];



                    //if (TheDoctor[3] == "5")
                    //{



                    //}
                    //else if (TheDoctor[3] == "4")
                    //{
                    //    star4.IsVisible = false;


                    //}
                    //else if (TheDoctor[3] == "3")
                    //{

                    //    star4.IsVisible = false;
                    //    star3.IsVisible = false;

                    //}
                    //else if (TheDoctor[3] == "2")
                    //{

                    //    star4.IsVisible = false;
                    //    star3.IsVisible = false;
                    //    star2.IsVisible = false;
                    //}
                    //else
                    //{

                    //    star4.IsVisible = false;
                    //    star3.IsVisible = false;
                    //    star2.IsVisible = false;
                    //    star1.IsVisible = false;



                    //}
                }

                loading.IsVisible = false;
         

            }
            catch (Exception e1)
            {
          

            }



        }


        public async void GetComments(String Doctor)
        {

               bool state = true;
        

                //loading2.IsVisible = true;
                // here you fetch Data
                ListOfUsers.Clear();
                CommentsCollector.Clear();
                HttpClient client = new HttpClient();
                HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Get, "https://api.parse.com/1/classes/EmployeeRating?" + WebUtility.UrlEncode("where=" + JsonConvert.SerializeObject(new DataParserForUserRating() { Name = Doctor })));
                message.Headers.Clear();
                message.Headers.Add("X-Parse-Application-Id", "2kWwje4PWZ980GmHQBk4EneY7DkENmlikDEZdwKt");
                message.Headers.Add("X-Parse-REST-API-Key", "3cZnB4kNlPYCChLXEp90tjuBbioTBcycnkMtV9qC");

                try
                {
                    HttpResponseMessage response = await client.SendAsync(message);
                    string content = await response.Content.ReadAsStringAsync();
                    DataToListForUserRating a = JsonConvert.DeserializeObject<DataToListForUserRating>(content);
                    foreach (var item in a.GetStringList())
                    {
                        CommentsCollector.Add(item);

                    }

                    if (CommentsCollector.Count == 0)
                    {
                        ListOfUsers.Add("No Comments");

                    }
                    else
                    {

                        for (int i = 0; i < a.GetStringList().Count / 3; i++)
                        {
                            string UserRating = null;
                            if (CommentsCollector[i + i + i + 1 + 1] == "1")
                            {

                                UserRating = "( Excellent )";
                            }
                            else if (CommentsCollector[i + i + i + 1 + 1] == "2")
                            {
                                UserRating = "( Good )";
                            }
                            else if (CommentsCollector[i + i + i + 1 + 1] == "3")
                            {
                                UserRating = "( Average )";
                            }
                            else if (CommentsCollector[i + i + i + 1 + 1] == "4")
                            {
                                UserRating = "( Ok )";
                            }
                            else if (CommentsCollector[i + i + i + 1 + 1] == "5")
                            {
                                UserRating = "( Bad )";
                            }
                            else
                            {
                                UserRating = "";
                            }




                            string Commenter = CommentsCollector[i + i + i] + " " + UserRating + " :  \n \t" + CommentsCollector[i + i + i + 1] ;
                            ListOfUsers.Add(Commenter);
                        }

                        listView.ItemsSource = ListOfUsers;
                    }

                    //loading2.IsVisible = false;

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



       
         async void SubmitComment(object sender, EventArgs args)
        {
            Cover.IsVisible = true;

            if (Comment.Text.Length <= 50 )
            {
                 if ( Comment.Text.Length >= 1)
            {



                ////////////////////////////////////////////////////////////////////////////////////////////////////  to check if already commented 
          
                CheckExisting.Clear();
                HttpClient client = new HttpClient();
                HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Get, "https://api.parse.com/1/classes/EmployeeRating?" + WebUtility.UrlEncode("where=" + JsonConvert.SerializeObject(new DataParserForEmployees() { Name = TheNameToComment, Username = usernameToComment })));
                message.Headers.Clear();
                message.Headers.Add("X-Parse-Application-Id", "2kWwje4PWZ980GmHQBk4EneY7DkENmlikDEZdwKt");
                message.Headers.Add("X-Parse-REST-API-Key", "3cZnB4kNlPYCChLXEp90tjuBbioTBcycnkMtV9qC");

                try
                {
                    HttpResponseMessage response = await client.SendAsync(message);
                    string content = await response.Content.ReadAsStringAsync();
                    DataToListForEmployeesForRating2 a = JsonConvert.DeserializeObject<DataToListForEmployeesForRating2>(content);
                    foreach (var item in a.GetStringList())
                    {
                        CheckExisting.Add(item);


                    }

                    if (CheckExisting.Count == 0)
                    {

                        ////////////////////////////////////////////////////////////////////////////////////////////////////  to post new rating 
                        HttpClient client2 = new HttpClient();
                        HttpRequestMessage message2 = new HttpRequestMessage(HttpMethod.Post, "https://api.parse.com/1/classes/EmployeeRating");
                        message2.Headers.Clear();
                        message2.Headers.Add("X-Parse-Application-Id", "2kWwje4PWZ980GmHQBk4EneY7DkENmlikDEZdwKt");
                        message2.Headers.Add("X-Parse-REST-API-Key", "3cZnB4kNlPYCChLXEp90tjuBbioTBcycnkMtV9qC");
                        string json = JsonConvert.SerializeObject(new DataParserForUserRating() { Name = TheNameToComment, Username = usernameToComment, Comments = Comment.Text });
                        message2.Content = new StringContent(json, Encoding.UTF8, "application/json");
                        message2.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                        HttpResponseMessage response2 = await client2.SendAsync(message2);
                        await DisplayAlert("Success", " * Your comment has been posted", "ok");
                             Cover.IsVisible = false;


                    }
                    else
                    {
                        ////////////////////////////////////////////////////////////////////////////////////////////////////  to modify current rating 
                        HttpClient client1 = new HttpClient();
                        HttpRequestMessage message1 = new HttpRequestMessage(HttpMethod.Put, "https://api.parse.com/1/classes/EmployeeRating/" + CheckExisting[0]);
                        message1.Headers.Clear();
                        message1.Headers.Add("X-Parse-Application-Id", "2kWwje4PWZ980GmHQBk4EneY7DkENmlikDEZdwKt");
                        message1.Headers.Add("X-Parse-REST-API-Key", "3cZnB4kNlPYCChLXEp90tjuBbioTBcycnkMtV9qC");
                        string json2 = JsonConvert.SerializeObject(new DataParserForUserRating() { Comments = Comment.Text });
                        message1.Content = new StringContent(json2, Encoding.UTF8, "application/json");
                        message1.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                        HttpResponseMessage response1 = await client1.SendAsync(message1);

                        await DisplayAlert("Success", " * Your original post has been modified", "ok");
                        Cover.IsVisible = false;
                    }
                }
                catch (Exception e1)
                {

                }

            }
            else
            {
                await DisplayAlert("Empty comment", "you have not written anything", "ok"); 

            }
            }
            else
            {
               await DisplayAlert("Too long !", " Your Comment must be equal or less than 50 characters", "ok");

            }
    

        }



    }
}

