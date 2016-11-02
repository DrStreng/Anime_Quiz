
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
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;


namespace Animu.View
{

    public sealed partial class Play : Page
    {
         int TIMELIMIT;
        DispatcherTimer timer;
        List<Pytanka> ListPytanka = new List<Pytanka>();
        DBConnect db;
        int index = 0;
        int mnoznik_pkt = 0;
        int punkty = 0;
        int poprawneOdp = 0;
        int maxPytan = 0;
        int aktualnePytanie = 1;

        private void showpanel(object sender, RoutedEventArgs e)
        {
            Burgerek.IsPaneOpen = !Burgerek.IsPaneOpen;
            if (Burgerek.IsPaneOpen)
                show.Content = "\uE00E";
            else
                show.Content = "\uE00F";
        }

        public Play()
        {

            this.InitializeComponent();
            db = new DBConnect();
            this.DataContext = new SampleViewModel();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            var mode = e.Parameter;

            if((Mode)mode == Mode.EASY)
            {
                ListPytanka = db.getEasy().OrderBy(i => Guid.NewGuid()).ToList();
                TIMELIMIT = 20;
                mnoznik_pkt = 1;
            }
            else if ((Mode)mode == Mode.MEDIUM)
            {
                ListPytanka = db.getMedium().OrderBy(i => Guid.NewGuid()).ToList();
                TIMELIMIT = 15;
                mnoznik_pkt = 2;
            }
            else if ((Mode)mode == Mode.HARD)
            {
                ListPytanka = db.getHard().OrderBy(i => Guid.NewGuid()).ToList();
                TIMELIMIT = 10;
                mnoznik_pkt = 3;
            }
            else if ((Mode)mode == Mode.VERYHARD)
            {
                ListPytanka = db.getVeryHard().OrderBy(i => Guid.NewGuid()).ToList();
                TIMELIMIT = 5;
                mnoznik_pkt = 4;
            }

            MyProgress.Minimum = 0;
            MyProgress.Value = 0;
            MyProgress.Maximum = TIMELIMIT;
            maxPytan = ListPytanka.Count;
            Pytanko(index);

        }


        private void sprawdzOdp(Button click)
        {
            if (click.Content.Equals(ListPytanka[index].PoprawnaOdp)){

                punkty += 1*mnoznik_pkt;
                poprawneOdp++;
                zdobytepkt.Text = punkty.ToString();
            }
            aktualnePytanie++;
            index++;
            resetTimer();
            Pytanko(index);


        }


        public void Pytanko (int index)
        {
            if(index < ListPytanka.Count)
            {
                
                string imgDB = "ms-appx:///Assets/animeChar/"+ ListPytanka[index].Image + ".png";
                ImageContent.Source = new BitmapImage(new Uri(imgDB));

                ButtonOdpA.Content = ListPytanka[index].OdpA;
                ButtonOdpB.Content = ListPytanka[index].OdpB;
                ButtonOdpC.Content = ListPytanka[index].OdpC;
                ButtonOdpD.Content = ListPytanka[index].OdpD;

                txtNum.Text = $"{aktualnePytanie}/{maxPytan}";

                timer = new DispatcherTimer();
                timer.Interval = new TimeSpan(0, 0, 1);
                timer.Tick += Timer_Tick;
                timer.Start();
            
            } else {
                
                Frame.Navigate(typeof(EndGame),new Send() {
                    poprawneOdp=this.poprawneOdp,
                    maxPytan=this.maxPytan,
                    punkciki = this.punkty
                });

            }

        }

        private void Timer_Tick(object sender, object e)
        {
            MyProgress.Value += 1;
            if(MyProgress.Value >= TIMELIMIT)
            {
                index++;
                resetTimer();
                Pytanko(index);
            }
        }

        private void resetTimer()
        {
            timer.Stop();
            timer = null;
            MyProgress.Value = 0;
        }

        private void ButtonOdpA_Click(object sender, RoutedEventArgs e)
        {
            sprawdzOdp(sender as Button);
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
