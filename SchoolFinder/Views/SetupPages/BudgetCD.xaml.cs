using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace SchoolFinder.Views.SetupPages
{
    public sealed partial class BudgetCD : ContentDialog
    {
        DispatcherTimer timer = new DispatcherTimer();

        public BudgetCD()
        {
            this.InitializeComponent();
            //timer.IsEnabled = false;
            timer.Interval = new TimeSpan(0, 0, 2);
            timer.Tick += Timer_Tick;
            if (!timer.IsEnabled)
            {
                timer.Start();
            }
        }

        private void Timer_Tick(object sender, object e)
        {
            welcome.Visibility = Visibility.Collapsed;
            timer.Stop();
            content.Visibility = Visibility.Visible;
            foreach(var kid in MainMapPage.KnownKids)
            {
                KidGrid.Items.Add(kid);
            }
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {

            //MainMapPage.BudgetEntered();
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        }
    }
}
