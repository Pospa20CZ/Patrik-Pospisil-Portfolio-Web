using Microsoft.EntityFrameworkCore;
using Patrik_Pospisil_Portfolio_Web.Models;

namespace Patrik_Pospisil_Portfolio_Web.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<ContactMessage> ContactMessages { get; set; }
    }
}
