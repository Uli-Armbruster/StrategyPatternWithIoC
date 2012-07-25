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
                                     {Bestandsstatus.AkuteDeckungsl�cke, new AkuteDeckungsl�cke()},
                                     {Bestandsstatus.Deckungsl�cke, new Deckungsl�cke()},
                                     {Bestandsstatus.Warnung, new Warnung()},
                                     {Bestandsstatus.Ok, new Ok()},
                                 };
        }

        public IchErrechneArtikelZukaufsvorschlag F�r(Bestandsstatus status)
        {
            return _vorschlagsrechner[status];
        }
    }
}