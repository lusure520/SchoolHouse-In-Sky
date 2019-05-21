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
using SendEmail.Views;

namespace SendEmail
{
    public partial class MapPage : ContentPage
    {
        public MapPage()
        {
            InitializeComponent();
        }

        void Handle_Clicked(object sender, System.EventArgs e)
        {
            switch (((Button)sender).StyleId)
            {
                case "Airport":
                    Navigation.PushAsync(new ProjectDetails("Airport"));
                    break;
                case "KhumjungSchool":
                    Navigation.PushAsync(new ProjectDetails("KhumjungSchool"));
                    break;
                case "LuklaDrinkingWater":
                    Navigation.PushAsync(new ProjectDetails("LuklaDrinkingWater"));
                    break;
                case "KundeHospital":
                    Navigation.PushAsync(new ProjectDetails("KundeHospital"));
                    break;
                case "ChaurikharkaSchool":
                    Navigation.PushAsync(new ProjectDetails("ChaurikharkaSchool"));
                    break;
                case "MuseyDrinkingWater":
                    Navigation.PushAsync(new ProjectDetails("MuseyDrinkingWater"));
                    break;
                case "ThameSchool":
                    Navigation.PushAsync(new ProjectDetails("ThameSchool"));
                    break;
                case "ShreeHimalayanPrimarySchool":
                    Navigation.PushAsync(new ProjectDetails("ShreeHimalayanPrimarySchool"));
                    break;
                case "MonjoSchool":
                    Navigation.PushAsync(new ProjectDetails("MonjoSchool"));
                    break;
                case "SagarmathaNationalPark":
                    Navigation.PushAsync(new ProjectDetails("SagarmathaNationalPark"));
                    break;
                case "TheYetiScalp":
                    Navigation.PushAsync(new ProjectDetails("TheYetiScalp"));
                    break;
                case "EverestAvalanche":
                    Navigation.PushAsync(new ProjectDetails("EverestAvalanche"));
                    break;
                case "KhumjungWater":
                    Navigation.PushAsync(new ProjectDetails("KhumjungWater"));
                    break;
                case "TengbocheMonastery":
                    Navigation.PushAsync(new ProjectDetails("TengbocheMonastery"));
                    break;
                case "PhortseSchool":
                    Navigation.PushAsync(new ProjectDetails("PhortseSchool"));
                    break;
            }
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

                    var pin1 = new Pin
                    {
                        Type = PinType.Place,
                        Position = new Position(27.6900444, 86.7317329),
                        Label = "Hillary-Tenzing Airport",
                    };
                    map.Pins.Add(pin1);

                    var pin2 = new Pin
                    {
                        Type = PinType.Place,
                        Position = new Position(27.8203184, 86.7166543),
                        Label = "Khumjung School",
                    };
                    map.Pins.Add(pin2);

                    var pin3 = new Pin
                    {
                        Type = PinType.Place,
                        Position = new Position(27.6899884, 86.729604),
                        Label = "Lukla Drinking Water Project",
                    };
                    map.Pins.Add(pin3);

                    var pin4 = new Pin
                    {
                        Type = PinType.Place,
                        Position = new Position(27.8237344, 86.7047882),
                        Label = "Kunde Hospital",
                    };
                    map.Pins.Add(pin4);

                    var pin5 = new Pin
                    {
                        Type = PinType.Place,
                        Position = new Position(27.6964303, 86.7205072),
                        Label = "Chaurikharka School",
                    };
                    map.Pins.Add(pin5);

                    var pin6 = new Pin
                    {
                        Type = PinType.Place,
                        Position = new Position(27.6968699, 86.7174107),
                        Label = "Musey Drinking Water Project",
                    };
                    map.Pins.Add(pin6);

                    var pin7 = new Pin
                    {
                        Type = PinType.Place,
                        Position = new Position(27.8301751, 86.6489022),
                        Label = "Thame School",
                    };
                    map.Pins.Add(pin7);

                    var pin8 = new Pin
                    {
                        Type = PinType.Place,
                        Position = new Position(27.8034675, 86.7123172),
                        Label = "Shree Himalayan Primary School, Namche",
                    };
                    map.Pins.Add(pin8);

                    var pin9 = new Pin
                    {
                        Type = PinType.Place,
                        Position = new Position(27.987445, 86.8762079),
                        Label = "Everest Avalanche on Popcorn Field",
                    };
                    map.Pins.Add(pin9);

                    var pin10 = new Pin
                    {
                        Type = PinType.Place,
                        Position = new Position(27.8245459, 86.7161815),
                        Label = "Khumjung Water Project",
                    };
                    map.Pins.Add(pin10);

                    var pin11 = new Pin
                    {
                        Type = PinType.Place,
                        Position = new Position(27.772655, 86.7218092),
                        Label = "Monjo School",
                    };
                    map.Pins.Add(pin11);

                    var pin12 = new Pin
                    {
                        Type = PinType.Place,
                        Position = new Position(27.8427756, 86.7617098),
                        Label = "Tengboche Monastery",
                    };
                    map.Pins.Add(pin12);

                    var pin13 = new Pin
                    {
                        Type = PinType.Place,
                        Position = new Position(27.8518312, 86.7473996),
                        Label = "Phortse School",
                    };
                    map.Pins.Add(pin13);

                    var pin14 = new Pin
                    {
                        Type = PinType.Place,
                        Position = new Position(27.773707, 86.7222946),
                        Label = "Sagarmatha National Park",
                    };
                    map.Pins.Add(pin14);

                    var pin15 = new Pin
                    {
                        Type = PinType.Place,
                        Position = new Position(27.8252767, 86.7160495),
                        Label = "The Yeti Scalp",
                    };
                    map.Pins.Add(pin15);


                    /*pin1.Clicked += (object epin, EventArgs pina) =>
                    {
                        var p = sender as Pin;
                        var piny = new Pin
                        {
                            Type = PinType.Place,
                            Position = new Position(38, -122),
                        };
                    }; */

                    await DisplayAlert("Location Detail", "Lat: " + results.Latitude + " Long: " + results.Longitude, "OK");
                    //LabelGeolocation.Text = "Lat: " + results.Latitude + " Long: " + results.Longitude;
                }
                else if (status != PermissionStatus.Unknown)
                {
                    await DisplayAlert("Location Denied", "Can not continue, try again.", "OK");
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Location Error", ex.ToString(), "OK");
                //LabelGeolocation.Text = "Error: " + ex;
            }

            ((Button)sender).IsEnabled = true;
            busy = false;
        }


    }
}
