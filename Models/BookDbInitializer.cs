using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace BookStore.Models
{
    public class BookDbInitializer : DropCreateDatabaseAlways<BookContext>
    {
        protected override void Seed(BookContext db)
        {
            db.Books.Add(new Book { Name = "Пригоди Олівера Твіста", Author = "Діккенс Чарльз", Price = 41,GenreId =1, CountryId = 1, LanguageId = 1, CoverId = 1 });
            db.Books.Add(new Book { Name = "Аліса в країні чудес", Author = "Керрол Льюїс", Price = 37, GenreId = 1, CountryId = 1, LanguageId = 1, CoverId = 1 });
            db.Books.Add(new Book { Name = "Пігмаліон", Author = "Шоу Бернард", Price = 57, GenreId = 1, CountryId = 1, LanguageId = 1, CoverId = 1 });
            db.Books.Add(new Book { Name = "Портрет Доріана Грея", Author = "Уайльд Оскар", Price = 57 , GenreId = 2, CountryId = 2, LanguageId = 2, CoverId = 2 });
            db.Books.Add(new Book { Name = "Гордість і упередження", Author = "Остін Джейн", Price = 68 , GenreId = 2, CountryId = 2, LanguageId = 2, CoverId = 2 });
            db.Genres.Add(new Genre { Id = 1, GenreName = "Художественная литература" });
            db.Genres.Add(new Genre { Id = 2, GenreName = "Литература для детей и юношества" });
            db.Countries.Add(new Country { Id = 1, CountryName = "Украина" });
            db.Countries.Add(new Country { Id = 2, CountryName = "USA" });
            db.Languages.Add(new Language { Id = 1, LanguageName = "Украинский" });
            db.Languages.Add(new Language { Id = 2, LanguageName = "English" });
            db.Covers.Add(new Cover { Id = 1, CoverName = "твердая" });
            db.Covers.Add(new Cover { Id = 2, CoverName = "мягкая" });
            base.Seed(db);
        }
    }
}