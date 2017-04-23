namespace ErgastApi.Interfaces
{
    public interface IQuery
    {
        ILimitedQuery Limit(int limit);
        IOffsetQuery Offset(int offset);
    }

    public interface ILimitedQuery
    {
        ILimitedOffsetQuery Offset(int offset);
    }

    public interface IOffsetQuery
    {
        ILimitedOffsetQuery Limit(int limit);
    }

    public interface ILimitedOffsetQuery
    {

    }
}