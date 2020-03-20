using System.Collections.Generic;
using System.Linq;
using System.Web;
using System;
using System.Web.Mvc;
using BookStore.Models;
using System.Data.Entity;

namespace BookStore.Controllers
{
    [Authorize(Roles = "admin")]
    public class BookController : Controller
    {

        BookContext db = new BookContext();

        public ActionResult Index()
        {

            var books = db.Books.Include(p => p.Genre).Include(p => p.Country).Include(p => p.Language).Include(p => p.Cover);


            return View(books.ToList());
        }
        [HttpGet]
        public ActionResult EditBook(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Book book = db.Books.Find(id);
            if (book != null)
            {
                SelectList genres = new SelectList(db.Genres, "Id", "GenreName", book.GenreId);
                ViewBag.Genres = genres;
                SelectList countries = new SelectList(db.Countries, "Id", "CountryName", book.CountryId);
                ViewBag.Countries = countries;
                SelectList languages = new SelectList(db.Languages, "Id", "LanguageName", book.LanguageId);
                ViewBag.Languages = languages;
                SelectList covers = new SelectList(db.Covers, "Id", "CoverName", book.CoverId);
                ViewBag.Covers = covers;
                return View(book);
            }
            return HttpNotFound();
        }
        [HttpPost]
        public ActionResult EditBook(Book book)
        {
            if (ModelState.IsValid)
            {
                db.Entry(book).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
            }

            return RedirectToAction("EditBook") ;
        }
        [HttpGet]
        public ActionResult Create()
        {
            SelectList genres = new SelectList(db.Genres, "Id", "GenreName");
            ViewBag.Genres = genres;
            SelectList countries = new SelectList(db.Countries, "Id", "CountryName");
            ViewBag.Countries = countries;
            SelectList languages = new SelectList(db.Languages, "Id", "LanguageName");
            ViewBag.Languages = languages;
            SelectList covers = new SelectList(db.Covers, "Id", "CoverName");
            ViewBag.Covers = covers;
            return View();
        }
        [HttpPost]
        public ActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                db.Books.Add(book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return RedirectToAction("Create");
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            
            Book b = db.Books.Find(id);
            if (b == null)
            {
                return HttpNotFound();
            }
            
            return View(b);
        }
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Book b = db.Books.Find(id);
            if (b == null)
            {
                return HttpNotFound();
            }
            db.Books.Remove(b);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}