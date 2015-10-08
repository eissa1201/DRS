using System;
using Xamarin.Forms;
using System.Runtime.CompilerServices;
using System.Threading;

[assembly: Xamarin.Forms.Dependency(typeof(DRS.WinPhone.Localize))]


namespace DRS.WinPhone
{
    public class Localize : DRS.ILocalize
    {
        public void SetLocale()
        {
            //
        }

        public System.Globalization.CultureInfo GetCurrentCultureInfo()
        {
            return System.Threading.Thread.CurrentThread.CurrentUICulture;
        }
    }
}

