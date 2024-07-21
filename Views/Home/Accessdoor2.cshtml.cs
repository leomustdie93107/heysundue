using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Heysundue.Models;
using Heysundue.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Heysundue.Pages
{
    public class Accessdoors2Model : PageModel
    {
        private readonly ArticleContext _context;

        public Accessdoors2Model(ArticleContext context)
        {
            _context = context;
        }

        public IList<Accessdoor> Accessdoors { get; set; } = new List<Accessdoor>();

        [BindProperty]
        public string? SearchColumn { get; set; }

        [BindProperty]
        public string? SearchKeyword { get; set; }

        public async Task OnGetAsync()
        {
            Accessdoors = await _context.Accessdoors.ToListAsync();
            ViewData["Title"] = "會議管理系統";
        }

        public async Task<IActionResult> OnPostAsync(Accessdoor newAccessdoors)
        {
            if (!ModelState.IsValid)
            {
                Accessdoors = await _context.Accessdoors.ToListAsync();
                return Page();
            }

            _context.Accessdoors.Add(newAccessdoors);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Accessdoors2");
        }

        public async Task<IActionResult> OnPostSearchAsync()
        {
            var query = _context.Accessdoors.AsQueryable();

            if (!string.IsNullOrEmpty(SearchColumn) && !string.IsNullOrEmpty(SearchKeyword))
            {
                switch (SearchColumn.ToLower())
                {
                    case "startdate":
                        if (DateTime.TryParse(SearchKeyword, out DateTime searchDate))
                        {
                            query = query.Where(j => j.StartDate.HasValue && j.StartDate.Value.Date == searchDate.Date);
                        }
                        break;
                    case "room":
                        query = query.Where(j => j.Room.Contains(SearchKeyword));
                        break;
                    case "session":
                        query = query.Where(j => j.Session.Contains(SearchKeyword));
                        break;
                    default:
                        return Page(); // 如果搜索欄位無效，返回當前頁面
                }
            }

            Accessdoors = await query.ToListAsync();
            return Page();
        }
    }
}
