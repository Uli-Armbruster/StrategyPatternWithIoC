using System;
using System.Collections.Generic;
using System.Linq;

using StrategyPattern.Contracts;

namespace StrategyPattern.V1
{
    public class Geschäftslogik
    {
        public IEnumerable<Artikel> ErrechneZukaufsvorschläge(IEnumerable<Artikel> artikelliste)
        {
            foreach (var artikel in artikelliste)
            {
                if (artikel.Lagerbestand < 3)
                    artikel.Status = Bestandsstatus.AkuteDeckungslücke;
                else if (artikel.Lagerbestand % 3 == 0 & artikel.Lagerbestand < 6)
                    artikel.Status = Bestandsstatus.Deckungslücke;
                else if (artikel.Lagerbestand < 9)
                    artikel.Status = Bestandsstatus.Warnung;
                else
                    artikel.Status = Bestandsstatus.Ok;

                switch (artikel.Status)
                {
                    case Bestandsstatus.AkuteDeckungslücke:
                        artikel.Zukaufsvorschlag = 10;
                        break;
                    case Bestandsstatus.Deckungslücke:
                        artikel.Zukaufsvorschlag = artikel.Lagerbestand * 2;
                        break;
                    case Bestandsstatus.Warnung:
                        artikel.Zukaufsvorschlag = artikel.Lagerbestand < 3 ? 3 : artikel.Lagerbestand;
                        break;
                    case Bestandsstatus.Ok:
                        artikel.Zukaufsvorschlag = 0;
                        break;
                    default:
                        throw new ApplicationException("Berechnung für Status fehlt");
                }

                yield return artikel;
            }
        }
    }
}