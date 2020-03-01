using Northwind.Models;
using System.Collections.Generic;

namespace Northwind.Repositories
{
    public interface ICustomerRepository : IBaseRepository<Customer>
    {
        IEnumerable<Customer> CustomerPagedList(int page, int rows);
    }
}
