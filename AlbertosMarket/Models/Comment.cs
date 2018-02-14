﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlbertosMarket.Models
{
    public class Comment
    {

        public int CommentID { get; set; }
        public int AuthorID { get; set; }

        public int MarketID { get; set; }
        public string Content { get; set; }
        public DateTime CommentDate { get; set; }
        public virtual Market Market { get; set; }
        public virtual Author Author { get; set; }
    }
}