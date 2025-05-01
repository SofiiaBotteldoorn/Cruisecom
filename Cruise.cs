using Cruisecom.Personeel;
using Cruisecom.Vloot;

namespace Cruisecom
{
    public class Cruise
    {
        public Cruise(int cruiseId, string bestemming, int duurInDagen, CruiseMaatschappij cruiseMaatschappij, Schip schip, List<Personeelslid> personeel) 
        {
            CruiseId = cruiseId;
            Bestemming = bestemming;
            DuurInDagen = duurInDagen;
            CruiseMaatschappij = cruiseMaatschappij;
            Schip = schip;
            Personeel = personeel;
        }
        public int CruiseId { get; set; }
        public string Bestemming { get; set; }
        public int DuurInDagen { get; set; }
        public CruiseMaatschappij CruiseMaatschappij { get; set; }
        public Schip Schip { get; set; }
        public List<Personeelslid> Personeel { get; set; }
        public decimal BerekenCruiseKost()
        {
            decimal totaleSchipKost = Schip.BerekenTotaleKostprijsPerDag() * DuurInDagen;
            //LINQ voor totaleKost berekenen voor List
            decimal totalePersoneelKost = Personeel.Sum(p => p.BerekenTotaleKostprijsPerDag()) * DuurInDagen;
            decimal totaleCruiseKost = totaleSchipKost + totalePersoneelKost;
            return totaleCruiseKost;
        }

        public string TekenLijn(char teken, int lengte)
        {
            return new string(teken, lengte);
            
        }
        public override string ToString()
        {
            return $"{TekenLijn('-', 45)}\n " +
                $"CruiseId: {CruiseId} - Bestemming: {Bestemming} ({DuurInDagen} dag(en))\n" +
                $"{TekenLijn('-', 45)}\n" +
                $"Maatschappij: {CruiseMaatschappij.Naam} - schip: {Schip.Naam} (Basis kostprijs per dag: {Schip.BasisKostprijsPerDag} euro)\n" +
                $"Cruisprijs: {BerekenCruiseKost()}\n" +
                $"Totale schipkost: {Schip.BasisKostprijsPerDag * DuurInDagen:F2}\n" +
                $"Totale personeelkost: {Personeel.Sum(p => p.BerekenTotaleKostprijsPerDag() * DuurInDagen):F2}\n" +
                $"    Totalekost brugpersoneel: {Personeel.OfType<BrugPersoneelslid>().Sum(p => p.BerekenTotaleKostprijsPerDag() * DuurInDagen):F2}\n" +
                $"    Totalekost passagierspersoneel:  {Personeel.OfType<PassagiersPersoneelslid>().Sum(p => p.BerekenTotaleKostprijsPerDag() * DuurInDagen)}\n" +
                $"Brugpersoneel: \n{TekenLijn('*', 14)}\n" + $"{string.Join("\n", Personeel.OfType<BrugPersoneelslid>().Select(p => p.ToString()))}\n" +
                $"Passagierspersoneel: \n{TekenLijn('*', 20)}\n" + $"{string.Join("\n", Personeel.OfType<PassagiersPersoneelslid>().Select(p => p.ToString()))}\n";

        }
    } 
}
