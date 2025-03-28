using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerCoreApplication.Interfaces
{
    public interface IUnitOfWork
    {
        ICustomerRepository Customers { get; }
        Task<int> SaveChangesAsync();
    }
}
