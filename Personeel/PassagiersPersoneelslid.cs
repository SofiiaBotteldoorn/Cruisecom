using Cruisecom.Exceptions;

namespace Cruisecom.Personeel
{
    public class PassagiersPersoneelslid: VarendPersoneelslid
    {
        public PassagiersPersoneelslid(int personeelsId, string naam, decimal basisKostprijsPerDag, Rang rang, List<Certificaat> certificaten, string werkpositie)
            :base(personeelsId, naam, basisKostprijsPerDag, rang, certificaten)
        {
            if(rang != Rang.ChefSteward && rang != Rang.Steward)
            {
                throw new RangException($"Verkeerde rang \"{rang}\", deze behoort niet tot mogelijke graden van passagiers personeelsleden (ChefSteward of Steward)",rang);
            } 
            Werkpositie = werkpositie;
        }
        private string? werkpositie;
        public string? Werkpositie
        {
            get => werkpositie;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException($"{nameof(Werkpositie)} is niet ingevuld!");
                werkpositie = value;
            }
        }
        public override decimal BasisKostprijsPerDag { get; init; }
        public override decimal BerekenTotaleKostprijsPerDag()
        {
            decimal totalKost = BasisKostprijsPerDag;
            switch (Rang)
            {
                //20% verhoging
                case Rang.ChefSteward:
                    totalKost *= 1.20m;
                    break;
                case Rang.Steward:
                default:
                    break;
            }
            // + 5 eurovoor EHBO certificaat
            if (Certificaten.Any(c => c.CertificaatAfkorting == "EHBO"))
            {
                totalKost += 5m;
            }
            return totalKost;
        }
        public override string ToString()
        {
            return $"{base.ToString()}" +
                $"Werkpositie: {Werkpositie}\n" + 
                $"Totale kost per dag: {BerekenTotaleKostprijsPerDag():F2} euro\n";
        }
    }
}
