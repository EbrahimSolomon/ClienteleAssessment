using CustomerCoreApplication.Features.Customers.Commands;
using CustomerCoreApplication.Interfaces;
using CustomerCoreDomain.Entities;
using MediatR;

namespace CustomerCoreApplication.Features.Customers.Hnadlers
{
    public class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, int>
    {
        private readonly IUnitOfWork _uow;

        public CreateCustomerCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<int> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            var entity = new Customer
            {
                Name = request.Customer.Name,
                Email = request.Customer.Email,
                PhoneNumber = request.Customer.PhoneNumber
            };

            await _uow.Customers.AddAsync(request.Customer);
            await _uow.SaveChangesAsync();

            return entity.CustomerID;
        }
    }
}

