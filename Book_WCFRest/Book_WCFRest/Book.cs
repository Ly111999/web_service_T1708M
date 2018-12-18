using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Book_WCFRest
{
    [DataContract]
    public class Book
    {
        [DataMember]
        public int BookID { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string ISBN { get; set; }
    }

    public interface IBookRepository
    {
        List<Book> GetBooks();
        Book GetBookById(int id);
        Book AddNewBook(Book book);
        bool Delete(int id);
        bool Update(Book book);
    }

    public class BookRepository : IBookRepository
    {
        List<Book> books = new List<Book>();
        private int counter = 1;

        public BookRepository()
        {
            AddNewBook(new Book() {Title = "Webservice", ISBN = "123abc"});
            AddNewBook(new Book() {Title = "PHP developer", ISBN = "PHP"});
            AddNewBook(new Book() {Title = "Node.js", ISBN = "hay"});
        }
        public List<Book> GetBooks()
        {
            return books;
        }
        public Book GetBookById(int id)
        {
            return books.Find(b => b.BookID == id);
        }

        public Book AddNewBook(Book book)
        {
            if (book == null)
            {
                throw new NotImplementedException();
            }

            book.BookID = counter++;
            books.Add(book);
            return book;
        }

        public bool Delete(int id)
        {
            int idx = books.FindIndex(b => b.BookID == id);
            if (idx == -1)
            {
                return false;
            }
            books.RemoveAll(b => b.BookID == id);
            return true;
        }

        public bool Update(Book book)
        {
            int idx = books.FindIndex(b => b.BookID == book.BookID);
            if (idx == -1)
            {
                return false;
            }
            books.RemoveAt(idx);
            books.Add(book);
            return true;
        }
    }


}
