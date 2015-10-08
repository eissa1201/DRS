using DRS.iOS;
using System;
using System.Collections.Generic;
using System.Text;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
[assembly: ExportRenderer(typeof(DRS.EntryTitle), typeof(MyEntryRenderer))]

namespace DRS.iOS
{
    public class MyEntryRenderer : EntryRenderer
    {
        // Override the OnElementChanged method so we can tweak this renderer post-initial setup
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {   // perform initial setup
                // do whatever you want to the UITextField here!
                Control.BackgroundColor = UIColor.White;
               // Control.BorderStyle     = UITextBorderStyle.Line;
                Control.TextAlignment   = UITextAlignment.Center;
               

            }
        }
    }
}