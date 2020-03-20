using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string CountryName { get; set; }
        [Display(Name = "Страна производства")]
        public ICollection<Country> Countries { get; set; }
        public Country()
        {
            Countries = new List<Country>();
        }
    }
}