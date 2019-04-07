using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;


namespace SchoolFinder.Views.SetupPages
{

    public sealed partial class MainPage : Page
    {
        DispatcherTimer timer = new DispatcherTimer();
        private void Timer_Tick(object sender, object e)
        {
            if (timer.IsEnabled)
            {
                timer.Stop();
                PBL.Visibility = Visibility.Collapsed;
                //Views.SetupPages.KidsNamesCD infoPanel = new Views.SetupPages.KidsNamesCD();
                //infoPanel.ShowAsync();
                //App.rootFrame.Navigate(typeof(Shell));
                Frame.Navigate(typeof(MainMapPage));
            }
        }
        public MainPage()
        {
            this.InitializeComponent();
            CoreApplication.GetCurrentView().TitleBar.ExtendViewIntoTitleBar = true;
            PBL.Width = Window.Current.Bounds.Width;
            
        }

        public void GoToMain()
        {
            PBL.Visibility = Visibility.Visible;
            start.IsEnabled = false;
            timer.Interval = new TimeSpan(0, 0, 0);
            timer.Tick += Timer_Tick;
            if (!timer.IsEnabled)
            {
                timer.Start();
            }
        }
    }
}
