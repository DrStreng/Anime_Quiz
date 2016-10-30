using Animu.Model;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Animu
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void showpanel(object sender, RoutedEventArgs e)
        {
            Burgerek.IsPaneOpen = !Burgerek.IsPaneOpen;
            if(Burgerek.IsPaneOpen)
                show.Content = "\uE00E";
            else
                show.Content = "\uE00F";
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
        }

        private void Play_Click(object sender, RoutedEventArgs e)
        {
            Mode mode;
            if (xŁatwy.IsChecked == true)
                mode = Mode.EASY;
            else if (xŚredni.IsChecked == true)
                mode = Mode.MEDIUM;
            else if (xTrudny.IsChecked == true)
                mode = Mode.HARD;
            else mode = Mode.VERYHARD;

            Frame.Navigate(typeof(View.Play),mode);
        }
    }
}
