using BookListRazor.Model;
using BookListRazor.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace BookListRazor.Pages.BookList
{
    public class EditModel : PageModel
    {
        private readonly IBookRepository _br;

        public EditModel(IBookRepository br)
        {
            _br = br ?? throw new ArgumentNullException(nameof(IBookRepository));
        }

        [BindProperty]
        public Book book { get; set; }

        public void OnGet(int Id)
        {
            book = _br.BookExists(Id);
        }
    }
}
