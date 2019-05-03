using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Forms.Maps;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using Plugin.Geolocator;

namespace SendEmail
{
    public partial class MapPage : ContentPage
    {
        public MapPage()
        {
            InitializeComponent();
        }

        bool busy;
        async void ButtonPermission_OnClicked(object sender, EventArgs e)
        {
            if (busy)
                return;


            busy = true;
            ((Button)sender).IsEnabled = false;

            var status = PermissionStatus.Unknown;
            switch (((Button)sender).StyleId)
            {
                case "LocationAlways":
                    status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.LocationAlways);
                    break;
                case "LocationWhenInUse":
                    status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.LocationWhenInUse);
                    break;
            }

            await DisplayAlert("Results", status.ToString(), "OK");

            if (status != PermissionStatus.Granted)
            {
                try
                {

                    switch (((Button)sender).StyleId)
                    {
                        case "LocationAlways":
                            status = (await CrossPermissions.Current.RequestPermissionsAsync(Permission.LocationAlways))[Permission.LocationAlways];
                            break;
                        case "LocationWhenInUse":
                            status = (await CrossPermissions.Current.RequestPermissionsAsync(Permission.LocationWhenInUse))[Permission.LocationWhenInUse];
                            break;
                    }
                    await DisplayAlert("Results", status.ToString(), "OK");
                }
                catch (Exception ex)
                {

                    await DisplayAlert("Results", ex.Message, "OK");
                }

            }

            busy = false;
            ((Button)sender).IsEnabled = true;
        }

        async void Button_OnClicked(object sender, EventArgs e)
        {
            if (busy)
                return;

            busy = true;
            ((Button)sender).IsEnabled = false;

            try
            {
                var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Location);
                if (status != PermissionStatus.Granted)
                {
                    if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.Location))
                    {
                        await DisplayAlert("Need location", "Gunna need that location", "OK");
                    }

                    var results = await CrossPermissions.Current.RequestPermissionsAsync(Permission.Location);
                    status = results[Permission.Location];
                }

                if (status == PermissionStatus.Granted)
                {
                    var results = await CrossGeolocator.Current.GetPositionAsync();
                    var map = new Map(MapSpan.FromCenterAndRadius(new Position(results.Latitude, results.Longitude), Distance.FromKilometers(0.2)));
                    map.MapType = MapType.Hybrid;
                    map.IsShowingUser = true;
                    map.HeightRequest = 100;
                    map.WidthRequest = 960;
                    map.VerticalOptions = LayoutOptions.FillAndExpand;

                    var stack = new StackLayout { Spacing = 0 };
                    stack.Children.Add(map);
                    Content = stack;

                    var position = new Position(37, -122); // Latitude, Longitude
                    var pin = new Pin
                    {
                        Type = PinType.Place,
                        Position = position,
                        Label = "Project X",
                        //Address = "custom detail info"
                    };
                    map.Pins.Add(pin);

                    pin.Clicked += (object epin, EventArgs pina) =>
                    {
                        var p = sender as Pin;
                        var piny = new Pin
                        {
                            Type = PinType.Place,
                            Position = new Position(38, -122),
                        };
                    };


                    LabelGeolocation.Text = "Lat: " + results.Latitude + " Long: " + results.Longitude;
                }
                else if (status != PermissionStatus.Unknown)
                {
                    await DisplayAlert("Location Denied", "Can not continue, try again.", "OK");
                }
            }
            catch (Exception ex)
            {

                LabelGeolocation.Text = "Error: " + ex;
            }

            ((Button)sender).IsEnabled = true;
            busy = false;
        }


    }
}
