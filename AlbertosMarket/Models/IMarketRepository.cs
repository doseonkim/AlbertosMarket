using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlbertosMarket.Models
{
    using System;
    using System.Collections.Generic;

    public interface IMarketRepository : IDisposable
    {
        IEnumerable<Market> GetMarkets();
        Market GetMarketById(int marketId);
        void InsertMarket(Market market);
        void DeleteMarket(int marketId);
        void UpdateMarket(Market market);
        void Save();
    }

}