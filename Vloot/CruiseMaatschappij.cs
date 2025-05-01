namespace Cruisecom.Vloot
{
    public class CruiseMaatschappij
    {
        public CruiseMaatschappij(int maatschappijId, Maatschappij naam, List<Schip>vloot) 
        { 
            MaatschappijId = maatschappijId;
            Naam = naam;
            Vloot = vloot;
        }
        public int MaatschappijId { get; set; }
        public Maatschappij Naam { get; set; }
        public List<Schip> Vloot { get; set; }
    }
}
