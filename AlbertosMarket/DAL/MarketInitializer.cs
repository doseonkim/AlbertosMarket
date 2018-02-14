using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using AlbertosMarket.Models;

namespace AlbertosMarket.DAL
{
    public class MarketInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<MarketContext>
    {
        protected override void Seed(MarketContext context)
        {
            var threads = new List<Market>
            {
                new Market{Author=new Author {Name="Alberto" },Title="Used Honda Civic 2017", Option=TradeOption.Selling, PostDate=DateTime.Parse("2005-09-01"), Price=5000,
                    Post ="New beautiful car that I recently crashed."}
            };

            threads.ForEach(s => context.Markets.Add(s));
            context.SaveChanges();
            var comments = new List<Comment>
            {
            new Comment{CommentID=1, MarketID=1,Content="You suck alberto", Author=new Author {Name="Akshay" }, CommentDate=DateTime.Parse("2005-09-02")},
            new Comment{CommentID=2, MarketID=1,Content="$500", Author=new Author {Name="Doseon" }, CommentDate=DateTime.Parse("2005-09-03")}
            };
            comments.ForEach(s => context.Comments.Add(s));
            context.SaveChanges();
        }
    }
}