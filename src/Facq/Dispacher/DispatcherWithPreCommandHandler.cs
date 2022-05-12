using System.Runtime.CompilerServices;
using Facq.Commands;
using Facq.Queries;

namespace Facq.Dispacher
{
    internal class DispatcherWithPreCommandHandler : IDispacher
    {
        private readonly IDependencyInjectionProvider _provider;
        public DispatcherWithPreCommandHandler(IDependencyInjectionProvider provider)
            => _provider = provider;

        public async Task Send<T>(T command) where T : ICommand
        {
            var preCommandHandler = _provider.GetResolve<IPreCommandHandler<T>>();
            if(preCommandHandler != null) await preCommandHandler.Handle(command);
            await _provider.GetRequiredResolve<ICommandHandler<T>>().Handle(command);
        }

        public async Task<TResult> Send<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult>
            => await  _provider.GetRequiredResolve<IQueryHandler<TQuery,TResult>>().Handle(query);            
    }
}