using Devart.Data.Oracle;
using Store.Shared.Helpers;
using System.Data;

namespace Store.Infrastructure.Repository.Repositories.Base
{
    /// <summary>
    /// user this for dapper
    /// </summary>
    public interface IDbConnectionProvider
    {
        IDbConnection GetStoreDbConnection();
    }

    public class DbConnectionProvider : IDbConnectionProvider
    {
        private readonly IConnectionString _str;

        public DbConnectionProvider(IConnectionString str)
        {
            _str = str;
        }

        public IDbConnection GetStoreDbConnection()
        {
            var conn = new OracleConnection(_str.Store);
            if (conn.State != ConnectionState.Open) conn.Open();

            return conn;
        }
    }
}
