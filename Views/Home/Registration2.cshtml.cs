using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using Heysundue.Models;
using Heysundue.Data;

namespace Heysundue.Pages
{
    public class Registration2Model : PageModel
    {
        private readonly ArticleContext _context;

        public Registration2Model(ArticleContext context)
        {
            _context = context;
            Registration = new Registration();
        }

        [BindProperty]
        public Registration Registration { get; set; }

        public IActionResult OnGet()
        {
            ViewData["Title"] = "Registration Category設定";
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewData["Title"] = "Registration Category設定";
                return Page();
            }

            _context.Registrations.Add(Registration);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
