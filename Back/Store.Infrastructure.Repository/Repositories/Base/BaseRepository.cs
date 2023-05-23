
using Microsoft.Data.SqlClient;
using Store.Domain.Repository;
using System.Data;

namespace Store.Infrastructure.Repository.Repositories.Base
{
    public abstract class BaseRepository : IBaseRepository
    {
        private readonly string _connectionString;

        public BaseRepository(string? connectionString)
        {
            if (string.IsNullOrWhiteSpace(connectionString)) throw new Exception("BaseRepository connection string is empty");

            _connectionString = connectionString;
        }

        protected IDbConnection GetConnection()
        {
            var conn = new SqlConnection(_connectionString);
            
            if (conn.State != ConnectionState.Open) conn.Open();

            return conn;
        }
    }
}
