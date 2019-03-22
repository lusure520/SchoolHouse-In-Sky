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
            Page editPage = null;
            Page donationPage = null;

            switch (Device.RuntimePlatform){
                case Device.iOS:
                    sendEmailPage = new NavigationPage(new SendEmail())
                    {
                        Title = "Send Email"
                    };
                    editPage = new NavigationPage(new Home())
                    {
                        Title = "Edit"
                    };
                    donationPage = new NavigationPage(new Donation())
                    {
                        Title = "Donate"
                    };
                    break;
                default:
                    sendEmailPage = new SendEmail();
                    editPage = new Home();
                    donationPage = new Donation();
                    break;
            }
            Children.Add(sendEmailPage);
            Children.Add(editPage);
            Children.Add(donationPage);
            Title = Children[0].Title;
        }

        //protected override void OnCurrentPageChanged()
        //{
        //    base.OnCurrentPageChanged();
        //    Title = CurrentPage?.Title ?? string.Empty;
        //}
    }
}

