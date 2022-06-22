using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPagesPhoneBook.Models;

namespace RazorPagesPhoneBook.Pages.PhoneBook
{
    public class DetailsModel : PageModel
    {
        private readonly RazorPagesPhoneBook.Data.RazorPagesPhoneBookContext _context;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public DetailsModel(RazorPagesPhoneBook.Data.RazorPagesPhoneBookContext context)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            _context = context;
        }

        public Phone Phone { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

#pragma warning disable CS8601 // Possible null reference assignment.
            Phone = await _context.Phone.FirstOrDefaultAsync(m => m.ID == id);
#pragma warning restore CS8601 // Possible null reference assignment.

            if (Phone == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
