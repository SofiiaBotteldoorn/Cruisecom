using Cruisecom;
using Cruisecom.Personeel;
using Cruisecom.Vloot;
try
{
    Certificaat BRG = new Certificaat
    {
        CertificaatAfkorting = "BRG",
        CertificaatOmschrijving = "Bridge Navigation License"
    };

    Certificaat RADAR = new Certificaat
    {
        CertificaatAfkorting = "RADAR",
        CertificaatOmschrijving = "Radar Operation"
    };

    Certificaat VHF = new Certificaat
    {
        CertificaatAfkorting = "VHF",
        CertificaatOmschrijving = "VHF Radio Communication"
    };

    Certificaat FIRE = new Certificaat
    {
        CertificaatAfkorting = "FIRE",
        CertificaatOmschrijving = "Fire Fighting"
    };

    Certificaat EVAC = new Certificaat
    {
        CertificaatAfkorting = "EVAC",
        CertificaatOmschrijving = "Evacuation Procedures"
    };

    Certificaat EHBO = new Certificaat
    {
        CertificaatAfkorting = "EHBO",
        CertificaatOmschrijving = "First Aid"
    };

    Certificaat SURV = new Certificaat
    {
        CertificaatAfkorting = "SURV",
        CertificaatOmschrijving = "Survival at Sea"
    };

    Certificaat HYG = new Certificaat
    {
        CertificaatAfkorting = "HYG",
        CertificaatOmschrijving = "Hygiene and Sanitation"
    };

    Certificaat SEC = new Certificaat
    {
        CertificaatAfkorting = "SEC",
        CertificaatOmschrijving = "Security Awareness"
    };

    Certificaat IFS = new Certificaat
    {
        CertificaatAfkorting = "IFS",
        CertificaatOmschrijving = "In-Flight Service (Cruise Edition)"
    };

    Certificaat ENG = new Certificaat
    {
        CertificaatAfkorting = "ENG",
        CertificaatOmschrijving = "Engine Room Procedures"
    };


    List<Personeelslid> personeel = new List<Personeelslid>()
    {
        new BrugPersoneelslid(1, "Captain Jack Sparrow", 450m, Rang.Kapitein, new List<Certificaat>() { BRG, RADAR, VHF }, 12000),
        new BrugPersoneelslid(2, "Will Turner", 380m, Rang.EersteStuurman, new List<Certificaat>() { BRG, RADAR }, 9500),
        new BrugPersoneelslid(3, "Emma Watson", 320m, Rang.TweedeStuurman, new List<Certificaat>() { BRG }, 7200),
        new BrugPersoneelslid(4, "Smeagol", 280m, Rang.JuniorStuurman, new List<Certificaat>() { BRG }, 4000),

        new PassagiersPersoneelslid(5, "Frodo Baggins", 300m, Rang.ChefSteward, new List<Certificaat>() { EHBO, FIRE }, "Dek 1"),
        new PassagiersPersoneelslid(6, "Sam", 250m, Rang.Steward, new List<Certificaat>() { EHBO }, "Receptie")
    };

    List<Schip> schepen = new List<Schip>()
    {
        new Schip("Vliegende Hollander", 7410, 8700, 5000),
        new Schip("Black Pearl", 7200, 8500, 4600),
        new Schip("Aurora", 7300, 8600, 4800),
        new Schip("Elven's Lied", 7700, 9200, 5400),
        new Schip("Rivendell Serenity", 7600, 9000, 5100),
        new Schip("Gondor Glory", 7350, 8700, 4700),
    };

    List<CruiseMaatschappij> cruisMaatschappijen = new List<CruiseMaatschappij>()
    {
        new CruiseMaatschappij(1, Maatschappij.GondorLines, new List<Schip>() { schepen[0], schepen[5] }),
        new CruiseMaatschappij(2, Maatschappij.ShireCruiseCompany, new List<Schip>() { schepen[1],schepen[2] }),
        new CruiseMaatschappij(3, Maatschappij.RivendellRetreats, new List<Schip>() { schepen[3], schepen[4] }),
    };

    List<Cruise> cruises = new List<Cruise>()
    {
        new Cruise(1, "Valinor", 7, cruisMaatschappijen[0], schepen[0], new List<Personeelslid>() { personeel[2], personeel[4], personeel[5] }),
        new Cruise(2, "Costa Rica", 10, cruisMaatschappijen[1], schepen[1], new List<Personeelslid>() { personeel[2], personeel[1], personeel[4] }),
        new Cruise(3, "Noorse Fjorden", 8, cruisMaatschappijen[2], schepen[3], new List<Personeelslid>() { personeel[0], personeel[3], personeel[5] })
    };

    foreach (var cruise in cruises)
    {
        Console.WriteLine(cruise.ToString());
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}