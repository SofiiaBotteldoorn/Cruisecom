namespace Cruisecom.Personeel
{
    public class Certificaat
    {
        public string CertificaatAfkorting { get; set; } = null!;
        public string CertificaatOmschrijving { get; set; } = null!;
        public override string ToString()
        {
            return $"{CertificaatOmschrijving} ({CertificaatAfkorting})\n";
        }
    }
}

