using CustomerCoreApplication.DTOs;
using CustomerCoreApplication.Features.Customers.Queries;
using CustomerCoreApplication.Interfaces;
using MediatR;

namespace CustomerCoreApplication.Features.Customers.Hnadlers
{
    public class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQuery, IEnumerable<CustomerDto>>
    {
        private readonly IUnitOfWork _uow;

        public GetAllCustomersQueryHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<IEnumerable<CustomerDto>> Handle(GetAllCustomersQuery request, CancellationToken cancellationToken)
        {
            return await _uow.Customers.GetAllAsync();
        }
    }
}
