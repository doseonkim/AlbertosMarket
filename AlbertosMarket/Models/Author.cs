using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlbertosMarket.Models
{
    public class Author
    {
        public int AuthorID { get; set; }
        public String Name { get; set; }

        public override string ToString()
        {
            return Name.ToString();
        }
    }
}