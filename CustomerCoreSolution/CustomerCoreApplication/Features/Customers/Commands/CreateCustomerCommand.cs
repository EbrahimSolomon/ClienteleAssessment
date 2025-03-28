using CustomerCoreApplication.DTOs;
using MediatR;

namespace CustomerCoreApplication.Features.Customers.Commands
{
    public record CreateCustomerCommand(CustomerDto Customer) : IRequest<int>;  // Return inserted ID
}
