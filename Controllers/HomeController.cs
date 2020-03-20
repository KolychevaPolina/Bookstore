using System.Collections.Generic;
using System.Linq;
using System.Web;
using System;
using System.Web.Mvc;
using BookStore.Models;
using System.Data.Entity;

namespace BookStore.Controllers
{
   
    public class HomeController : Controller
    {
        
        BookContext db = new BookContext();
        public ActionResult Index(int? genre, int? country, int? language, int? cover)
        {
            IQueryable<Book> books = db.Books.Include(p => p.Genre).Include(p => p.Country).Include(p => p.Language).Include(p => p.Cover);
            if (genre != null && genre != 0)
            {
                books = books.Where(p => p.GenreId == genre);
            }
            if (country != null && country != 0)
            {
                books = books.Where(p => p.CountryId == country);
            }
            if (language != null && language != 0)
            {
                books = books.Where(p => p.LanguageId == language);
            }
            if (cover != null && cover != 0)
            {
                books = books.Where(p => p.CoverId == cover);
            }

            List<Genre> genres = db.Genres.ToList();
            genres.Insert(0, new Genre { GenreName = "Все", Id = 0 });
            List<Country> countries = db.Countries.ToList();
            countries.Insert(0, new Country { CountryName = "Все", Id = 0 });
            List<Language> languages = db.Languages.ToList();
            languages.Insert(0, new Language { LanguageName = "Все", Id = 0 });
            List<Cover> covers = db.Covers.ToList();
            covers.Insert(0, new Cover { CoverName = "Все", Id = 0 });

            BooksListViewModel blvm = new BooksListViewModel
            {
                Books = books.ToList(),
                Genres = new SelectList(genres, "Id", "GenreName"),
                Countries = new SelectList(countries, "Id", "CountryName"),
                Languages = new SelectList(languages, "Id", "LanguageName"),
                Covers = new SelectList(covers, "Id", "CoverName")

            };
            return View(blvm);
        }
        
        [HttpGet]
        public ActionResult Buy(int id)
        {
            ViewBag.BookId = id;
            return View();
        }
        [HttpPost]
        public string Buy(Purchase purchase)
        {
            if (ModelState.IsValid)
            {
                purchase.Date = DateTime.Now;
            db.Purchases.Add(purchase);
            db.SaveChanges();
            return "Спасибо," + purchase.Person + ", за покупку!";
            }

            return "Заполните все поля!";

        }
       
    }
}