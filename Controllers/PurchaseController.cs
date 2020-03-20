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
    public class PurchaseController : Controller
    {
        BookContext db = new BookContext();
        public ActionResult Index(int? bookId, string person)
        {
            IQueryable<Purchase> purchases = db.Purchases;
            if (bookId != null && bookId != 0)
            {
                purchases = purchases.Where(p => p.BookId == bookId);
            }
            if (!String.IsNullOrEmpty(person) && !person.Equals("Все"))
            {
                purchases = purchases.Where(p => p.Person == person);
            }
            List<int> bookIds = db.Purchases.Select(p => p.BookId).Distinct().ToList();
            bookIds.Insert(0, 0);
            List<string> persons = db.Purchases.Select(p => p.Person).Distinct().ToList();
            persons.Insert(0, "Все");
            BooksListViewModel blvm = new BooksListViewModel
            {
                Purchases = purchases.ToList(),
                BookIds = new SelectList(bookIds),
                Persons = new SelectList(persons)
                
            };
            return View(blvm);
        }
    }
}