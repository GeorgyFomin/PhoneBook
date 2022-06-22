using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RazorPagesPhoneBook.Models;

namespace RazorPagesPhoneBook.Pages.PhoneBook
{
#pragma warning disable CS8618
    public class CreateModel : PageModel
    {
        private readonly RazorPagesPhoneBook.Data.RazorPagesPhoneBookContext _context;

        public CreateModel(RazorPagesPhoneBook.Data.RazorPagesPhoneBookContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Phone Phone { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Phone.Add(Phone);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
#pragma warning restore CS8618
}
