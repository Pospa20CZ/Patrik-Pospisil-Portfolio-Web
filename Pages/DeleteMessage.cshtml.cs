using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Patrik_Pospisil_Portfolio_Web.Data;
using Patrik_Pospisil_Portfolio_Web.Models;
using System.Threading.Tasks;

namespace Patrik_Pospisil_Portfolio_Web.Pages
{
    public class DeleteMessageModel : PageModel
    {
        private readonly AppDbContext _context;

        public DeleteMessageModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ContactMessage? Message { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Message = await _context.ContactMessages.FindAsync(id);

            if (Message == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (Message == null || Message.Id == 0)
            {
                return NotFound();
            }

            var messageToDelete = await _context.ContactMessages.FindAsync(Message.Id);

            if (messageToDelete == null)
            {
                return NotFound();
            }

            _context.ContactMessages.Remove(messageToDelete);
            await _context.SaveChangesAsync();

            return RedirectToPage("/Messages");
        }
    }
}
