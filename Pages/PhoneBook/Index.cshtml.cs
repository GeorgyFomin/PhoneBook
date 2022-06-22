using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesPhoneBook.Models;

namespace RazorPagesPhoneBook.Pages.PhoneBook
{
#pragma warning disable CS8618
    public class IndexModel : PageModel
    {
        private readonly RazorPagesPhoneBook.Data.RazorPagesPhoneBookContext _context;

        public IndexModel(RazorPagesPhoneBook.Data.RazorPagesPhoneBookContext context)
        {
            _context = context;
        }

        public IList<Phone> Phone { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        //public SelectList Names { get; set; }
        //[BindProperty(SupportsGet = true)]
        //public string PhoneName { get; set; }
        public async Task OnGetAsync()
        {
            var phones = from m in _context.Phone
                         select m;
            if (!string.IsNullOrEmpty(SearchString) && !string.IsNullOrEmpty(SearchString.Trim()))
            {
                phones = phones.Where(s => s.Name.Contains(SearchString));
            }

            Phone = await phones.ToListAsync();
//            Phone = await _context.Phone.ToListAsync();
        }
    }
#pragma warning restore CS8618
}
