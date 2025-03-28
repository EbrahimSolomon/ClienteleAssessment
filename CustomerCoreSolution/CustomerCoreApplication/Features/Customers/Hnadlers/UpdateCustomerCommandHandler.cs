using CustomerCoreApplication.Features.Customers.Commands;
using CustomerCoreApplication.Interfaces;
using MediatR;

namespace CustomerCoreApplication.Features.Customers.Handlers
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, Unit>
    {
        private readonly IUnitOfWork _uow;

        public UpdateCustomerCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<Unit> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            await _uow.Customers.UpdateAsync(request.Customer);
            await _uow.SaveChangesAsync();
            return Unit.Value;
        }
    }
}