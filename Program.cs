using System;
using System.Collections.Generic;
using System.IO;

namespace szemétgeci
{
   public class Keres
    {
      public  string Cim { get; set; }
        public string DatumIdo { get; set; }
        public string Get { get; set; }
        public string HttpKod { get; set; }
        public string meret { get; set; }

        public Keres(string Cim,string DatumIdo,string Get,string HttpKod,string meret)
        {
            this.Cim = Cim;
            this.DatumIdo = DatumIdo;
            this.Get = Get;
            this.HttpKod = HttpKod;
            this.meret = meret;
        }
        public int ByteMeret() {

            if (meret == "-")
            {
                return 0;
            }
            else
            {
                return int.Parse(meret);
            }
        }
        public bool Domain()
        {
            if ((Cim.EndsWith("1"))|| (Cim.EndsWith("2"))|| (Cim.EndsWith("3"))|| (Cim.EndsWith("4"))|| (Cim.EndsWith("5"))|| (Cim.EndsWith("6"))|| (Cim.EndsWith("7"))|| (Cim.EndsWith("8"))|| (Cim.EndsWith("9"))|| (Cim.EndsWith("0")))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            
            string[] s = File.ReadAllLines(@"C:\Users\Jack Mehof\Downloads\NASAlog.txt");
            List<Keres> lista = new List<Keres>();
            for (int i = 0; i < s.Length; i++)
            {
                string [] anyyád=s[i].Split("*");
                string[] geci = anyyád[3].Split(" ");
                Keres keres = new Keres(anyyád[0],anyyád[1],anyyád[2],geci[0],geci[1]);
                lista.Add(keres);
            }
            Console.WriteLine("5. feladat: Kérések száma: {0}", lista.Count);
            int összesByte = 0;
            foreach (var item in lista)
            {
                összesByte+=item.ByteMeret();
            }
            Console.WriteLine("6. feladat: Válaszok összes mérete: {0} byte", összesByte);
            float a=0f;
            double percentage=0.00f;
            foreach (var item in lista)
            {
                if (item.Domain() == true)
                {
                    a++;
                }
            }
            percentage =Math.Round( a/lista.Count*100,2);
            Console.WriteLine("8. Feladat: Domain-es kérések: {0}%", percentage);
            HashSet<string> fasz = new HashSet<string>(); 
            foreach (var item in lista)
            {
                fasz.Add(item.HttpKod);
            }
            int nigger = 0;
            Console.WriteLine("9. feladat: Statisztika");
            foreach (var item in fasz)
            {
                nigger = 0;
                foreach (var geci in lista)
                {
                    if (geci.HttpKod == item)
                    {
                        nigger++;
                    }
                }
                Console.WriteLine("     {0}: {1} db",item,nigger);
            }
        }
    }
}
