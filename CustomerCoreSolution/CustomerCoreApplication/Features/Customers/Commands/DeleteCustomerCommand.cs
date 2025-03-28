using MediatR;

namespace CustomerCoreApplication.Features.Customers.Commands
{
    public record DeleteCustomerCommand(int Id) : IRequest<Unit>;
}
