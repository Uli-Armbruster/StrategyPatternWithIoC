using StrategyPattern.Contracts;

namespace StrategyPattern.V3.Status
{
    public class Ok : IchErrechneArtikelZukaufsvorschlag
    {
        public int Für(Artikel artikel)
        {
            return 0;
        }
    }
}