using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using Heysundue.Models;
using Heysundue.Data;
using System.Threading.Tasks;

namespace Heysundue.Pages
{
    public class Joinlist2Model : PageModel
    {
        private readonly ArticleContext _context;

        public Joinlist2Model(ArticleContext context)
        {
            _context = context;
            Joinlist = new Joinlist();
        }

        [BindProperty]
        public Joinlist Joinlist { get; set; }

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

            _context.Joinlist.Add(Joinlist);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}