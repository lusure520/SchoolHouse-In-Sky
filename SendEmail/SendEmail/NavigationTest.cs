using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SendEmail
{
    public class NavigationTest : TabbedPage
    {
       

        public NavigationTest()
        {
        
            Page sendEmailPage = null;
            Page editPage = null;
           
            switch(Device.RuntimePlatform){
                case Device.iOS:
                    sendEmailPage = new NavigationPage(new SendEmail())
                    {
                        Title = "Send Email"
                    };
                    editPage = new NavigationPage(new Home())
                    {
                        Title = "Edit"
                    };
                    break;
                default:
                    sendEmailPage = new SendEmail();
                    editPage = new Home();
                    break;
            }
        


            Children.Add(sendEmailPage);
            Children.Add(editPage);
            Title = Children[0].Title;
        }

        protected override void OnCurrentPageChanged()
        {
            base.OnCurrentPageChanged();
            Title = CurrentPage?.Title ?? string.Empty;
        }
    }
}

