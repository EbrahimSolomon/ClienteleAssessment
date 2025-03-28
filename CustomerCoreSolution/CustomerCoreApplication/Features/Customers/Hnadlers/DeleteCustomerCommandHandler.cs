using CustomerCoreApplication.Features.Customers.Commands;
using CustomerCoreApplication.Interfaces;
using MediatR;

namespace CustomerCoreApplication.Features.Customers.Hnadlers
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommand, Unit>
    {
        private readonly IUnitOfWork _uow;

        public DeleteCustomerCommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<Unit> Handle(DeleteCustomerCommand request, CancellationToken cancellationToken)
        {
            await _uow.Customers.DeleteAsync(request.Id);
            await _uow.SaveChangesAsync();
            return Unit.Value;
        }
    }
}
