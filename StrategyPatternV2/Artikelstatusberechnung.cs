using StrategyPattern.Contracts;

namespace StrategyPatternV2
{
    public class Artikelstatusberechnung : IchErmittleArtikelStatus
    {
        public Bestandsstatus Für(Artikel artikel)
        {
            if (artikel.Lagerbestand < 3)
                return Bestandsstatus.AkuteDeckungslücke;
            else if (artikel.Lagerbestand % 3 == 0 & artikel.Lagerbestand < 6)
                return Bestandsstatus.Deckungslücke;
            else if (artikel.Lagerbestand < 9)
                return Bestandsstatus.Warnung;
            else
                return Bestandsstatus.Ok;
        }
    }
}