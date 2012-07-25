using StrategyPattern.Contracts;

namespace StrategyPatternV2.Status
{
    public class Deckungslücke : IchErrechneArtikelZukaufsvorschlag
    {
        public int Für(Artikel artikel)
        {
            return artikel.Lagerbestand * 2;
        }
    }
}