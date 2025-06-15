using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Patrik_Pospisil_Portfolio_Web.Data;
using Patrik_Pospisil_Portfolio_Web.Models;
using System.Threading.Tasks;

namespace Patrik_Pospisil_Portfolio_Web.Pages
{
    public class ContactModel : PageModel
    {
        private readonly AppDbContext _context;

        public ContactModel(AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ContactMessage Message { get; set; } = new ContactMessage();

        public void OnGet()
        {
            // Na�ten� str�nky - nen� t�eba nic speci�ln�ho d�lat
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                // Pokud validace sel�e, zobraz znovu formul�� s chybami
                return Page();
            }

            // Nastav �as vytvo�en� zpr�vy
            Message.DateSent = System.DateTime.Now;

            // Ulo� zpr�vu do datab�ze
            _context.ContactMessages.Add(Message);
            await _context.SaveChangesAsync();

            // Nastav zpr�vu o �sp�chu, kter� se zobraz� u�ivateli
            TempData["SuccessMessage"] = "Thank you for contacting me! I will get back to you soon.";

            // P�esm�ruj na GET metodu, aby nedo�lo k op�tovn�mu odesl�n� formul��e p�i refreshi str�nky
            return RedirectToPage();
        }
    }
}
