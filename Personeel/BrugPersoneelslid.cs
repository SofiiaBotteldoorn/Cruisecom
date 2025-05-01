using Cruisecom.Exceptions;

namespace Cruisecom.Personeel
{
    public class BrugPersoneelslid : VarendPersoneelslid
    {
        
        public BrugPersoneelslid(int personeelsId, string naam, decimal basisKostprijsPerDag, Rang rang, List<Certificaat> certificaten, int vaaruren)
            :base(personeelsId, naam, basisKostprijsPerDag, rang, certificaten)
        {
            //Alleen rangen toegestaan op de brug
            if (rang != Rang.Kapitein && rang != Rang.EersteStuurman && rang != Rang.TweedeStuurman && rang != Rang.JuniorStuurman)
            {
                throw new RangException($"Verkeerde rang \"{rang}\", deze behoort niet tot mogelijke graden van brug personeel(Kapitein, EersteStuurman, TweedeStuurman, JuniorStuurman)", rang);
            }

            Vaaruren = vaaruren;
        }

        private int vaaruren;
        public int Vaaruren
        {
            get => vaaruren;
            set
            {
                if (value < 0)
                    throw new ArgumentException($"{nameof(Vaaruren)} mag niet negatief zijn");
                vaaruren = value;
            }
        }
        public override decimal BasisKostprijsPerDag { get; init; }
        public override decimal BerekenTotaleKostprijsPerDag()
        {
            decimal totaalKost = BasisKostprijsPerDag;
            // Totale kostprijs afhankelijk van de rang van het personeelslid
            switch (Rang)
            { 
                case Rang.Kapitein:
                    totaalKost *= 1.30m; //30% verhoging
                    break;
                case Rang.EersteStuurman:
                    totaalKost *= 1.20m; //20% verhoging
                    break;
                case Rang.TweedeStuurman:
                    totaalKost *= 1.10m; //10% verhoging
                    break;
                case Rang.JuniorStuurman: //0%
                default:
                    break;
            }
            // + 50 euro voor BRG certificaat
            if (Certificaten.Any(c => c.CertificaatAfkorting == "BRG"))
            {
                totaalKost += 50m;    
            }
            return totaalKost;
        }
        public override string ToString()
        {
            return $"{base.ToString()}" + 
                $"Vaaruren: {Vaaruren}\n" +
                $"Totale kost per dag: {BerekenTotaleKostprijsPerDag():F2} euro\n";
        }
    }
}
