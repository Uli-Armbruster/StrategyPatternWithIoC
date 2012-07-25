namespace StrategyPattern.Contracts
{
    public interface IchVermittleVorschlagsrechner
    {
        IchErrechneArtikelZukaufsvorschlag Für(Bestandsstatus status);
    }
}