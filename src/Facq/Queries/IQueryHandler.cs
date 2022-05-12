namespace Facq.Queries
{
    public interface IQueryHandler<TQuery, TResult> where TQuery : IQuery<TResult> { Task<TResult> Handle(TQuery query); }
}