using Animu.Model;
using Animu.View;
using Animu.ViewModel;
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
using NotificationsExtensions.ToastContent;
using Windows.UI.Notifications;

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
            this.DataContext = new SampleViewModel();
            IToastImageAndText02 trying_toast = ToastContentFactory.CreateToastImageAndText02();
            trying_toast.TextHeading.Text = "Toast notification Example";
            trying_toast.TextBodyWrap.Text = "Animu Quiz app";
            ScheduledToastNotification giveittime;
            giveittime = new ScheduledToastNotification(trying_toast.GetXml(), DateTime.Now.AddSeconds(2));
            giveittime.Id = "Any_ID";
            ToastNotificationManager.CreateToastNotifier().AddToSchedule(giveittime);

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
            if (xŁatwy.IsChecked == true) { mode = Mode.EASY; }
            else if (xŚredni.IsChecked == true) { mode = Mode.MEDIUM; }
            else if (xTrudny.IsChecked == true) { mode = Mode.HARD; }
            else { mode = Mode.VERYHARD; }

            Frame.Navigate(typeof(View.Play),mode);
        }

        private void ranking(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(View.Results));
        }

        private void glowna(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(MainPage));
        }

        private void live_titlesClick(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(LiveTitleChange));
        }
    }
}
