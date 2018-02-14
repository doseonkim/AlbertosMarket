using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;

namespace AlbertosMarket.Models
{
    public class Author
    {
        public int ID { get; set; }

        [Required]
        [Display(Name = "Username")]
        [StringLength(50)]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Join Date")]
        public DateTime JoinDate { get; set; }

        public String location { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<Market> Markets { get; set; }

    }
}