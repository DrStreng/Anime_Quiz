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
           
        }
        public string Glowna { get; set; }
        public string Ranking { get; set; }

        public string Test {
            get { return test; }
            set {
                test = value;
                RaisePropertyChanged("No co tam");
            }
        }

    }
}
   
