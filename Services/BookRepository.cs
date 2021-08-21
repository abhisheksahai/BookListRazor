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

        public void DeleteBook(Book book)
        {
            _db.Book.Remove(book);
            Save();
        }

        public void UpdateBook(Book book)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            return (_db.SaveChanges() >= 0);
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
