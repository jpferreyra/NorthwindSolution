using Dapper;
using Northwind.Models;
using Northwind.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Northwind.DataAccess
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(string connectionString):base(connectionString)
        {
        }

        public IEnumerable<Customer> CustomerPagedList(int page, int rows)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@page", page);
            parameters.Add("@rows", rows);

            using (var connection = new SqlConnection(connectionString))
            {
                return connection.Query<Customer>("dbo.CustomerPagedList",
                                                parameters,
                                                commandType: System.Data.CommandType.StoredProcedure);
            }
        }
    }
}
