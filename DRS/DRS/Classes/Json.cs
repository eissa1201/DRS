using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace DRS
{
    class Json
    {


    }
    public class DataParser
    {
        [JsonProperty(PropertyName = "Username", NullValueHandling = NullValueHandling.Ignore)]
        public string Username { get; set; }

        [JsonProperty(PropertyName = "createdAt", NullValueHandling = NullValueHandling.Ignore)]
        public string createdAt { get; set; }
        [JsonProperty(PropertyName = "objectId", NullValueHandling = NullValueHandling.Ignore)]
        public string objectId { get; set; }
        [JsonProperty(PropertyName = "updatedAt", NullValueHandling = NullValueHandling.Ignore)]
        public string updatedAt { get; set; }

        [JsonProperty(PropertyName = "Password", NullValueHandling = NullValueHandling.Ignore)]
        public string Password { get; set; }

        [JsonProperty(PropertyName = "PhoneNumber", NullValueHandling = NullValueHandling.Ignore)]
        public string PhoneNumber { get; set; }

        [JsonProperty(PropertyName = "Email", NullValueHandling = NullValueHandling.Ignore)]
        public string Email { get; set; }

        public override string ToString()
        {
            return Username;
        }

    }

    ////////////////////////////////////////////////////////////////// seprate 



    public class DataToList
    {
        [JsonProperty(PropertyName = "results")]
        public List<DataParser> results { get; set; }



        public List<string> GetStringList()
        {
            List<string> resultList = new List<string>();
        
            foreach (var item in results)
            {
                resultList.Add(item.Username);
                resultList.Add(item.Email);
                resultList.Add(item.Password);
                resultList.Add(item.PhoneNumber);
                resultList.Add(item.objectId);
            }
            return resultList;
        }

    }



    public class DataParserForUserRating
    {
        [JsonProperty(PropertyName = "Name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "Username", NullValueHandling = NullValueHandling.Ignore)]
        public string Username { get; set; }

        [JsonProperty(PropertyName = "Comments", NullValueHandling = NullValueHandling.Ignore)]
        public string Comments { get; set; }

        [JsonProperty(PropertyName = "createdAt", NullValueHandling = NullValueHandling.Ignore)]
        public string createdAt { get; set; }

        [JsonProperty(PropertyName = "objectId", NullValueHandling = NullValueHandling.Ignore)]
        public string objectId { get; set; }

        [JsonProperty(PropertyName = "updatedAt", NullValueHandling = NullValueHandling.Ignore)]
        public string updatedAt { get; set; }


        [JsonProperty(PropertyName = "Rating", NullValueHandling = NullValueHandling.Ignore)]
        public int Rating { get; set; }

        public override string ToString()
        {
            return Name;
        }

    }









    public class DataParserForEmployees
    {
        [JsonProperty(PropertyName = "Images", NullValueHandling = NullValueHandling.Ignore)]
        public string Images { get; set; }


        [JsonProperty(PropertyName = "Username", NullValueHandling = NullValueHandling.Ignore)]
        public string Username { get; set; }

        [JsonProperty(PropertyName = "Name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "createdAt", NullValueHandling = NullValueHandling.Ignore)]
        public string createdAt { get; set; }
        [JsonProperty(PropertyName = "objectId", NullValueHandling = NullValueHandling.Ignore)]
        public string objectId { get; set; }
        [JsonProperty(PropertyName = "updatedAt", NullValueHandling = NullValueHandling.Ignore)]
        public string updatedAt { get; set; }

        [JsonProperty(PropertyName = "Hospital", NullValueHandling = NullValueHandling.Ignore)]
        public string Hospital { get; set; }

        [JsonProperty(PropertyName = "Specialty", NullValueHandling = NullValueHandling.Ignore)]
        public string Specialty { get; set; }

        [JsonProperty(PropertyName = "City", NullValueHandling = NullValueHandling.Ignore)]
        public string City { get; set; }

        [JsonProperty(PropertyName = "OverallRating", NullValueHandling = NullValueHandling.Ignore)]
        public string OverallRating { get; set; }

        public override string ToString()
        {
            return Name;
        }

    }


    ////////////////////////////////////////////////////////////////// seprate 


    public class DataParserForCity
    {
        [JsonProperty(PropertyName = "City", NullValueHandling = NullValueHandling.Ignore)]
        public string City { get; set; }

        [JsonProperty(PropertyName = "createdAt", NullValueHandling = NullValueHandling.Ignore)]
        public string createdAt { get; set; }
        [JsonProperty(PropertyName = "objectId", NullValueHandling = NullValueHandling.Ignore)]
        public string objectId { get; set; }
        [JsonProperty(PropertyName = "updatedAt", NullValueHandling = NullValueHandling.Ignore)]
        public string updatedAt { get; set; }


        public override string ToString()
        {
            return City;
        }

    }
    ////////////////////////////////////////////////////////////////// seprate 
    public class DataParserForHospital
    {
        [JsonProperty(PropertyName = "Hospital", NullValueHandling = NullValueHandling.Ignore)]
        public string Hospital { get; set; }

        [JsonProperty(PropertyName = "City", NullValueHandling = NullValueHandling.Ignore)]
        public string City { get; set; }

        [JsonProperty(PropertyName = "createdAt", NullValueHandling = NullValueHandling.Ignore)]
        public string createdAt { get; set; }
        [JsonProperty(PropertyName = "objectId", NullValueHandling = NullValueHandling.Ignore)]
        public string objectId { get; set; }
        [JsonProperty(PropertyName = "updatedAt", NullValueHandling = NullValueHandling.Ignore)]
        public string updatedAt { get; set; }


        public override string ToString()
        {
            return Hospital;
        }

    }
    ////////////////////////////////////////////////////////////////// seprate 
    public class DataParserForSpecialty
    {
        [JsonProperty(PropertyName = "Specialty", NullValueHandling = NullValueHandling.Ignore)]
        public string Specialty { get; set; }

        [JsonProperty(PropertyName = "createdAt", NullValueHandling = NullValueHandling.Ignore)]
        public string createdAt { get; set; }
        [JsonProperty(PropertyName = "objectId", NullValueHandling = NullValueHandling.Ignore)]
        public string objectId { get; set; }
        [JsonProperty(PropertyName = "updatedAt", NullValueHandling = NullValueHandling.Ignore)]
        public string updatedAt { get; set; }


        public override string ToString()
        {
            return Specialty;
        }

    }

    /// <summary>
    /// /////////////////////////////////////////////////////////////////////////////////////////////
    /// </summary>

    public class DataToListForEmployees
    {
        [JsonProperty(PropertyName = "results")]
        public List<DataParserForEmployees> results { get; set; }



        public List<string> GetStringList()
        {
            List<string> resultList = new List<string>();

            foreach (var item in results)
            {
                resultList.Add(item.Name);
                resultList.Add(item.Specialty);
                resultList.Add(item.Images);

            }
            return resultList;
        }

    }


    public class DataToListForEmployeesForRating2
    {
        [JsonProperty(PropertyName = "results")]
        public List<DataParserForUserRating> results { get; set; }



        public List<string> GetStringList()
        {
            List<string> resultList = new List<string>();

            foreach (var item in results)
            {
                resultList.Add(item.objectId);
            }
            return resultList;
        }

    }




    public class DataToListForEmployeesForRating
    {
        [JsonProperty(PropertyName = "results")]
        public List<DataParserForEmployees> results { get; set; }



        public List<string> GetStringList()
        {
            List<string> resultList = new List<string>();

            foreach (var item in results)
            {
                resultList.Add(item.Name);
                resultList.Add(item.City);
                resultList.Add(item.Hospital);
                resultList.Add(item.OverallRating);
                resultList.Add(item.Specialty);
            }
            return resultList;
        }

    }
    /// <summary>
    /// //////////////////////////////////////
    /// </summary>
    public class DataToListForCity
    {
        [JsonProperty(PropertyName = "results")]
        public List<DataParserForCity> results { get; set; }



        public List<string> GetStringList()
        {
            List<string> resultList = new List<string>();

            foreach (var item in results)
            {
                resultList.Add(item.City);

            }
            return resultList;
        }

    }
    /// <summary>
    /// //////////////////////////////////////
    /// </summary>
    public class DataToListForHospital
    {
        [JsonProperty(PropertyName = "results")]
        public List<DataParserForHospital> results { get; set; }



        public List<string> GetStringList()
        {
            List<string> resultList = new List<string>();

            foreach (var item in results)
            {
                resultList.Add(item.Hospital);

            }
            return resultList;
        }

    }
    public class DataToListForHospital2
    {
        [JsonProperty(PropertyName = "results")]
        public List<DataParserForHospital> results { get; set; }



        public List<string> GetStringList()
        {
            List<string> resultList = new List<string>();

            foreach (var item in results)
            {
                resultList.Add(item.City);

            }
            return resultList;
        }

    }


    public class DataToListForUserRating
    {
        [JsonProperty(PropertyName = "results")]
        public List<DataParserForUserRating> results { get; set; }



        public List<string> GetStringList()
        {
            List<string> resultList = new List<string>();

            foreach (var item in results)
            {
                resultList.Add(item.Username);
                resultList.Add(item.Comments);
                resultList.Add(item.Rating.ToString());

            }
            return resultList;
        }

    }





    /// <summary>
    /// //////////////////////////////////////
    /// </summary>
    public class DataToListForSpecialty
    {
        [JsonProperty(PropertyName = "results")]
        public List<DataParserForSpecialty> results { get; set; }



        public List<string> GetStringList()
        {
            List<string> resultList = new List<string>();

            foreach (var item in results)
            {
                resultList.Add(item.Specialty);

            }
            return resultList;
        }

    }
    
}
