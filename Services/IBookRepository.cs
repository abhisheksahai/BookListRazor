using BookListRazor.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookListRazor.Services
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetBooks();
        Book BookExists(int Id);
        Book AddBook(Book book);
        void UpdateBook(Book book);
        void DeleteBook(Book book);
        bool Save();
    }
}
