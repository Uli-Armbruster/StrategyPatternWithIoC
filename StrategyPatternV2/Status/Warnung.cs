using StrategyPattern.Contracts;

namespace StrategyPatternV2.Status
{
    public class Warnung : IchErrechneArtikelZukaufsvorschlag
    {
        public int Für(Artikel artikel)
        {
            return artikel.Lagerbestand < 3 ? 3 : artikel.Lagerbestand;
        }
    }
}