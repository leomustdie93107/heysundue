using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using Heysundue.Models;
using Heysundue.Data;
using System.Threading.Tasks;

namespace Heysundue.Pages
{
    public class Doorsystem2Model : PageModel
    {
        private readonly ArticleContext _context;

        public Doorsystem2Model(ArticleContext context)
        {
            _context = context;
            Doorsystem = new Doorsystem();
        }

        [BindProperty]
        public Doorsystem Doorsystem { get; set; }

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

            _context.Doorsystem.Add(Doorsystem);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}