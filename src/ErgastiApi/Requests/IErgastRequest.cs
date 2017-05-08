namespace ErgastApi.Requests
{
    public interface IErgastRequest
    {
        int? Limit { get; set; }

        int? Offset { get; set; }

        void Page(int page, int pageSize);

        int? Season { get; set; }

        int? Round { get; set; }

        string DriverId { get; set; }
    }
}