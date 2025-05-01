namespace Cruisecom.Personeel
{
    class NietVarendPersoneelslid : Personeelslid
    {
        public NietVarendPersoneelslid(int personeelsId, string naam, decimal basisKostprijsPerDag, Afdeling afdeling, int urenPerWeek) 
            : base(personeelsId, naam, basisKostprijsPerDag)
        {
            Afdeling  = afdeling;
            UrenPerWeek = urenPerWeek;
        }

        public Afdeling Afdeling { get; set; }
        private int urenPerWeek;
        public int UrenPerWeek
        {
            get => urenPerWeek;
            set
            {
                if (value < 0)
                    throw new ArgumentException($"{nameof(UrenPerWeek)} mag niet negatief zijn");
                urenPerWeek = value;
            }
        }    
        public override decimal BasisKostprijsPerDag { get; init; }
        public override decimal BerekenTotaleKostprijsPerDag()
        {
            decimal nietVaardendPersoneelslidKost = BasisKostprijsPerDag * UrenPerWeek;
            return nietVaardendPersoneelslidKost;
        }

        public override string ToString()
        {
            return $"{base.ToString()}\n" +
                $"Afdeling: {Afdeling} Uren per week: {UrenPerWeek}";
        }
    }
}
