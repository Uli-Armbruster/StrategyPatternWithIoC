using StrategyPattern.Contracts;

namespace StrategyPatternV2.Status
{
    public class AkuteDeckungslücke : IchErrechneArtikelZukaufsvorschlag
    {
        public int Für(Artikel artikel)
        {
            return 10;
        }
    }
}