using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumBsp
{

    [Flags]
    enum Türen { Keine = 0, Drehtür = 1, Schiebtür = 2, Flügeltür = 4, Ofentür = 8 }

    class Möbel
    {
        public String Bezeichnung = String.Empty;
        public Türen Tür = Türen.Keine;
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Möbel> Möbelliste = new List<Möbel>();
            Möbelliste.Add(new Möbel() { Bezeichnung="Erstes  Möbel", Tür = Türen.Flügeltür });
            Möbelliste.Add(new Möbel() { Bezeichnung="Zweites Möbel", Tür = Türen.Flügeltür });
            Möbelliste.Add(new Möbel() { Bezeichnung="Drittes Möbel", Tür = Türen.Schiebtür });
            Möbelliste.Add(new Möbel() { Bezeichnung="der Ofen     ", Tür = Türen.Ofentür });

            String[] t = new String[5];
            t[0] = Türen.Drehtür.ToString();
            t[1] = Türen.Flügeltür.ToString();
            t[2] = Türen.Ofentür.ToString();

            Türen TürAuswahl = Türen.Keine;

            var alleTüren = (Türen[])Enum.GetValues(typeof(Türen));
            foreach (var _t in t)
            {
                foreach (var _tür in alleTüren)
                {
                    if (_tür.ToString() == _t)
                    {
                        TürAuswahl |= _tür;
                    }
                }
            }

            String Ausgabe = String.Empty;

            foreach (var m in Möbelliste)
            {
                if ((m.Tür&TürAuswahl) != Türen.Keine)
                {
                    Ausgabe += m.Bezeichnung + Environment.NewLine;
                }
            }

            Console.WriteLine(Ausgabe);
            Console.ReadLine();
        }
    }
}
