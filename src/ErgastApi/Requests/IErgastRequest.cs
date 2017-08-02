namespace ErgastApi.Requests
{
    public interface IErgastRequest
    {
        int? Limit { get; set; }

        int? Offset { get; set; }

        void Page(int page, int pageSize);

        string Season { get; set; }

        string Round { get; set; }

        string DriverId { get; set; }
    }
}