using Animu.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Navigation;

namespace Animu.ViewModel
{

    class SampleViewModel : VMBase
    {
        private string test;
        public SampleViewModel()
        {
            Glowna = "Glowna ";
            Ranking = "Ranking";
            Test = "test";
            Zdobytepkt = "Zdobyte pkty:";
            DesktopBG = "../../Assets/pixel_art_pattern_gray-wallpaper-2560x1600.jpg";
            PhoneBG = "../../Assets/MojuBJ.jpg";

        }

        public string DesktopBG { get; private set; }
        public string Glowna { get; set; }
        public string PhoneBG { get; private set; }
        public string Ranking { get; set; }

        public string Test {
            get { return test; }
            set {
                test = value;
                RaisePropertyChanged("No co tam");
            }
        }

        public string Zdobytepkt { get; private set; }
    }
}
   
