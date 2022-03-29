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
                Console.WriteLine($"{i+1}. helyezett: {gyoztesek.ElementAt(i).Nev}");              
            }

            //3.feladat
            Console.WriteLine("\n3.feladat");
            for (int i = 0; i < 1; i++)
            {
                Console.WriteLine($"Győztes: {gyoztesek.ElementAt(i).Nev}");
                Console.WriteLine($"Átlagsebessége úszásban: {(1500 / (double)gyoztesek.ElementAt(i).uszasi_ido * 3.6).ToString("0.00")} km/h");
                Console.WriteLine($"Átlagsebessége kerékpározásban: {40000 / (double)gyoztesek.ElementAt(i).kerekpar_ido * 3.6} km/h");
                Console.WriteLine($"Átlagsebessége futásban:{10000 / (double)gyoztesek.ElementAt(i).futasi_ido * 3.6} km/h");
            }

            //4,5,6.feladat
            Console.WriteLine("\n4,5,6.feladat");
            StreamWriter ir = new StreamWriter("triatlon.ki");
            foreach (var adat in gyoztesek)
            {
                ir.WriteLine($"{adat.Nev} {konvertal_ido(adat.osszesitett_ido)}");
            }
            ir.Close();
            Console.WriteLine("A \"triatlon.ki\" fájl kiírva!");

            //7.feladat
            Console.WriteLine("\n7.feladat");
            StreamWriter iro = new StreamWriter("reszer.ki");
            int gyoztes_uszo_index = lista.FindIndex(x => x.uszasi_ido == lista.Select(y => y.uszasi_ido).Min());
            int gyoztes_kerekpar_index = lista.FindIndex(x => x.kerekpar_ido == lista.Select(y => y.kerekpar_ido).Min());
            int gyoztes_futas_index = lista.FindIndex(x => x.futasi_ido == lista.Select(y => y.futasi_ido).Min());
            iro.WriteLine($"{lista[gyoztes_uszo_index].Nev} {konvertal_ido(lista[gyoztes_uszo_index].uszasi_ido)}");
            iro.WriteLine($"{lista[gyoztes_kerekpar_index].Nev} {konvertal_ido(lista[gyoztes_kerekpar_index].uszasi_ido)}");
            iro.WriteLine($"{lista[gyoztes_futas_index].Nev} {konvertal_ido(lista[gyoztes_futas_index].uszasi_ido)}");
            iro.Close();
            Console.WriteLine("A \"reszer.ki\" fájl kiírva!");
            Console.ReadKey();
        }
    }
}
