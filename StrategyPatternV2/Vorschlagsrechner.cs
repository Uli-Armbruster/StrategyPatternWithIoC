using System.Collections.Generic;

using StrategyPattern.Contracts;

using StrategyPatternV2.Status;

namespace StrategyPatternV2
{
    public class Vorschlagsrechner : IchVermittleVorschlagsrechner
    {
        readonly Dictionary<Bestandsstatus, IchErrechneArtikelZukaufsvorschlag> _vorschlagsrechner;

        public Vorschlagsrechner()
        {
            _vorschlagsrechner = new Dictionary<Bestandsstatus, IchErrechneArtikelZukaufsvorschlag>
                                 {
                                     {Bestandsstatus.AkuteDeckungslücke, new AkuteDeckungslücke()},
                                     {Bestandsstatus.Deckungslücke, new Deckungslücke()},
                                     {Bestandsstatus.Warnung, new Warnung()},
                                     {Bestandsstatus.Ok, new Ok()},
                                 };
        }

        public IchErrechneArtikelZukaufsvorschlag Für(Bestandsstatus status)
        {
            return _vorschlagsrechner[status];
        }
    }
}