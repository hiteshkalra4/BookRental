using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BookRentalPortal.Models;
using BookRentalPortal.Utility;
using BookRentalPortal.ViewModel;

namespace BookRentalPortal.Controllers
{
    [Authorize(Roles = SD.AdminUserRole)]
    public class BookController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Book
        // retrive all books
        public ActionResult Index()
        {
            var books = db.Books.Include(b => b.Genre);
            return View(books.ToList());
        }

        // GET: Book/Details/5
        //retrieve book based on id
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }

            var model = new BookViewModel
            {
                Book = book,
                Genres = db.Genres.ToList()
            };
            return View(model);
        }

        // GET: Book/Create 
        //get method for creating a new book
        public ActionResult Create()
        {
            var genre = db.Genres.ToList();
            var model = new BookViewModel
            {
                Genres = genre
            };
            return View(model);
        }

        // POST: Book/Create
        // post method for adding new book
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BookViewModel bookVM)
        {
            var book = new Book
            {
                Author = bookVM.Book.Author,
                Avaibility = bookVM.Book.Avaibility,
                DateAdded = bookVM.Book.DateAdded,
                Description = bookVM.Book.Description,
                Genre = bookVM.Book.Genre,
                GenreId = bookVM.Book.GenreId,
                ImageUrl = bookVM.Book.ImageUrl,
                ISBN = bookVM.Book.ISBN,
                Pages = bookVM.Book.Pages,
                Price = bookVM.Book.Price,
                Publisher = bookVM.Book.Publisher,
                ProductDimension = bookVM.Book.ProductDimension,
                PublicationDate = bookVM.Book.PublicationDate,
                Title = bookVM.Book.Title
            };

            if (ModelState.IsValid)
            { 
                db.Books.Add(book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            bookVM.Genres = db.Genres.ToList();
            return View(bookVM);

        }

        // GET: Book/Edit/5
        //retrive selected book detials for edit
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            var model = new BookViewModel
            {
                Book = book,
                Genres = db.Genres.ToList()
            };

            return View(model);
        }

        // POST: Book/Edit/5
        // post method to edit book details
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit(BookViewModel bookVM)
        {
            var book = new Book
            {
                Id = bookVM.Book.Id,
                Author = bookVM.Book.Author,
                Avaibility = bookVM.Book.Avaibility,
                DateAdded = bookVM.Book.DateAdded,
                Description = bookVM.Book.Description,
                Genre = bookVM.Book.Genre,
                GenreId = bookVM.Book.GenreId,
                ImageUrl = bookVM.Book.ImageUrl,
                ISBN = bookVM.Book.ISBN,
                Pages = bookVM.Book.Pages,
                Price = bookVM.Book.Price,
                Publisher = bookVM.Book.Publisher,
                ProductDimension = bookVM.Book.ProductDimension,
                PublicationDate = bookVM.Book.PublicationDate,
                Title = bookVM.Book.Title
            };

            if (ModelState.IsValid)
            {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            bookVM.Genres = db.Genres.ToList();
            return View(bookVM);
        }

        // GET: Book/Delete/5
        // retrive selected book details for delete
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            var model = new BookViewModel
            {
                Book = book,
                Genres = db.Genres.ToList()
            };
            return View(model);
        }

        // POST: Book/Delete/5
        // post method for delete book
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Book book = db.Books.Find(id);
            db.Books.Remove(book);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
