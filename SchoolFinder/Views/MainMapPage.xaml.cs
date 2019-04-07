using SchoolFinder.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Core;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace SchoolFinder.Views
{
    public sealed partial class MainMapPage : Page
    {
        public static ObservableCollection<Kid> KnownKids = new ObservableCollection<Kid>();
        public static List<School> KnownSchools = new List<School>();
        public ObservableCollection<School> SES = new ObservableCollection<School>();
        public MainMapPage()
        {
            this.InitializeComponent();
            CoreApplicationViewTitleBar coreTitleBar = CoreApplication.GetCurrentView().TitleBar;
            coreTitleBar.ExtendViewIntoTitleBar = true;
            mainMap.Loaded += MainMap_Loaded;
            KidGridM.ItemsSource = KnownKids;

            //artifically fill up schools:

            KnownSchools.Add(new School
            {
                Name = "Little Kids",
                Address = "718 Rochford St",
                LatLon = new Geopoint(new BasicGeoposition { Latitude = 41.872669, Longitude = -87.650915 }),
                Phone = "555-555-555-5",
                SchoolType = "Elementary School",
                Website = "https://littlekidsschool.com"
            });
            KnownSchools.Add(new School
            {
                Name = "Bigger Kids",
                Address = "728 Rochford St",
                LatLon = new Geopoint(new BasicGeoposition { Latitude = 41.868404, Longitude = -87.652548 }),
                Phone = "555-565-666-5",
                SchoolType = "Middle School",
                Website = "https://middlekidsschool.com"
            });
            KnownSchools.Add(new School
            {
                Name = "Better Little Kids",
                Address = "798 Clinton St",
                LatLon = new Geopoint(new BasicGeoposition { Latitude = 41.869885, Longitude = -87.6293 }),
                Phone = "555-595-555-5",
                SchoolType = "Elementary School",
                Website = "https://betterlittlekidsschool.com"
            });
        }

        private async void MainMap_Loaded(object sender, RoutedEventArgs e)
        {
            var centre = new Geopoint(new BasicGeoposition()
            {
                Latitude = 41.874442,
                Longitude = -87.656971
            });

            await mainMap.TrySetSceneAsync(MapScene.CreateFromLocationAndRadius(centre, 1500));
            SetupPages.KidsNamesCD Kids = new SetupPages.KidsNamesCD();
            await Kids.ShowAsync();
            SetMapElements();
        }

        public static async void NamesEntered()
        {
            SetupPages.BudgetCD budget = new SetupPages.BudgetCD();
            await budget.ShowAsync();
            
        }

        public void SetMapElements()
        {
            var MyLandmarks = new List<MapElement>();

            foreach (var point in KnownSchools)
            {
                var school = new MapIcon
                {
                    Location = point.LatLon,
                    NormalizedAnchorPoint = new Point(0.5, 1.0),
                    ZIndex = 0,
                    Title = point.Name,
                    Tag = point.Name
                };
                MyLandmarks.Add(school);

            }
            //BasicGeoposition snPosition = new BasicGeoposition { Latitude = 41.873857, Longitude = -87.640664 };
            var LandmarksLayer = new MapElementsLayer
            {
                ZIndex = 1,
                MapElements = MyLandmarks
            };

            mainMap.Layers.Add(LandmarksLayer);
            mainMap.Center = KnownSchools[0].LatLon;
            mainMap.ZoomLevel = 14;
            mainMap.TrafficFlowVisible = true;
            Schools.ItemsSource = SES;
        }

        private void MainMap_MapElementClick(MapControl sender, MapElementClickEventArgs args)
        {
            SES.Clear();
            var school = KnownSchools.Find(n => n.Name.Equals(args.MapElements[0].Tag));
            SES.Add(school);
        }
    }
}
