using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SendEmail.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Donation : ContentPage
    {
        public string ToolsDetails { get; set; } = "High in the Everest region of Nepal, schools are very poorly funded with little in the way of resources. Reading books and school stationery are luxury items for families and schools. Your gift could provide early literacy books and essential stationary for 10 children.";
        public string MedicalDetails { get; set; } = "The Himalayan Trust is working to improve the quality of local health care in remote Nepal. your gift could provide one month of midwifery training for a local health worker in the remote district of Bung, giving new babies the best possible start to life.";
        public string TeacherDetails { get; set; } = "Getting a good start in reading and writing is an essential foundation for future learning. Yet literacy levels throughout Nepal remain low, preventing too many bright, keen and deserving young people from fulfilling their potential. Your gift will empower teachers in remote schools to teach reading and writing more effectively.";
        public string WaterDetails { get; set; } = "Many families in the remote Solukhumbu region walk long distances to collect water, often from unsafe sources. Your gift could contribute to the construction of an earthquake-resistant water system, fitted with a filtration system, to provide homes with safe, clean drinking water and to irrigate crops.";
        public Donation()
        {
            InitializeComponent();
            BindingContext = this;
        }


        void Handle_Clicked(object sender, System.EventArgs e)
        {
            string url = "";
            url = "https://www.paypal.com/cgi-bin/webscr?cmd=_s-xclick&hosted_button_id=UYE2TU3LV3SGS&source=url";
            Device.OpenUri(new Uri(url));
            
        }
    }
}
