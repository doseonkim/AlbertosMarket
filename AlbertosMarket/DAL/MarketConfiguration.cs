using System.Data.Entity;
using System.Data.Entity.SqlServer;

namespace AlbertosMarket.DAL
{
    public class MarketConfiguration : DbConfiguration
    {
        public MarketConfiguration()
        {
            SetExecutionStrategy("System.Data.SqlClient", () => new SqlAzureExecutionStrategy());
        }
    }
}