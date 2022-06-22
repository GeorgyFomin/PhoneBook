using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesPhoneBook.Models;

namespace RazorPagesPhoneBook.Pages.PhoneBook
{
#pragma warning disable CS8618
#pragma warning disable CS8601 // Possible null reference assignment.
    public class DeleteModel : PageModel
    {
        private readonly RazorPagesPhoneBook.Data.RazorPagesPhoneBookContext _context;

        public DeleteModel(RazorPagesPhoneBook.Data.RazorPagesPhoneBookContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Phone Phone { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Phone = await _context.Phone.FirstOrDefaultAsync(m => m.ID == id);

            if (Phone == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Phone = await _context.Phone.FindAsync(id);

            if (Phone != null)
            {
                _context.Phone.Remove(Phone);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
#pragma warning restore CS8601 // Possible null reference assignment.
#pragma warning restore CS8618
}
