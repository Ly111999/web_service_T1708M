using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ConsumerRESTBook.Models;

namespace ConsumerRESTBook.Controllers
{
    public class BookController : Controller
    {
        BookServicesClient bookClient = new BookServicesClient();
        // GET: Book
        public ActionResult Index()
        {
            return View(bookClient.GetAllBooksClient());
        }

        // GET: Book/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Book/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: Book/Create
        [HttpPost]
        public ActionResult Create(Book book)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bookClient.AddBookClient(book);
                    return RedirectToAction("Index");
                }

                return View(book);
            }
            catch
            {
                return View();
            }
        }

        // GET: Book/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var book = bookClient.Find(id);
            if (book == null)
                return HttpNotFound();
            return View(book);
        }

        // POST: Book/Edit/5
        [HttpPost]
        public ActionResult Edit(Book book)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    bookClient.EditBookClient(book);
                    return RedirectToAction("Index");
                }

                return View("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Book/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Book/Delete/5
        [HttpPost]
        public ActionResult Delete(int? id, Book bookDe)
        {
            try
            {
                Book book = new Book();
                if (ModelState.IsValid)
                {
                    if (id == null)
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    book = bookClient.Find(id);
                    if (book == null)
                        return HttpNotFound();
                    bookClient.DeleteBookClient(book.BookID);
                    return RedirectToAction("Index");
                }

                return View(book);
            }
            catch
            {
                return View();
            }
        }
    }
}
