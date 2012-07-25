using System.Collections.Generic;
using System.Linq;

using StrategyPattern.Contracts;

namespace StrategyPattern.V3
{
    public class Geschäftslogik : IchKenneDasBusiness
    {
        readonly IchErmittleArtikelStatus _status;
        readonly IchVermittleVorschlagsrechner _vermittler;

        public Geschäftslogik(IchErmittleArtikelStatus status, IchVermittleVorschlagsrechner vermittler)
        {
            _status = status;
            _vermittler = vermittler;
        }

        public IEnumerable<Artikel> ErrechneZukaufsvorschläge(IEnumerable<Artikel> articles)
        {
            foreach (var article in articles)
            {
                article.Status = _status.Für(article);
                var zukaufsvorschlag = _vermittler.Für(article.Status);

                article.Zukaufsvorschlag = zukaufsvorschlag.Für(article);

                yield return article;
            }
        }
    }
}
