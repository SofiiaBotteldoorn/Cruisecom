namespace Cruisecom.Personeel
{
    public abstract class Personeelslid:IKost
    {
        public Personeelslid(int personeelsId, string naam, decimal basisKostprijsPerDag) 
        { 
            PersoneelsId = personeelsId;
            Naam = naam;
            BasisKostprijsPerDag = basisKostprijsPerDag;
        }
        public int PersoneelsId { get; init; }
        private string naam;
        public string Naam
        {
            get => naam;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException($"{nameof(Naam)} mag niet leeg zijn");
                    naam = value;
            }
        }
        public abstract decimal BasisKostprijsPerDag { get; init; }
        public abstract decimal BerekenTotaleKostprijsPerDag();
        public override string ToString()
        {
            return $"00{PersoneelsId} - {Naam} (basis kost per dag: {BasisKostprijsPerDag:F2} euro)\n";
        }
    }
}
