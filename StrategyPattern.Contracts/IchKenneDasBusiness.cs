using System.Collections.Generic;

namespace StrategyPattern.Contracts
{
    public interface IchKenneDasBusiness
    {
        IEnumerable<Artikel> ErrechneZukaufsvorschläge(IEnumerable<Artikel> articles);
    }
}