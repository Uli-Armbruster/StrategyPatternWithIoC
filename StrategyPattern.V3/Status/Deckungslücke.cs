using StrategyPattern.Contracts;

namespace StrategyPattern.V3.Status
{
    public class Deckungsl�cke : IchErrechneArtikelZukaufsvorschlag
    {
        public int F�r(Artikel artikel)
        {
            return artikel.Lagerbestand * 2;
        }
    }
}