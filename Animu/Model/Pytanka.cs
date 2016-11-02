using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animu.Model
{
    class Pytanka
    {
        public int Id { get; set; }

        public string OdpA { get; set; }

        public string OdpB { get; set; }

        public string OdpC { get; set; }

        public string OdpD { get; set; }

        public string PoprawnaOdp { get; set; }

        public string Image { get; set; }

    }
    public enum Mode
    {
        EASY,
        HARD,
        MEDIUM,
        VERYHARD
    }
}
