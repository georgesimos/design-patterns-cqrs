using DesignPatterns.Queries;

namespace DesignPatterns.Handlers
{
    public interface IQueryHandler
    {
    }
    public interface IQueryHandler<T> : IQueryHandler
      where T : IQuery
    {
        string Handle(T query);
    }
}