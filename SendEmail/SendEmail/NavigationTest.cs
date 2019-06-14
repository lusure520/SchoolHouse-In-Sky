﻿using System;
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

            //creat navigation bar on Android and IOS Device.
            switch (Device.RuntimePlatform){
                case Device.iOS:
                    sendEmailPage = new NavigationPage(new SendEmail())
                    {
                        Title = "Newsletter",
                        Icon = "email.png"

                    };
                    donationPage = new NavigationPage(new Donation())
                    {
                        Title = "Donate",
                        Icon = "donate.png"
                    };
                    mapPage = new NavigationPage(new MapPage())
                    {
                        Title = "Explore Nepal",
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
                    mapPage = new NavigationPage(new MapPage())
                    {
                        Title = "Explore Nepal"
                    };
                    aboutPage = new About();
                    break;
            }
            Children.Add(sendEmailPage);//link Newsletter page to navigation bar.
            Children.Add(aboutPage);//link About Us page to navigation bar.
            Children.Add(mapPage);//link Map page to navigation bar.
            Children.Add(donationPage);//link Donation page to navigation bar.
            Title = Children[0].Title;//set first children page with defaul page.
        }

        protected override void OnCurrentPageChanged()
        {
            base.OnCurrentPageChanged();
            Title = CurrentPage?.Title ?? string.Empty;
        }

        public static implicit operator NavigationPage(NavigationTest v)
        {
            throw new NotImplementedException();
        }
    }
}

