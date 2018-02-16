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
            var authors = new List<Author>
            {
            new Author {ID="1234", Name = "Alberto", JoinDate = DateTime.Parse("2002-07-06"), location="USA"},
            new Author {ID="1235", Name = "Akshay", JoinDate = DateTime.Parse("1995-03-11"), location="USA"},
            new Author {ID="1236", Name = "Doseon", JoinDate = DateTime.Parse("2001-01-15"), location="USA"},
            new Author {ID="1237", Name = "Ryan", JoinDate = DateTime.Parse("2004-02-12"), location="USA"}
            };
            authors.ForEach(s => context.Authors.AddOrUpdate(p => p.Name, s));
            context.SaveChanges();


            var markets = new List<Market>
            {
                new Market{AuthorID=authors.Single( s => s.Name == "Alberto").ID,
                    Title ="Used Honda Civic 2017", Option=TradeOption.Selling, PostDate=DateTime.Parse("2005-09-01"), Price=5000,
                    Post ="New beautiful car that I recently crashed." },

                new Market{AuthorID=authors.Single( s => s.Name == "Akshay").ID,
                    Title ="Gaming Laptop", Option=TradeOption.Selling, PostDate=DateTime.Parse("2012-12-02"), Price=1000,
                    Post ="Selling a laptop for gaming." },

                new Market{AuthorID=authors.Single( s => s.Name == "Doseon").ID,
                    Title ="Banana", Option=TradeOption.Buying, PostDate=DateTime.Parse("2015-03-04"), Price=1,
                    Post ="Buying a ripe banana."},

                new Market{AuthorID=authors.Single( s => s.Name == "Alberto").ID,
                    Title ="Airplane", Option=TradeOption.Buying, PostDate=DateTime.Parse("2017-03-04"), Price=10000,
                    Post ="I keep crashing my car, so I want to drive a plane instead."},

                new Market{AuthorID=authors.Single( s => s.Name == "Akshay").ID,
                    Title ="House", Option=TradeOption.Buying, PostDate=DateTime.Parse("2017-05-04"), Price= 5000,
                    Post ="I accidentally burned down my house, I need a new place."},

                new Market{AuthorID=authors.Single( s => s.Name == "Ryan").ID,
                    Title ="Bus", Option=TradeOption.Buying, PostDate=DateTime.Parse("2018-01-04"), Price= 1500,
                    Post ="I'm tired of commuting so I'll drive my own bus."},

                new Market{AuthorID=authors.Single( s => s.Name == "Doseon").ID,
                    Title ="phone", Option=TradeOption.Sold, PostDate=DateTime.Parse("2017-12-04"), Price= 1500,
                    Post ="Selling my Nexus 5 in mint condition."},

                new Market{AuthorID=authors.Single( s => s.Name == "Alberto").ID,
                    Title ="glasses", Option=TradeOption.Traded, PostDate=DateTime.Parse("2018-1-01"), Price= 0,
                    Post ="I'm looking to trade my glasses for cooler ones."}
            };
            markets.ForEach(s => context.Markets.AddOrUpdate(p => p.Title, s));
            context.SaveChanges();

            var comments = new List<Comment>
            {
                new Comment{MarketID=markets.Single(s => s.Title == "Used Honda Civic 2017").ID, Content="You suck alberto",
                    AuthorID=authors.Single( s => s.Name == "Akshay").ID, CommentDate=DateTime.Parse("2005-09-03")},
                new Comment{MarketID=markets.Single(s => s.Title == "Used Honda Civic 2017").ID, Content="$500",
                AuthorID=authors.Single( s => s.Name == "Doseon").ID, CommentDate=DateTime.Parse("2005-09-03")},
                new Comment{MarketID=markets.Single(s => s.Title == "Gaming Laptop").ID, Content="This laptop is top model!",
                    AuthorID=authors.Single( s => s.Name == "Ryan").ID, CommentDate=DateTime.Parse("2012-12-02")},
                new Comment{MarketID=markets.Single(s => s.Title == "Banana").ID, Content="This is the wrong place to buy a banana!",
                    AuthorID=authors.Single( s => s.Name == "Alberto").ID, CommentDate=DateTime.Parse("2015-03-04")},
                new Comment{MarketID=markets.Single(s => s.Title == "Airplane").ID, Content="10,000 is too cheap for an airplane.",
                   AuthorID=authors.Single( s => s.Name == "Doseon").ID, CommentDate=DateTime.Parse("2017-03-04")}
            };
            comments.ForEach(s => context.Comments.AddOrUpdate(p => p.Content, s));
            context.SaveChanges();
        }
    }
}
