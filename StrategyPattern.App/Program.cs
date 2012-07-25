using System;
using System.Collections.Generic;
using System.Linq;

using Castle.Windsor;

using StrategyPattern.Contracts;
using StrategyPattern.V1;

namespace StrategyPattern.App
{
    class Program
    {
        static IWindsorContainer Container;

        static void Main()
        {
            Container = new IoCInitializer().RegisterComponents().Container;
            
            var articles = new List<Artikel>
                           {
                               new Artikel {Nummer="Hammer",Lagerbestand = 1},
                               new Artikel {Nummer="Schraubenzieher",Lagerbestand = 3},
                               new Artikel {Nummer="Säge",Lagerbestand = 6},
                               new Artikel {Nummer="Bohrer",Lagerbestand = 9},
                           };

            BerechneAufAlteWeise(articles);
            BerechneAufNeueWeise(articles);
            
            Console.ReadLine();
        }


        static void BerechneAufAlteWeise(IEnumerable<Artikel> articles)
        {
            Console.WriteLine("Berechnung mit V1");
            var logik = new Geschäftslogik();
            var berechneteArtikel = logik.ErrechneZukaufsvorschläge(articles);
            Print(berechneteArtikel);
        }

        static void BerechneAufNeueWeise(IEnumerable<Artikel> articles)
        {
            Console.WriteLine("Berechnung mit V3");
            var geschäftslogik = Container.Resolve<IchKenneDasBusiness>();
            var berechneteArtikel = geschäftslogik.ErrechneZukaufsvorschläge(articles);
            Print(berechneteArtikel);

        }

        static void Print(IEnumerable<Artikel> berechneteArtikel)
        {
            foreach (var artikel in berechneteArtikel)
            {
                Console.WriteLine(artikel.ToString());
            }
            Console.WriteLine();
        }
    }
}
