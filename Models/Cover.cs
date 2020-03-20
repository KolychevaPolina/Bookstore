using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class Cover
    {
        public int Id { get; set; }
        [Display(Name = "Вид обложки")]
        public string CoverName { get; set; }
        
        public ICollection<Cover> Covers { get; set; }
        public Cover()
        {
            Covers = new List<Cover>();
        }
    }
}