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
        }
        private void live_titlesClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(LiveTitleChange));
        }
        private void ranking(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(View.Results));
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

    }
}
