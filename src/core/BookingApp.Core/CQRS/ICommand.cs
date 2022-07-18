using MediatR;

namespace BookingApp.Core.CQRS
{
    public interface ICommand : ICommand<Unit>
    {
    }

    public interface ICommand<out T> : IRequest<T>
        where T : notnull
    {
    }
}
