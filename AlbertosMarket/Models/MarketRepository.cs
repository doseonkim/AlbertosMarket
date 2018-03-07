using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using AlbertosMarket.Models;
using System.Data.Entity;

namespace AlbertosMarket.DAL
{
    public class MarketRepository : IMarketRepository, IDisposable
    {
        private MarketContext context;

        public MarketRepository(MarketContext context)
        {
            this.context = context;
        }

        public IEnumerable<Market> GetMarkets()
        {
            return context.Markets.ToList();
        }

        public Market GetMarketById(int id)
        {
            return context.Markets.Find(id);
        }

        public void InsertMarket(Market market)
        {
            context.Markets.Add(market);
        }

        public void DeleteMarket(int MarketID)
        {
            Market Market = context.Markets.Find(MarketID);
            context.Markets.Remove(Market);
        }

        public void UpdateMarket(Market Market)
        {
            context.Entry(Market).State = EntityState.Modified;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}