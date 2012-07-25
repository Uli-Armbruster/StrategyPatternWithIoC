using StrategyPattern.Contracts;

namespace StrategyPattern.V3.Status
{
    public class Deckungslücke : IchErrechneArtikelZukaufsvorschlag
    {
        public int Für(Artikel artikel)
        {
            return artikel.Lagerbestand * 2;
        }
    }
}