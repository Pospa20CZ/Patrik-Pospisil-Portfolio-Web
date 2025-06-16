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
            // Naètení stránky - není tøeba nic speciálního dìlat
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                // Pokud validace selže, zobraz znovu formuláø s chybami
                return Page();
            }

            // Nastav èas vytvoøení zprávy
            Message.DateSent = System.DateTime.Now;

            // Ulož zprávu do databáze
            _context.ContactMessages.Add(Message);
            await _context.SaveChangesAsync();

            // Nastav zprávu o úspìchu, která se zobrazí uživateli
            TempData["SuccessMessage"] = "Thank you for contacting me! I will get back to you soon.";

            // Pøesmìruj na GET metodu, aby nedošlo k opìtovnému odeslání formuláøe pøi refreshi stránky
            return RedirectToPage();
        }
    }
}
