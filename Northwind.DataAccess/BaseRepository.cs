using Dapper.Contrib.Extensions;
using Northwind.Repositories;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Northwind.DataAccess
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected string connectionString;

        public BaseRepository(string connectionString)
        {
            SqlMapperExtensions.TableNameMapper = (type) => { return $"{ type.Name}"; };
            this.connectionString = connectionString;
        }
        public bool Delete(T entity)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                return connection.Delete(entity);
            }
        }

        public T GetById(int Id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                return connection.Get<T>(Id);
            }
        }

        public IEnumerable<T> GetList()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                return connection.GetAll<T>();
            }
        }

        public int Insert(T entity)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                return (int)connection.Insert<T>(entity);
            }
        }

        public bool Update(T entity)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                return connection.Update<T>(entity);
            }
        }
    }
}
