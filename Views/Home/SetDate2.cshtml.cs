using Heysundue.Models;
using Heysundue.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;

namespace Heysundue.Pages
{
    public class SetDate2Model : PageModel
    {
        private readonly ArticleContext _context;

        public SetDate2Model(ArticleContext context)
        {
            _context = context;
            Article = new Article();
        }

        [BindProperty]
        public Article Article { get; set; }

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

            _context.Article.Add(Article);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
