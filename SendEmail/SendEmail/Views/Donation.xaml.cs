using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace SendEmail.Views
{
    public partial class Donation : ContentPage
    {
        public Donation()
        {
            InitializeComponent();

            var moneys = new List<String>
            {
                "$35",
                "$70",
                "$105",
                "Other"
            };
            money.ItemsSource = moneys;

            var times = new List<String>
            {
                "One time",
                "Weekly",
                "Monthly",
                "Yearly"
            };
            donation_time.ItemsSource = times; 
        }

        private void OnPickerSelectedIndexChanged(object sender, EventArgs e)
        {
            Picker picker = sender as Picker;
            var selectedItem = picker.SelectedItem; // This is the model selected in the picker
            if(selectedItem.Equals("Other"))
            {
                DisplayAlert("Notification", "Develop later!", "OK");
            }

        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            string url = "";

            //string business = "my@paypalemail.com";  // your paypal email
            //string description = "Donation";            // '%20' represents a space. remember HTML!
            //string country = "AU";                  // AU, US, etc.
            //string currency = "AUD";                 // AUD, USD, etc.

        //    url += "https://www.paypal.com/cgi-bin/webscr" +
        //        "?cmd=" + "_donations" +
        //        "&business=" + business +
        //        "&lc=" + country +
        //        "&item_name=" + description +
        //        "&currency_code=" + currency +
        //        "&bn=" + "PP%2dDonationsBF";

        //https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=UYE2TU3LV3SGS&source=url

            url = "https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=UYE2TU3LV3SGS&source=url";
            //System.Diagnostics.Process.Start(url);
            Device.OpenUri(new Uri(url));
            
        }
    }
}
