using System.Threading.Tasks;
using Jokenpo.Domain.Commands.Contracts;

namespace Jokenpo.Domain.Handlers.Contracts
{
    public interface IHandler<in TCommand, out TResult> where TCommand : ICommand
    {
        TResult Handle(TCommand command);
    }
}