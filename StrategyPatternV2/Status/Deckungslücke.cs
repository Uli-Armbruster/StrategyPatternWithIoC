using StrategyPattern.Contracts;

namespace StrategyPatternV2.Status
{
    public class Deckungsl�cke : IchErrechneArtikelZukaufsvorschlag
    {
        public int F�r(Artikel artikel)
        {
            return artikel.Lagerbestand * 2;
        }
    }
}