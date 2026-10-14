using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Kiss_Csaba_GyakorlatiMunka01
{
    internal class Program
    {
        static List<VideoJatekok> videojatekLista = new List<VideoJatekok>();
        static void Main(string[] args)

        {
            
            AdatBeolvas();

            /*
            //1., feladat
            Console.WriteLine("\n1., feladat:");
            videojatekLista.Where(x => x.FelhasznaloiErtekeles >= 9).ToList().ForEach(w => Console.WriteLine(w.Nev));

            //2., feladat
            Console.WriteLine("\n2., feladat:");
            videojatekLista.Where(x => x.Platform == "Nintendo Switch" && x.KiadasEve >= 2015 && x.FelhasznaloiErtekeles >= 8).ToList().ForEach(w => Console.WriteLine(w.Nev));
            

            //3., feladat
            Console.WriteLine("\n3., feladat:");
            videojatekLista.OrderByDescending(x => x.KiadasEve).ToList().ForEach(w => Console.WriteLine(w.Nev));
            

            //4., feladat
            Console.WriteLine("\n4., feladat:");
            videojatekLista.OrderByDescending(x => x.FelhasznaloiErtekeles).Take(10).ToList().ForEach(w => Console.WriteLine($"{w.Nev} {w.FelhasznaloiErtekeles}"));
            

            //5., feladat
            Console.WriteLine("\n5., feladat:");
            videojatekLista.GroupBy(x => x.Platform).Select(x => new
            {
                platform = x.Key,
                jatekdb = x.Count()

            }).ToList().ForEach(w => Console.WriteLine(w));
            

            //6., feladat
            Console.WriteLine("\n6., feladat:");
            videojatekLista.GroupBy(x => x.Tipus).Select(x => new
            {
                platform = x.Key,
                jatekdbtipus = x.Count()

            }).ToList().ForEach(w => Console.WriteLine(w));
            

            //7., feladat
            Console.WriteLine("\n7., feladat:");
            Console.WriteLine(videojatekLista.Average(x => x.FelhasznaloiErtekeles)); 
            

            //8., feladat
            Console.WriteLine("\n8., feladat:");
            videojatekLista.GroupBy(x => x.Platform).Select(x => new
            {
                platform = x.Key,
                atlag = x.Average(y => y.FelhasznaloiErtekeles)

            }).OrderByDescending(x => x.atlag).Take(1).ToList().ForEach(w => Console.WriteLine(w));
            

            //9., feladat
            Console.WriteLine("\n9., feladat: ");
            Console.WriteLine($"Maximum értékelés: {videojatekLista.Max(x => x.FelhasznaloiErtekeles)}");
            Console.WriteLine($"Minimum értékelés: {videojatekLista.Min(x => x.FelhasznaloiErtekeles)}");
            

            //10., feladat
            Console.WriteLine("\n10., feladat: ");
            videojatekLista.Select(x => x.Tipus).Distinct().ToList().ForEach(x => Console.WriteLine(x));
            

            //11., feladat
            Console.WriteLine("\n11., feladat");
            var listah = videojatekLista.Select(x => new
            {
                nev = x.Nev,
                kiadaseve = x.KiadasEve,

            }).ToList();
            listah.ForEach(w => Console.WriteLine($"{w.nev}, {w.kiadaseve}"));
            

            //12., feladat
            Console.WriteLine("\n12., feladat:");
            videojatekLista.Where(x => x.Tipus == "Action").OrderByDescending(x => x.FelhasznaloiErtekeles).ToList().ForEach(w => Console.WriteLine($"Action Játékok: {w.Nev}, {w.KiadasEve}, {w.FelhasznaloiErtekeles}"));
            

            //13., feladat
            Console.WriteLine("\n13., feladat: ");
            videojatekLista.GroupBy(x => x.Tipus).Select(x => new
            {
                tipus = x.Key,
                atlagosErtekeles = x.Average(y => y.FelhasznaloiErtekeles)

            }).ToList().ForEach(w => Console.WriteLine(w));
            

            //14., feladat
            Console.WriteLine("\n14., feladat:");
            videojatekLista.Where(x => x.KiadasEve <= 2005).ToList().ForEach(w => Console.WriteLine($"{w.Nev} {w.Platform}"));
            */

            //15., feladat
            Console.WriteLine("\n15., feladat:");           
            videojatekLista.GroupBy(x => x.Platform).Select(x => new
            {
                
                platform = x.Key,
                ertekeles = x.OrderByDescending(y => y.FelhasznaloiErtekeles).FirstOrDefault(),
                nev = x.Select(z => z.Nev)
                

            }).ToList().ForEach(w => Console.WriteLine($"{w.platform}, {w.ertekeles}, {w.nev}"));

            Console.ReadKey();
           
        }
        private static void VideoJatekokkk()
        {
            foreach (var item in videojatekLista)
            {
                Console.WriteLine(item.Nev);
            }
        }

        private static void AdatBeolvas()
        {
            try
            {
                videojatekLista = File.ReadAllLines("Csaba Kiss - games_dataset.csv")
                    .Skip(1)
                    .Select(egysor => egysor.Split(';'))
                    .Select(adat => new VideoJatekok(adat[0], adat[1], adat[2], int.Parse(adat[3]), double.Parse(adat[4])))
                    .ToList();

                
            }
            catch (Exception e)
            {

                Console.WriteLine($"Hibás beolvasás! {e.Message}");
            }
        }
    }
}
