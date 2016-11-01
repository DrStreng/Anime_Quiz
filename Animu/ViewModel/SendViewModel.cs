using Animu.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animu.ViewModel
{

    class SendViewModel : VMBase
    {
        int _poprawneOdp;
        int _maxPytan;
        int _punkciki;

        public SendViewModel(Send model)
        {
            _Model = model;
            _poprawneOdp= model.poprawneOdp;
            _maxPytan = model.maxPytan;
            _punkciki = model.punkciki;
        }

        public SendViewModel()
        {
        }

        Send _Model;

        public int Punkciki
        {
            get { return _punkciki; }
            set{ _punkciki = value;}
        }
        public int MaxPytan
        {
            get { return _maxPytan; }
            set { _maxPytan = value;}
        }
        public int PoprawneOdp
        {
            get { return _poprawneOdp; }
            set {  _poprawneOdp = value; }
        }
    }
}
