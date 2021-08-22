using BookListRazor.Model;
using BookListRazor.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace BookListRazor.Pages.BookList
{
    public class CreateModel : PageModel
    {
        private readonly IBookRepository _br;
        public CreateModel(IBookRepository br)
        {
            _br = br ?? throw new ArgumentNullException(nameof(ApplicationDbContext));
        }

        [BindProperty]
        public Book Book { get; set; }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _br.AddBook(Book);
                return RedirectToPage("Index");
            }
            else
            {
                return Page();
            }
        }
    }
}
