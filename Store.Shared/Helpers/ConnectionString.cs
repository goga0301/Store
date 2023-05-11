using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Shared.Helpers
{
    public interface IConnectionString
    {
        string Store { get; }
    }

    public class ConnectionString : IConnectionString
    {
        public string Store { get; private set; }

        public ConnectionString(IConfiguration configuration)
        {
            Store = configuration.GetConnectionString("StoreDb") ?? throw new ArgumentNullException("Store connection string is null");
        }
    }
}
