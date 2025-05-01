namespace Cruisecom
{
    public interface IKost
    {
        decimal BasisKostprijsPerDag { get; }
        decimal BerekenTotaleKostprijsPerDag();
    }
}
