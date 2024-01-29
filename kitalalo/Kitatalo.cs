using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kitalalo
{
    internal class Kitatalo
    {
        string KitalaltSzo1;

        public string KitalaltSzo { get => KitalaltSzo1; set => KitalaltSzo1 = value; }

        public Kitatalo(string Beolvas)
        {
 
            string[] kitalal = Beolvas.Split(',');
            KitalaltSzo1 = kitalal[0];
        }

        public override string ToString()
        {
            return KitalaltSzo;
        }

        public string KitalalasEredmeny(string tipp)
        {
            char[] eredmeny = new char[KitalaltSzo.Length];

            for (int i = 0; i < KitalaltSzo.Length; i++)
            {
                if (tipp.Contains(KitalaltSzo[i]))
                {
                    eredmeny[i] = KitalaltSzo[i];
                }
                else
                {
                    eredmeny[i] = '.';
                }
            }

            return new string(eredmeny);
        }

        public bool Megfejtve(string tipp)
        {
            return KitalaltSzo.Equals(tipp);
        }
    }
}

