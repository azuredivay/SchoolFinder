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
    public sealed partial class KidsNamesCD : ContentDialog
    {
        public KidsNamesCD()
        {
            this.InitializeComponent();
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            foreach(var kid in KidsList.Items)
            {
                var vals = kid.ToString().Split(':');
                MainMapPage.KnownKids.Add(new Models.Kid
                {
                    Age = float.Parse(vals[1]), Name = vals[0]
                });
            }
            Hide();
            MainMapPage.NamesEntered();
            
        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            KidsList.Items.Add($"{KidName.Text}:{age.Text}");
            KidName.Text = string.Empty;
        }

        private void KidsList_ItemClick(object sender, ItemClickEventArgs e)
        {
           
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
