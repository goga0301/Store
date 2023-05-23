using Microsoft.Extensions.Configuration;
namespace Shared.Helpers
{
    public interface IConnectionString
    {
        string Store { get; }
    }

    public class ConnectionString : IConnectionString
    {
        public string Store { get; private set; }
        public string Banking { get; private set; }

        public ConnectionString(IConfiguration configuration)
        {
            Store = configuration.GetConnectionString("StoreDb") ?? throw new ArgumentNullException("Store connection string is null");
            Banking = configuration.GetConnectionString("BankingDb") ?? throw new ArgumentNullException("Banking connection string is null");
        }
    }
}
