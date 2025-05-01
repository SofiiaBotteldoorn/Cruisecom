namespace Cruisecom.Personeel
{
    public abstract class VarendPersoneelslid : Personeelslid
    {
        public VarendPersoneelslid(int personeelsId, string naam, decimal basisKostprijsPerDag, Rang rang, List<Certificaat> certificaten)
            : base(personeelsId, naam, basisKostprijsPerDag)
        {
            Rang = rang;
            Certificaten = certificaten;
        }
        public Rang Rang { get; set; }
        public List<Certificaat> Certificaten { get; set; }

        public override decimal BerekenTotaleKostprijsPerDag()
        {
            return BasisKostprijsPerDag;
        }

        public override string ToString()
        {
            return $"{base.ToString()}" +
                $"Rang: {Rang}\n" +
                $"Certificaten:\n   {string.Join("   ", Certificaten)}\n";
        }
        
    }
}
