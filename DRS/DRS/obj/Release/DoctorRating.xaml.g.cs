//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DRS {
    using System;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;
    
    
    public partial class DoctorRating : ContentPage {
        
        private Label Information;
        
        private ActivityIndicator loading;
        
        private Label RatingLable;
        
        private global::DRS.ListOfCities Rating;
        
        private Entry Comment;
        
        private ActivityIndicator PostingComment;
        
        private ListView listView;
        
        private void InitializeComponent() {
            this.LoadFromXaml(typeof(DoctorRating));
            Information = this.FindByName<Label>("Information");
            loading = this.FindByName<ActivityIndicator>("loading");
            RatingLable = this.FindByName<Label>("RatingLable");
            Rating = this.FindByName<global::DRS.ListOfCities>("Rating");
            Comment = this.FindByName<Entry>("Comment");
            PostingComment = this.FindByName<ActivityIndicator>("PostingComment");
            listView = this.FindByName<ListView>("listView");
        }
    }
}
