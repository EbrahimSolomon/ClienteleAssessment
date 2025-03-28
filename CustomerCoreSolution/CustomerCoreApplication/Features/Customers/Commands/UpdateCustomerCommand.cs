using CustomerCoreApplication.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerCoreApplication.Features.Customers.Commands
{
    public record UpdateCustomerCommand(CustomerDto Customer) : IRequest<Unit>;
}
