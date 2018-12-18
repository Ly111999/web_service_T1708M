using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Book_WCFRest
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "BookService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select BookService.svc or BookService.svc.cs at the Solution Explorer and start debugging.
    public class BookService : IBookService
    {
        static IBookRepository repository = new BookRepository();
        public List<Book> GetBookList()
        {
            return repository.GetBooks();
        }

        public Book GetBookById(string id)
        {
            return repository.GetBookById(int.Parse(id));
        }

        public string AddBook(Book book)
        {
            Book newBook = repository.AddNewBook(book);
            return "id =" + newBook.BookID;
        }

        public string UpdateBook(Book book)
        {
            bool deleted = repository.Update(book);
            if (deleted)
            {
                return "Updated successfully! Book with id=" + book.BookID;
            }
            else
            {
                return "Update false!";
            }
        }

        public string DeleteBook(string id)
        {
            bool deleted = repository.Delete(int.Parse(id));
            if (deleted)
                return "Deleted successfully!";
            else
                return "Delete false!";
        }
    }
}
