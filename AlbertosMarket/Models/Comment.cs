﻿using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlbertosMarket.Models
{
    public class Comment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CommentID { get; set; }
        public int MarketID { get; set; }
        public string Author { get; set; }
        public string Content { get; set; }
        public DateTime CommentDate { get; set; }
        public virtual Market Market { get; set; }
    }
}