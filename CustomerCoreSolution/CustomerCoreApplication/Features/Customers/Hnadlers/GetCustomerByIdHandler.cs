using CustomerCoreApplication.DTOs;
using CustomerCoreApplication.Features.Queries;
using CustomerCoreApplication.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerCoreApplication.Features.Customers.Hnadlers
{
    public class GetCustomerByIdHandler : IRequestHandler<GetCustomerByIdQuery, CustomerDto?>
    {
        private readonly IUnitOfWork _uow;

        public GetCustomerByIdHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<CustomerDto?> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            return await _uow.Customers.GetByIdAsync(request.Id);
        }
    }
}