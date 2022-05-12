using Facq.Commands;
using Facq.Queries;

namespace Facq.Dispacher
{
    public interface IDispacher
    {
        public Task Send<T>(T command) where T : notnull, ICommand;

        public Task<TResult> Send<TQuery, TResult>(TQuery query) where TQuery : notnull, IQuery<TResult>;
    }
}