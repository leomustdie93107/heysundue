using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Heysundue.Models;
using Heysundue.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Heysundue.Pages
{
    public class Joinlist2Model : PageModel
    {
        private readonly ArticleContext _context;

        public Joinlist2Model(ArticleContext context)
        {
            _context = context;
        }

        public IList<Joinlist> Joinlists { get; set; } = new List<Joinlist>();

        [BindProperty]
        public string? SearchColumn { get; set; }

        [BindProperty]
        public string? SearchKeyword { get; set; }

        public async Task OnGetAsync()
        {
            Joinlists = await _context.Joinlists.ToListAsync();
            ViewData["Title"] = "報名人員管理系統";
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

        public async Task<IActionResult> OnPostSearchAsync()
        {
            var query = _context.Joinlists.AsQueryable();

            if (!string.IsNullOrEmpty(SearchColumn) && !string.IsNullOrEmpty(SearchKeyword))
            {
                switch (SearchColumn.ToLower())
                {
                    case "regno":
                        query = query.Where(j => j.RegNo.Contains(SearchKeyword));
                        break;
                    case "firstname":
                        query = query.Where(j => j.FirstName.Contains(SearchKeyword));
                        break;
                    case "lastname":
                        query = query.Where(j => j.LastName.Contains(SearchKeyword));
                        break;
                    case "chinesename":
                        query = query.Where(j => j.ChineseName.Contains(SearchKeyword));
                        break;
                    case "country":
                        query = query.Where(j => j.Country.Contains(SearchKeyword));
                        break;
                    case "registrationstatus":
                        query = query.Where(j => j.RegistrationStatus.Contains(SearchKeyword));
                        break;
                }
            }

            Joinlists = await query.ToListAsync();
            return Page();
        }
    }
}
