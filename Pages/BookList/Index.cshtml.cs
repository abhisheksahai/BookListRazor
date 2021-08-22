using BookListRazor.Model;
using BookListRazor.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;

namespace BookListRazor.Pages.BookList
{
    public class IndexModel : PageModel
    {
        private readonly IBookRepository _br;
        public IndexModel(IBookRepository br)
        {
            _br = br ?? throw new ArgumentNullException(nameof(IBookRepository));
        }

        public IEnumerable<Book> Books { get; set; }
        public void OnGet()
        {
            Books = _br.GetBooks();
        }

        public IActionResult OnPostDelete(int Id)
        {
            if (!_br.DeleteBook(Id))
            {
                return NotFound();
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}