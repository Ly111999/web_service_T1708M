using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ConsumerRESTBook.BookReferences;

namespace ConsumerRESTBook.Models
{
    public class BookServicesClient
    {
        BookServiceClient client = new BookServiceClient();
        //string BASE_URL = "http://localhost:53734/BookService.svc";

        public List<Book> GetAllBooksClient()
        {
            var list = client.GetBookList().ToList();
            var rt = new List<Book>();
            list.ForEach(b => rt.Add(new Book()
            {
                BookID = b.BookID,
                ISBN = b.ISBN,
                Title = b.Title
            }));
            return rt;

            //var syncClient = new WebClient();
            //var content = syncClient.DownloadString(BASE_URL + "Books");
            //var json_serializer = new JavaScriptSerializer();
            //return json_serializer.Deserialize<List<Book>>(content);
        }

        public string AddBookClient(Book newBook)
        {
            var book = new BookReferences.Book()
            {
                BookID = newBook.BookID,
                ISBN = newBook.ISBN,
                Title = newBook.Title
            };
            return client.AddBook(book);
        }

        public string DeleteBookClient(int id)
        {
            return client.DeleteBook(Convert.ToString(id));
        }

        public string EditBookClient(Book newBook)
        {
            var book = new BookReferences.Book()
            {
                BookID = newBook.BookID,
                ISBN = newBook.ISBN,
                Title = newBook.Title
            };
            return client.UpdateBook(book);
        }

        public Book Find(int? id)
        {
            var book = client.GetBookById(Convert.ToString(id));
            var bookId = new Book();

            bookId.BookID = book.BookID;
            bookId.Title = book.Title;
            bookId.ISBN = book.ISBN;
            return bookId;
        }
    }


}