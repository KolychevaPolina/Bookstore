using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class Book
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Название книги")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Автор")]
        public string Author { get; set; }

        [Required]
        [Display(Name = "Цена")]
        public int Price { get; set; }
        
        public int? GenreId { get; set; }
        public Genre Genre { get; set; }
        
        public int? CountryId { get; set; }
        public Country Country { get; set; }
        
        public int? LanguageId { get; set; }
        public Language Language { get; set; }
       
        public int? CoverId { get; set; }
        public Cover Cover { get; set; }
    }
}