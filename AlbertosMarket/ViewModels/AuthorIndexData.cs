using AlbertosMarket.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlbertosMarket.ViewModels
{
    public class AuthorIndexData
    {
        public IEnumerable<Author> Authors { get; set; }
        public IEnumerable<Market> Markets { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
    }
}