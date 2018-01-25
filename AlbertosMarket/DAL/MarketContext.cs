﻿using AlbertosMarket.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace AlbertosMarket.DAL
{
    public class MarketContext : DbContext
    {

        public MarketContext() : base("MarketContext")
        {
        }

        public DbSet<Market> Markets { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}