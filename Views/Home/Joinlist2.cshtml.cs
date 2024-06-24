using Microsoft.AspNetCore.Mvc.RazorPages;
using Heysundue.Models;
using Heysundue.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc; // 確保引入了這個命名空間


namespace Heysundue.Pages
{
    public class Joinlist2Model : PageModel
    {
        private readonly ArticleContext _context;

        public Joinlist2Model(ArticleContext context)
        {
            _context = context;
        }

        public IList<Joinlist> Joinlists { get; set; }

        public async Task OnGetAsync()
        {
            Joinlists = await _context.Joinlists.ToListAsync();
        }

        public async Task<IActionResult> OnPostAsync(Joinlist newJoinlist)
        {
            if (!ModelState.IsValid)
            {
                Joinlists = await _context.Joinlists.ToListAsync();
                return Page();
            }

            _context.Joinlists.Add(newJoinlist);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Joinlist2");
        }
    }
}
