using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiss_Csaba_GyakorlatiMunka01
{
    internal class VideoJatekok
    {
        public VideoJatekok(string nev, string tipus, string platform, int kiadasEve, double felhasznaloiErtekeles)
        {
            Nev = nev;
            Tipus = tipus;
            Platform = platform;
            KiadasEve = kiadasEve;
            FelhasznaloiErtekeles = felhasznaloiErtekeles;
        }

        //Játék neve;Típus;Platform;Kiadás éve;Felhasználói értékelés
        public string Nev { get; set; }
        public string Tipus { get; set; }
        public string Platform { get; set; }
        public int KiadasEve { get; set; }
        public double FelhasznaloiErtekeles { get; set; }
    }
}
