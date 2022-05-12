using Facq.Commands;

namespace Facq
{
    public interface IPreCommandHandler<TCommand> where TCommand : ICommand { Task Handle(TCommand command); }
}