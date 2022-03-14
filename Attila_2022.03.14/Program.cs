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
        static void Main(string[] args)
        {
            //1. feladat: Olvassa be a triatlon.be fájlból az adatokat!
            Adat adatok = new Adat();
            List<Adat> lista = new List<Adat>();
            /*int szam = int.Parse(File.ReadAllLines("TRIATLON.BE").First());
            foreach(string i in File.ReadAllLines("TRIATLON.BE").Skip(1))
            {
                adatok.Nev = i;
                adatok.uszasi_ido = int.Parse(i.ToString());
                adatok.kerekpar_ido = int.Parse(i);
                adatok.futasi_ido = int.Parse(i);
                lista.Add(adatok);
            }*/
            StreamReader olvas = new StreamReader("TRIATLON.BE");
            int szam = int.Parse(olvas.ReadLine());
            while (!olvas.EndOfStream)
            {
                adatok.Nev = olvas.ReadLine();
                adatok.uszasi_ido = int.Parse(olvas.ReadLine());
                adatok.kerekpar_ido = int.Parse(olvas.ReadLine());
                adatok.futasi_ido = int.Parse(olvas.ReadLine());
                lista.Add(adatok);
            }
            olvas.Close();
            foreach (var i in lista)
            {
                Console.Write($"{i.Nev} {i.uszasi_ido} {i.kerekpar_ido} {i.futasi_ido}\n");
            }
            Console.ReadKey();
        }
    }
}
