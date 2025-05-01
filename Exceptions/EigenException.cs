namespace Cruisecom.Exceptions
{
    public class RangException : Exception
    {
        public Rang VerkeerdeRang { get; set; }
        public RangException(string message, Rang verkeerdeRang)
             : base(message)
        {
            VerkeerdeRang = verkeerdeRang;
        }
    }

}
