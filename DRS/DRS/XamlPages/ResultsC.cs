using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace DRS
{


    public class DoctorsValues
    {
        public DoctorsValues(string name, string position, string image, ICommand Command)
        {
            this.Name = name;
            this.Position = position;
            this.Image = image;
            this.ItemTappedCommand = Command;

        }

        public string Name { private set; get; }

        public string Position { private set; get; }

        public string Image { private set; get; }

        public ICommand ItemTappedCommand { private set; get; }
    };
    public class ResultsC : ContentPage
    {

        public ResultsC(List<string> DoctorsInformation, String Username)
        {
          
            List<DoctorsValues> Doctors = new List<DoctorsValues>();

            for (int i = 0; i < DoctorsInformation.Count / 4; i++)
            {
                Doctors.Add(new DoctorsValues(DoctorsInformation[i + i + i], DoctorsInformation[i + i + i + 1], DoctorsInformation[i + i + i + 2], new Command<string>((name) =>
                {

                    GoToRatingPage(name.ToString(), Username);

                })


                ));


            }


            Label header = new Label
            {
                Text = "Doctors",
                Font = Font.SystemFontOfSize(35),
                HorizontalOptions = LayoutOptions.Center
            };


            var cell = new DataTemplate(typeof(ImageCell));

            cell.SetBinding(TextCell.TextProperty, "Name");
            cell.SetBinding(TextCell.DetailProperty, new Binding("Position", stringFormat: "{0}"));
            cell.SetBinding(ImageCell.ImageSourceProperty, "Image");
            cell.SetBinding(TextCell.CommandProperty, "ItemTappedCommand");
           cell.SetBinding(TextCell.CommandParameterProperty, "Name");



            ListView listView = new ListView
            {
                ItemsSource = Doctors,
                ItemTemplate = cell,
              

               


            };


            this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);


            this.Content = new StackLayout
            {
                Children = {
				header,
				listView
			}
            };


        }
        async void GoToRatingPage(string DoctorsName, string User)
        {
            await Navigation.PushAsync(new DoctorRating(DoctorsName, User));
        }

    }
}