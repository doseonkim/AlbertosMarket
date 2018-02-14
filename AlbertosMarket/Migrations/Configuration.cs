namespace AlbertosMarket.Migrations
{
    using AlbertosMarket.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AlbertosMarket.DAL.MarketContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AlbertosMarket.DAL.MarketContext context)
        {
            Author alberto, akshay, doseon, ryan;
            alberto = new Author { Name = "Alberto" };
            akshay = new Author { Name = "Akshay" };
            doseon = new Author { Name = "Doseon" };
            ryan = new Author { Name = "Ryan" };



            var markets = new List<Market>
            {
                new Market{Author=alberto,Title="Used Honda Civic 2017", Option=TradeOption.Selling, PostDate=DateTime.Parse("2005-09-01"), Price=5000,
                    Post ="New beautiful car that I recently crashed." },

                new Market{Author=akshay,Title="Gaming Laptop", Option=TradeOption.Selling, PostDate=DateTime.Parse("2012-12-02"), Price=1000,
                    Post ="Selling a laptop for gaming." },

                new Market{Author=doseon,Title="Banana", Option=TradeOption.Buying, PostDate=DateTime.Parse("2015-03-04"), Price=1,
                    Post ="Buying a ripe banana."},

                new Market{Author=alberto,Title="Airplane", Option=TradeOption.Buying, PostDate=DateTime.Parse("2017-03-04"), Price=10000,
                    Post ="I keep crashing my car, so I want to drive a plane instead."},

                new Market{Author=akshay,Title="House", Option=TradeOption.Buying, PostDate=DateTime.Parse("2017-05-04"), Price= 5000,
                    Post ="I accidentally burned down my house, I need a new place."},

                new Market{Author=ryan,Title="Bus", Option=TradeOption.Buying, PostDate=DateTime.Parse("2018-01-04"), Price= 1500,
                    Post ="I'm tired of commuting so I'll drive my own bus."},

                new Market{Author=doseon,Title="phone", Option=TradeOption.Sold, PostDate=DateTime.Parse("2017-12-04"), Price= 1500,
                    Post ="Selling my Nexus 5 in mint condition."},

                new Market{Author=alberto,Title="glasses", Option=TradeOption.Traded, PostDate=DateTime.Parse("2018-1-01"), Price= 0,
                    Post ="I'm looking to trade my glasses for cooler ones."}
            };
            markets.ForEach(s => context.Markets.AddOrUpdate(p => p.Title, s));
            context.SaveChanges();

            var comments = new List<Comment>
            {
                new Comment{CommentID=1,MarketID=markets.Single(s => s.Title == "Used Honda Civic 2017").ID, Content="You suck alberto", Author=akshay, CommentDate=DateTime.Parse("2005-09-02")},
                new Comment{CommentID=2,MarketID=markets.Single(s => s.Title == "Used Honda Civic 2017").ID, Content="$500", Author=doseon, CommentDate=DateTime.Parse("2005-09-03")},
                new Comment{CommentID=3,MarketID=markets.Single(s => s.Title == "Gaming Laptop").ID, Content="This laptop is top model!", Author=ryan, CommentDate=DateTime.Parse("2012-12-02")},
                new Comment{CommentID=4,MarketID=markets.Single(s => s.Title == "Banana").ID, Content="This is the wrong place to buy a banana!", Author=alberto, CommentDate=DateTime.Parse("2015-03-04")},
                new Comment{CommentID=5,MarketID=markets.Single(s => s.Title == "Airplane").ID, Content="10,000 is too cheap for an airplane.", Author=doseon, CommentDate=DateTime.Parse("2017-03-04")}
            };
            comments.ForEach(s => context.Comments.AddOrUpdate(p => p.Content, s));
            context.SaveChanges();
        }
    }
}
