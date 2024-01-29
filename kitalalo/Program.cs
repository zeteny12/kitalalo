using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace kitalalo
{
    internal class Program
    {
        static List<Kitatalo> lista = new List<Kitatalo>();

        static void Main(string[] args)
        {
            Adatolvasas();
            RandomSzo();

            Console.ReadKey();
        }

        // Random szó kiválasztása és játék indítása
        private static void RandomSzo()
        {
            Random r = new Random();
            Kitatalo kivalasztottSzo = lista[r.Next(lista.Count)];

            Console.WriteLine($"Rejtett szó kiválasztva. Kezdd el a tippelést!");

            int tippekSzama = 0;

            char[] megfejtettBetuk = new char[kivalasztottSzo.KitalaltSzo.Length];

            do
            {
                Console.Write("Tipp: ");
                string tipp = Console.ReadLine().ToLower();

                if (tipp == "stop")
                {
                    Console.WriteLine("Játék leállítva.");
                    return;
                }

                if (tipp.Length != kivalasztottSzo.KitalaltSzo.Length)
                {
                    Console.WriteLine($"A tippnek pontosan {kivalasztottSzo.KitalaltSzo.Length} karakterből kell állnia!");
                    continue;
                }

                string eredmeny = kivalasztottSzo.KitalalasEredmeny(tipp);
                Console.WriteLine($"Eredmény: {eredmeny}");

                tippekSzama++;

            } while (!kivalasztottSzo.Megfejtve(new string(megfejtettBetuk)));

            Console.WriteLine($"Gratulálok, ki találtad! {tippekSzama} tipp kellett hozzá.");
        }

        // Adatok beolvasása
        private static void Adatolvasas()
        {
            try
            {
                using (StreamReader sr = new StreamReader("szavak.txt"))
                {
                    while (!sr.EndOfStream)
                    {
                        lista.Add(new Kitatalo(sr.ReadLine()));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
