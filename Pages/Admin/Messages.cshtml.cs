using Microsoft.AspNetCore.Mvc.RazorPages;
using Patrik_Pospisil_Portfolio_Web.Models;
using Patrik_Pospisil_Portfolio_Web.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Patrik_Pospisil_Portfolio_Web.Pages.Admin
{
    public class MessagesModel : PageModel
    {
        private readonly AppDbContext _context;

        public MessagesModel(AppDbContext context)
        {
            _context = context;
        }

        public List<ContactMessage> Messages { get; set; } = new();

        public async Task OnGetAsync()
        {
            Messages = await _context.ContactMessages
                .OrderByDescending(m => m.DateSent)
                .ToListAsync();
        }
    }
}
