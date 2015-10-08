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
    public class App : Application
    {
        public App()
        {

            MainPage = GetMainPage();
        }

        public Page GetMainPage()
        {
            return new NavigationPage(new WelcomePage());
        }

    }
}
