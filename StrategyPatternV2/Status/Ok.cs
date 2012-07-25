using StrategyPattern.Contracts;

namespace StrategyPatternV2.Status
{
    public class Ok : IchErrechneArtikelZukaufsvorschlag
    {
        public int Für(Artikel artikel)
        {
            return 0;
        }
    }
}