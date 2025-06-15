using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Patrik_Pospisil_Portfolio_Web.Data;
using Patrik_Pospisil_Portfolio_Web.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Patrik_Pospisil_Portfolio_Web.Pages
{
    public class MessagesModel : PageModel
    {
        private readonly AppDbContext _context;

        public MessagesModel(AppDbContext context)
        {
            _context = context;
        }

        public IList<ContactMessage> Messages { get; set; } = new List<ContactMessage>();

        public async Task OnGetAsync()
        {
            Messages = await _context.ContactMessages
                .OrderByDescending(m => m.DateSent)
                .ToListAsync();
        }
    }
}
