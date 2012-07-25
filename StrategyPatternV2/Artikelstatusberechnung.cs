using StrategyPattern.Contracts;

namespace StrategyPatternV2
{
    public class Artikelstatusberechnung : IchErmittleArtikelStatus
    {
        public Bestandsstatus F�r(Artikel artikel)
        {
            if (artikel.Lagerbestand < 3)
                return Bestandsstatus.AkuteDeckungsl�cke;
            else if (artikel.Lagerbestand % 3 == 0 & artikel.Lagerbestand < 6)
                return Bestandsstatus.Deckungsl�cke;
            else if (artikel.Lagerbestand < 9)
                return Bestandsstatus.Warnung;
            else
                return Bestandsstatus.Ok;
        }
    }
}