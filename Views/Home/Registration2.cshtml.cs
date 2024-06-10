using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using Heysundue.Models;
using Heysundue.Data;
using System.Threading.Tasks;

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
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Registration.Add(Registration);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
