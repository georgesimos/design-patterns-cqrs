using DesignPatterns.Queries;

namespace DesignPatterns.Handlers
{
    /// <summary>
    /// Defines a handler for a query.
    /// </summary>
    /// <typeparam name="T">Query type being handled</typeparam>
    public interface IQueryHandler
    {
    }
    public interface IQueryHandler<T> : IQueryHandler
      where T : IQuery
    {
        string Handle(T query);
    }
}