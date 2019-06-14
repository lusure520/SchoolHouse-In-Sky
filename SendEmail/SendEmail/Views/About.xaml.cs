using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SendEmail
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class About : ContentPage
    {
        //Binding String for the About Us Page.
        public string AboutTitle { get; set; } = "About us";
        public string SecondTitle { get; set; } = "Ed begins it all";
        public string AboutDetails { get; set; } = "Sir Edmund Hillary (20 July 1919 – 11 January 2008) was a New Zealand mountaineer, explorer and philanthropist. On 29 May 1953, Hillary and Tenzing Norgay became the first climbers to reach the summit of Mount Everest.\n\u00a0\nFollowing his ascent of Everest, Sir Ed devoted his life to helping the people of Nepal through the Himalayan Trust,\n\u00a0\nSir Ed founded the Himalayan Trust in the 1960s. Thanks to supporters in New Zealand and across the world, we continue his work to bring quality education, safe water, and better healthcare to communities living in the Everest region of Nepal.\n\u00a0\nTo Sir Ed, his greatest achievement was not climbing Everest, but his help for the people of Nepal through the Himalayan Trust.";
        public string SecondDetails { get; set; } = "It all began in the early 1960s when Sir Ed asked a Sherpa: “If there was anything I could do for the Sherpa people, what do you think that would be?”\n\u00a0\nThe Sherpa replied: “Our children have eyes but they are blind and cannot see. We would like you to open their eyes by building a school in our village.”\n\u00a0\nThis touched Sir Ed’s heart and he immediately set about building the first school in Khumjung. He went on to build schools, hospitals and health clinics across the Solukhumbu region in the foothills of Everest.";
        public About()
        {
            InitializeComponent();
            BindingContext = this;
        }
    }
}
