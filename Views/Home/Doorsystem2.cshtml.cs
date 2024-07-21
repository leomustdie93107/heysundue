using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Heysundue.Models;
using Heysundue.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Heysundue.Views.Home;

namespace Heysundue.Pages
{
    public class Doorsystem2Model : PageModel
    {
        private readonly ArticleContext _context;

        public Doorsystem2Model(ArticleContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Doorsystem Doorsystem { get; set; }

        [BindProperty]
        public string? SearchColumn { get; set; }

        [BindProperty]
        public string? SearchKeyword { get; set; }

        public Doorsystem2ViewModel ViewModel { get; set; } = new Doorsystem2ViewModel();

        public async Task<IActionResult> OnGetAsync()
        {
            ViewModel.Doorsystems = await _context.Doorsystems.ToListAsync();
            ViewData["Title"] = "門禁系統管理";
            ViewData["ViewModel"] = ViewModel;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                ViewModel.Doorsystems = await _context.Doorsystems.ToListAsync();
                ViewData["ViewModel"] = ViewModel;
                return Page();
            }

            _context.Doorsystems.Add(Doorsystem);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Doorsystem2");
        }

        public async Task<IActionResult> OnPostSearchAsync()
        {
            var query = _context.Doorsystems.AsQueryable();

            if (!string.IsNullOrEmpty(SearchColumn) && !string.IsNullOrEmpty(SearchKeyword))
            {
                switch (SearchColumn.ToLower())
                {
                    case "date":
                        if (DateTime.TryParse(SearchKeyword, out DateTime searchDate))
                        {
                            query = query.Where(d => d.Date.Date == searchDate.Date);
                        }
                        break;
                    case "session":
                        query = query.Where(d => d.Session.Contains(SearchKeyword));
                        break;
                    case "sessionname":
                        query = query.Where(d => d.SessionName.Contains(SearchKeyword));
                        break;
                    case "room":
                        query = query.Where(d => d.Room.Contains(SearchKeyword));
                        break;
                    case "timerange":
                        query = query.Where(d => d.TimeRange.Contains(SearchKeyword));
                        break;
                }
            }

            ViewModel.Doorsystems = await query.ToListAsync();
            ViewData["ViewModel"] = ViewModel;
            return Page();
        }
    }
}
