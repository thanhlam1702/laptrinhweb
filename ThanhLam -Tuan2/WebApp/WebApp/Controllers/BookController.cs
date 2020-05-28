using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApp.Models;

namespace WebApp.Controllers
{
    public class BookController : Controller
    {
        
        // GET: Book
        public string HelloTeacher()
        {
            return "Hello Nguyen Dinh Anh";
        }
        public ActionResult ListBook()
        {
            var books = new List<string>();
            books.Add("Book2");
            books.Add("Book2");
            books.Add("Book3");
            ViewBag.Books = books;
            return View();
        }
        public ActionResult ListBookModel()
        {
            var books = new List<Book>();
            books.Add(new Book(1, "Book 1", "Tran Thi Deo", "/Content/Images/book1.jpg"));
            books.Add(new Book(2, "Book 2", "NguyenThi Hanh Phuc", "/Content/Images/book2.jpg"));
            books.Add(new Book(3, "Book 3", "Nguyen Van Teo", "/Content/Images/book3.jpg"));
            return View(books);
        }

        public ActionResult EditBook(int? id)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "Book 1", "Tran Thi Deo", "/Content/Images/book1.jpg"));
            books.Add(new Book(2, "Book 2", "NguyenThi Hanh Phuc", "/Content/Images/book2.jpg"));
            books.Add(new Book(3, "Book 3", "Nguyen Van Teo", "/Content/Images/book3.jpg"));
            Book book = new Book();
            foreach (Book b in books)
            {
                if (b.Id == id)
                {
                    book = b;
                    break;
                }
            }
            if (book == null) return HttpNotFound();
            return View(book);
        }
        [HttpPost, ActionName("EditBook")]
        [ValidateAntiForgeryToken]
        public ActionResult EditBook(int? id, string Title, string Author, string ImageCover)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "Book 1", "Tran Thi Deo", "/Content/Images/book1.jpg"));
            books.Add(new Book(2, "Book 2", "NguyenThi Hanh Phuc", "/Content/Images/book2.jpg"));
            books.Add(new Book(3, "Book 3", "Nguyen Van Teo", "/Content/Images/book3.jpg"));
            if (id == null) return HttpNotFound();
            Book book = new Book();
            foreach (Book b in books)
            {
                if (b.Id == id)
                {
                    b.Title = Title;
                    b.Author = Author;
                    b.ImageCover = ImageCover;
                    break;
                }
            }
            return View("ListBookModel", books);
        }
        public ActionResult CreateBook()
        {
            return View();
        }
        [HttpPost, ActionName("CreateBook")]
        [ValidateAntiForgeryToken]

        public ActionResult Contact([Bind(Include = "Id, Title, Author, ImageCover")]Book book)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "Book 1", "Tran Thi Deo", "/Content/Images/book1.jpg"));
            books.Add(new Book(2, "Book 2", "NguyenThi Hanh Phuc", "/Content/Images/book2.jpg"));
            books.Add(new Book(3, "Book 3", "Nguyen Van Teo", "/Content/Images/book3.jpg"));
            try
            {
                if (ModelState.IsValid)
                {
                    books.Add(book);
                }
            }
            catch (RetryLimitExceededException)
            {
                ModelState.AddModelError("", "Error Save Data");
            }
            return View("ListBookModel", books);
        }

    }
}