using StrategyPattern.Contracts;

namespace StrategyPattern.V3.Status
{
    public class AkuteDeckungslücke : IchErrechneArtikelZukaufsvorschlag
    {
        public int Für(Artikel artikel)
        {
            return 10;
        }
    }
}