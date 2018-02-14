using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AlbertosMarket.Models
{
    public enum TradeOption
    {
        Buying, Selling, Trading, Sold, Bought, Traded
    }

    public class Market
    {

        public int ID { get; set; }
        public Author Author { get; set; }
        public DateTime PostDate { get; set; }
        public TradeOption? Option { get; set; }
        public int Price { get; set; }

        public String Title { get; set; }

        [DataType(DataType.MultilineText)]
        public String Post { get; set; }

        public string Secret { get; set; }



        public virtual ICollection<Comment> Comments { get; set; }
    }
}