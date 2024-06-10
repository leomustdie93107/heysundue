using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using Heysundue.Models;
using Heysundue.Data;
using System.Threading.Tasks;

namespace Heysundue.Pages
{
    public class Login2Model : PageModel
    {
        private readonly ArticleContext _context;

        public Login2Model(ArticleContext context)
        {
            _context = context;
            Login = new Login();
        }

        [BindProperty]
        public Login Login { get; set; }

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

            _context.Login.Add(Login);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
