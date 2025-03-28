using CustomerCoreApplication.DTOs;
using CustomerCoreApplication.Interfaces;
using CustomerCoreDomain.Entities;
using CustomerCoreInfrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace CustomerCoreInfrastructure.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly AppDbContext _context;

        public CustomerRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CustomerDto>> GetAllAsync()
        {
            return await _context.Customers
                .Select(c => new CustomerDto
                {
                    CustomerID = c.CustomerID,
                    Name = c.Name,
                    Email = c.Email,
                    PhoneNumber = c.PhoneNumber
                }).ToListAsync();
        }

        public async Task<CustomerDto?> GetByIdAsync(int id)
        {
            var c = await _context.Customers.FindAsync(id);
            return c == null ? null : new CustomerDto
            {
                CustomerID = c.CustomerID,
                Name = c.Name,
                Email = c.Email,
                PhoneNumber = c.PhoneNumber
            };
        }

        public async Task AddAsync(CustomerDto customer)
        {
            var entity = new Customer
            {
                Name = customer.Name,
                Email = customer.Email,
                PhoneNumber = customer.PhoneNumber
            };
            _context.Customers.Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(CustomerDto customer)
        {
            var entity = await _context.Customers.FindAsync(customer.CustomerID);
            if (entity == null) return;

            entity.Name = customer.Name;
            entity.Email = customer.Email;
            entity.PhoneNumber = customer.PhoneNumber;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null) return;

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
        }
    }
}