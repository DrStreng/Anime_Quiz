using Animu.ViewModel;
using NotificationsExtensions.TileContent;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Notifications;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Animu.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class LiveTitleChange : Page
    {
        public LiveTitleChange()
        {
            this.InitializeComponent();
            this.DataContext = new SampleViewModel();
        }
        private void live_titlesClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(LiveTitleChange));
        }
        private void ranking(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(Results));
        }

        private void glowna(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }
        private void showpanel(object sender, RoutedEventArgs e)
        {
            Burgerek.IsPaneOpen = !Burgerek.IsPaneOpen;
            if (Burgerek.IsPaneOpen)
                show.Content = "\uE00E";
            else
                show.Content = "\uE00F";
        }

        private void zmienlivetitle(object sender, RoutedEventArgs e)
        {
            var template = TileContentFactory.CreateTileSquare150x150PeekImageAndText01();
            template.TextBody1.Text = "Wow ale super";
            template.TextBody2.Text = "na";
            template.TextBody3.Text = "150x150";
            template.Image.Src = "ms-appx:///Assets/aaa.scale-400.png";

            var wideTemlate = TileContentFactory.CreateTileWide310x150PeekImageAndText01();
            wideTemlate.TextBodyWrap.Text = "WoW WoW 310x150";
            wideTemlate.Image.Src = "ms-appx:///Assets/aaa.scale-400.png";
            wideTemlate.Square150x150Content = template;

            TileNotification wideNotification = wideTemlate.CreateNotification();
            TileUpdater updater = TileUpdateManager.CreateTileUpdaterForApplication();
            updater.Update(wideNotification);

        }
    }
}
