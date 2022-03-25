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
        static void Beolvas()//Eljárás, ami csinál valamit! Nem kell, hogy értékkel térjen vissza!
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

        static string konvertal_ido(int second)
        {
            int ora = second / 60 / 60;
            int perc = (second / 60) - (ora * 60);
            int masodperc = second % 60;
            return $"{ora.ToString("00")}:{perc.ToString("00")}:{masodperc.ToString("00")}";
        }
        static void Main(string[] args)//Main
        {
            //1. feladat: Olvassa be a triatlon.be fájlból az adatokat!
            Beolvas();
            Console.WriteLine("1.feladat: Beolvasás kész!");
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
            Console.WriteLine("\n2.feladat");
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
            Console.WriteLine("\n3.feladat");
            for (int i = 0; i < 1; i++)
            {
                Console.WriteLine($"Győztes: {gyoztesek.ElementAt(i).Nev}");
                Console.WriteLine($"Átlagsebessége úszásban: {(1500 / (double)gyoztesek.ElementAt(i).uszasi_ido * 3.6).ToString("0.00")} km/h");
                Console.WriteLine($"Átlagsebessége kerékpározásban: {4000 / (double)gyoztesek.ElementAt(i).kerekpar_ido * 3.6} km/h");
                Console.WriteLine($"Átlagsebessége futásban:{1000 / (double)gyoztesek.ElementAt(i).futasi_ido * 3.6} km/h");
            }

            //4.feladat
            Console.WriteLine("\n4.feladat");
            Console.WriteLine(gyoztesek.ElementAt(0).osszesitett_ido);
            Console.WriteLine($"{konvertal_ido(116)}");
            Console.ReadKey();
        }
    }
}
