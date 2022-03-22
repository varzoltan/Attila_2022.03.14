using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Attila_2022._03._14
{
    internal class Program
    {
        struct Adat
        {
            public string Nev { get; set; }
            public int uszasi_ido { get; set; }
            public int kerekpar_ido { get; set; }
            public int futasi_ido { get; set; }
            public int osszesitett_ido { get { return uszasi_ido + kerekpar_ido + futasi_ido; } }
        }

        static List<Adat> lista = new List<Adat>();
        static void Beolvas()
        {
            Adat adatok = new Adat();
            //int szam = int.Parse(File.ReadAllLines("TRIATLON.BE").First());
            string[] triatlon = File.ReadAllLines("TRIATLON.BE");
            for (int i = 1; i < triatlon.Length; i += 4)
            {
                adatok.Nev = triatlon[i];
                adatok.uszasi_ido = int.Parse(triatlon[i + 1]);
                adatok.kerekpar_ido = int.Parse(triatlon[i + 2]);
                adatok.futasi_ido = int.Parse(triatlon[i + 3]);
                lista.Add(adatok);
            }
        }
        static void Main(string[] args)
        {
            //1. feladat: Olvassa be a triatlon.be fájlból az adatokat!
            Beolvas();
            /*StreamReader olvas = new StreamReader("TRIATLON.BE");
            int szam = int.Parse(olvas.ReadLine());
            while (!olvas.EndOfStream)
            {
                adatok.Nev = olvas.ReadLine();
                adatok.uszasi_ido = int.Parse(olvas.ReadLine());
                adatok.kerekpar_ido = int.Parse(olvas.ReadLine());
                adatok.futasi_ido = int.Parse(olvas.ReadLine());
                lista.Add(adatok);
            }
            olvas.Close();*/

            //2.feladat
            var gyoztesek = lista.OrderBy(x => x.osszesitett_ido);
            /*foreach (var i in Enumerable.Range(0,3))
            {
                Console.Write($"{gyoztesek.ElementAt(i).Nev} {gyoztesek.ElementAt(i).osszesitett_ido}\n");
            }*/
            for (int i = 0;i<3;i++)
            {
                Console.WriteLine($"{gyoztesek.ElementAt(i).Nev}");
            }

            //3.feladat

            Console.ReadKey();
        }
    }
}
