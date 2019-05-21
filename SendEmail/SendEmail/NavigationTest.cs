using System;
using System.Threading.Tasks;
using SendEmail.Views;
using Xamarin.Forms;

namespace SendEmail
{
    public class NavigationTest : TabbedPage
    {
        public NavigationTest()
        {
        
            Page sendEmailPage = null;
            Page donationPage = null;
            Page aboutPage = null;
            Page mapPage = null;

            switch (Device.RuntimePlatform){
                case Device.iOS:
                    sendEmailPage = new NavigationPage(new SendEmail())
                    {
                        Title = "Send Email",
                        Icon = "email.png"
                    };
                    donationPage = new NavigationPage(new Donation())
                    {
                        Title = "Donate",
                        Icon = "donate.png"
                    };
                    mapPage = new NavigationPage(new MapPage())
                    {
                        Title = "Project Details",
                        Icon = "map.png"
                    };
                    aboutPage = new NavigationPage(new About())
                    {
                        Title = "About Us",
                        Icon = "aboutUs.png"
                    };
                    break;
                default:
                    sendEmailPage = new SendEmail();
                    donationPage = new Donation();
                    mapPage = new MapPage();
                    aboutPage = new About();
                    break;
            }
            Children.Add(aboutPage);
            Children.Add(sendEmailPage);
            Children.Add(mapPage);
            Children.Add(donationPage);
            Title = Children[0].Title;
        }

        protected override void OnCurrentPageChanged()
        {
            base.OnCurrentPageChanged();
            Title = CurrentPage?.Title ?? string.Empty;
        }
    }
}

