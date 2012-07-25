namespace StrategyPattern.Contracts
{
    public class Artikel
    {
        public string Nummer { get; set; }
        public Bestandsstatus Status { get; set; }
        public int Zukaufsvorschlag { get; set; }
        public int Lagerbestand { get; set; }

        public override string ToString()
        {
            return string.Format("Artikel {0} hat den Status {1}. Mit dem aktuellen Lagerbestand {2} beträgt der Zukaufsvorschlag {3}",
                Nummer,Status.ToString(),Lagerbestand,Zukaufsvorschlag);
        }
    }
}