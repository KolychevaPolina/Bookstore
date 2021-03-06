﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Models
{
    public class Genre
    {
        public int Id { get; set; }
        [Display(Name = "Жанр")]
        public string GenreName { get; set; }
        
        public ICollection<Book> Books { get; set; }
        public Genre()
        {
            Books = new List<Book>();
        }
    }
}