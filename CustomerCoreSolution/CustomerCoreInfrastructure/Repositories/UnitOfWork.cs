using CustomerCoreApplication.Interfaces;
using CustomerCoreInfrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerCoreInfrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        public ICustomerRepository Customers { get; }

        public UnitOfWork(AppDbContext context, ICustomerRepository customerRepo)
        {
            _context = context;
            Customers = customerRepo;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
