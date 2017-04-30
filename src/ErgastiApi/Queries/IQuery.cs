namespace ErgastApi.Queries
{
    public interface IQuery
    {
        string DriverId { get; set; }

        int? Round { get; set; }

        int? Season { get; set; }
    }
}