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
    
    
    public partial class Profile : ContentPage {
        
        private global::DRS.EntryTitle Username;
        
        private global::DRS.EntryTitle Email;
        
        private global::DRS.EntryTitle Password;
        
        private global::DRS.EntryTitle Phonenumber;
        
        private void InitializeComponent() {
            this.LoadFromXaml(typeof(Profile));
            Username = this.FindByName<global::DRS.EntryTitle>("Username");
            Email = this.FindByName<global::DRS.EntryTitle>("Email");
            Password = this.FindByName<global::DRS.EntryTitle>("Password");
            Phonenumber = this.FindByName<global::DRS.EntryTitle>("Phonenumber");
        }
    }
}
