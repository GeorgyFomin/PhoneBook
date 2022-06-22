using Microsoft.EntityFrameworkCore;

namespace RazorPagesPhoneBook.Data
{
    public class RazorPagesPhoneBookContext : DbContext
    {
        public RazorPagesPhoneBookContext(DbContextOptions<RazorPagesPhoneBookContext> options)
            : base(options)
        {
        }

        public DbSet<RazorPagesPhoneBook.Models.Phone> Phone { get; set; } = null!;
    }
}
