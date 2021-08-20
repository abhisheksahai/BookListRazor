using BookListRazor.Model;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;

namespace BookListRazor.Pages.BookList
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public CreateModel(ApplicationDbContext db)
        {
            _db = db ?? throw new ArgumentNullException(nameof(ApplicationDbContext));
        }

        public Book book { get; set; }
        public void OnGet()
        {
        }
    }
}
