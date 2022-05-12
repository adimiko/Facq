using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Facq.Commands;
using Facq.Queries;

namespace Facq.Dispacher
{
    internal class FastestDispatcher : IDispacher
    {
        private readonly IDependencyInjectionProvider _provider;
        public FastestDispatcher(IDependencyInjectionProvider provider)
            => _provider = provider;

        public async Task Send<T>(T command) where T : ICommand
            => await _provider.GetRequiredResolve<ICommandHandler<T>>().Handle(command);

        public async Task<TResult> Send<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult>
            => await  _provider.GetRequiredResolve<IQueryHandler<TQuery,TResult>>().Handle(query);
    }
}