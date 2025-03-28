using CustomerCoreApplication.DTOs;
using MediatR;
using System.Collections.Generic;

namespace CustomerCoreApplication.Features.Customers.Queries
{
    public record GetAllCustomersQuery() : IRequest<IEnumerable<CustomerDto>>;
}
