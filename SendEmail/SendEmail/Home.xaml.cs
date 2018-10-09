using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SendEmail
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home : ContentPage
    {
        public string MissionStatement { get; set; } = "Mission statement to be edited";
        public string HistoryStatement { get; set; } = "History statement to be edited";

        public Home()
        {
            InitializeComponent();
            BindingContext = this;
        }

        


        private void Button_Clicked(object sender, EventArgs e)
        {
            //DisplayAlert("Success", "Button Clicked", "Exit");
            Navigation.PushAsync(new EditPage());
        }
    }
}