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
    
    
    public partial class Menu : ContentPage {
        
        private Label use;
        
        private Button Find;
        
        private Button Create;
        
        private Button Edit;
        
        private Button options;
        
        private Button Out;
        
        private void InitializeComponent() {
            this.LoadFromXaml(typeof(Menu));
            use = this.FindByName<Label>("use");
            Find = this.FindByName<Button>("Find");
            Create = this.FindByName<Button>("Create");
            Edit = this.FindByName<Button>("Edit");
            options = this.FindByName<Button>("options");
            Out = this.FindByName<Button>("Out");
        }
    }
}
