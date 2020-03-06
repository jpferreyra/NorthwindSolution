using Northwind.Models;
using System.Collections.Generic;

namespace Northwind.Repositories
{
    public interface IUserRepository: IBaseRepository<User>
    {
        User ValidateUser(string email, string password);
    }
}
