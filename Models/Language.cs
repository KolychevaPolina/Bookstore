using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class Language
    {
        public int Id { get; set; }
        [Display(Name = "Язык издания")]
        public string LanguageName { get; set; }
        
        public ICollection<Language> Languages { get; set; }
        public Language()
        {
            Languages = new List<Language>();
        }
    }
}