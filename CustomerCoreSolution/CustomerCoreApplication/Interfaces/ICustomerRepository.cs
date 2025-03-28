using CustomerCoreApplication.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerCoreApplication.Interfaces
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<CustomerDto>> GetAllAsync();
        Task<CustomerDto?> GetByIdAsync(int id);
        Task AddAsync(CustomerDto customer);
        Task UpdateAsync(CustomerDto customer);
        Task DeleteAsync(int id);
    }
}
