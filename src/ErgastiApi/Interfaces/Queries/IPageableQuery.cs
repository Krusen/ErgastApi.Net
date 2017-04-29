namespace ErgastApi.Interfaces.Queries
{
    public interface IPageableQuery
    {
        ILimitedQuery Limit(int limit);

        IOffsetQuery Offset(int offset);

        // TODO: Document that page starts at 1 for the first page
        IPagedQuery Page(int page, int pageSize);
    }

    public interface ILimitedQuery
    {
        IPagedQuery Offset(int offset);
    }

    public interface IOffsetQuery
    {
        IPagedQuery Limit(int limit);
    }

    public interface IPagedQuery
    {

    }
}