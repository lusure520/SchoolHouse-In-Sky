using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace SendEmail
{
    public partial class About : ContentPage
    {
        public string Contents { get; set; } = "Need Contents from client!";
        public About()
        {
            InitializeComponent();
            BindingContext = this;
        }
    }
}
