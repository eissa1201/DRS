using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using DRS.Droid;
using DRS;
[assembly: ExportRenderer(typeof(EntryTitle), typeof(MyEntryRenderer))]
[assembly: ExportRenderer(typeof(ListOfCities), typeof(LabelPickerViewRenderer))]
namespace DRS.Droid
{
    public class MyEntryRenderer : EntryRenderer
    {
        // Override the OnElementChanged method so we can tweak this renderer post-initial setup
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                // do whatever you want to the textField here!
               Control.SetBackgroundColor(global::Android.Graphics.Color.Transparent);
               Control.SetTextColor(global::Android.Graphics.Color.Black);

            }
        }
    }
    public class LabelPickerViewRenderer : PickerRenderer
    {
        // Override the OnElementChanged method so we can tweak this renderer post-initial setup
        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                // do whatever you want to the textField here!
              Control.SetBackgroundColor(global::Android.Graphics.Color.Transparent);
              Control.SetTextColor(global::Android.Graphics.Color.Black);
              
            }
        }
    }

   
}