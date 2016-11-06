using Animu.Model;
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


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Animu.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    /// 



    public sealed partial class Results : Page
    {
    
        List<Wyniki> listWyniki = new List<Wyniki>();
   
        DBConnect db;

        public Results()
        {
            this.InitializeComponent();
            db = new DBConnect();
            this.DataContext = new SampleViewModel();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            loadRanking();
        }

        private void loadRanking()
        {
           var a = db.getWyniki();
         
            foreach (var data in a)
            {
                Wyniki w1 = new Wyniki() { Punkty = data.Punkty,IloscPytan = data.IloscPytan,PoprawneOdp=data.PoprawneOdp };
                listWyniki.Add(w1);
            }
            myListpkt.ItemsSource = listWyniki;
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
