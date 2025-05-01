namespace Cruisecom.Vloot
{
    public class Schip : IKost
    {
        public Schip(string naam, int capaciteit, int vaarBereik, decimal basisKostprijsPerDag)
        {
            Naam = naam;
            Capaciteit = capaciteit;
            VaarBereik = vaarBereik;
            BasisKostprijsPerDag = basisKostprijsPerDag;
        }
        public string Naam { get; set; }
        public int Capaciteit { get; set; } //aantal passagiers
        public int VaarBereik { get; set; } //in zeemijlen
        // Interface-implementatie: Schip is geen afgeleide klasse, dus geen override nodig.
        public decimal BasisKostprijsPerDag { get; init; }
        public decimal BerekenTotaleKostprijsPerDag()
        {
            return BasisKostprijsPerDag;
        }
    }
}
