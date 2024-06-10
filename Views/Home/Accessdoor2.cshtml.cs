using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using Heysundue.Models;
using Heysundue.Data;
using System.Threading.Tasks;

namespace Heysundue.Pages
{
    public class Accessdoor2Model : PageModel
    {
        private readonly ArticleContext _context;

        public Accessdoor2Model(ArticleContext context)
        {
            _context = context;
            Accessdoor = new Accessdoor();
        }

        [BindProperty]
        public Accessdoor Accessdoor { get; set; }

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

            _context.Accessdoor.Add(Accessdoor);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}