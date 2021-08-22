using BookListRazor.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookListRazor.Services
{
    public class BookRepository : IBookRepository, IDisposable
    {
        private readonly ApplicationDbContext _db;
        public BookRepository(ApplicationDbContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(ApplicationDbContext));
        }

        public IEnumerable<Book> GetBooks()
        {
            return _db.Book.ToList();
        }

        public Book BookExists(int Id)
        {
            return _db.Book.Find(Id);
        }

        public Book AddBook(Book book)
        {
            _db.Book.Add(book);
            Save();
            return book;
        }

        public bool DeleteBook(int Id)
        {
            bool status = false;
            var bookFromDb = _db.Book.Find(Id);
            if (bookFromDb != null)
            {
                _db.Book.Remove(bookFromDb);
                status = Save();
            }
            return status;
        }

        public void UpdateBook(Book book)
        {
            var bookFromDb = _db.Book.Find(book.Id);
            bookFromDb.Name = book.Name;
            bookFromDb.Author = book.Author;
            bookFromDb.ISBN = book.ISBN;
            Save();
        }

        public bool Save()
        {
            int stateCount = _db.SaveChanges();
            return (stateCount >= 0);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {

            }
        }
    }
}
