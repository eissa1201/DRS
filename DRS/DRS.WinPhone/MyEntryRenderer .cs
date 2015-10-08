using DRS;
using DRS.WinPhone;
using Microsoft.Phone.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using Xamarin.Forms;
using Xamarin.Forms.Platform.WinPhone;
[assembly: ExportRenderer(typeof(EntryTitle), typeof(MyEntryRenderer))]
[assembly: ExportRenderer(typeof(ListOfCities), typeof(LabelPickerViewRenderer))]
[assembly: ExportRenderer(typeof(pressButton), typeof(pressButtonclass))]
namespace DRS.WinPhone
{
    public class MyEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement == null)
            {
                var nativePhoneTextBox = (PhoneTextBox)Control.Children[0];

                nativePhoneTextBox.Background = new SolidColorBrush(Colors.White);

                nativePhoneTextBox.TextAlignment = System.Windows.TextAlignment.Center;
            }
        }
    }

   public class LabelPickerViewRenderer : PickerRenderer
    {
        public static void Init() { }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Picker> e)
        {
            base.OnElementChanged(e);
        
            this.Control.FontSize = 30;
           // this.Control.Background = new SolidColorBrush(Colors.Black);
            this.Control.Background = new SolidColorBrush(Colors.Transparent);
            this.Control.Foreground = new SolidColorBrush(Colors.Purple);
            this.Control.BorderBrush = new SolidColorBrush(Colors.Black);

      

        }
    }


   public class pressButtonclass : ButtonRenderer
   {
       public static void Init() { }

       protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
       {
           base.OnElementChanged(e);

          // this.Control.FontSize = 30;
        //  this.Control.Background = new SolidColorBrush(Colors.Black);

           //Button.HeightRequestProperty = new s

       }
   }



    }



