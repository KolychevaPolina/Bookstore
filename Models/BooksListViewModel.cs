using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace BookStore.Models
{
    public class BooksListViewModel
    {
        public IEnumerable<Book> Books { get; set; }
        public SelectList Genres { get; set; }
        public SelectList Countries { get; set; }
        public SelectList Languages { get; set; }
        public SelectList Covers { get; set; }
        public IEnumerable<Purchase> Purchases { get; set; }
        public SelectList Persons { get; set; }
        public SelectList BookIds { get; set; }
    }
}