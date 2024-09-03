using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Heysundue.Models;
using Heysundue.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Heysundue.Pages
{
    public class Userlist2Model : PageModel
    {
        private readonly ArticleContext _context;

        public Userlist2Model(ArticleContext context)
        {
            _context = context;
        }

        public IList<Member> Members { get; set; } = new List<Member>();

        [BindProperty]
        public string? SearchColumn { get; set; }

        [BindProperty]
        public string? SearchKeyword { get; set; }

        [BindProperty]
        public List<SelectListItem> LevelOptions { get; set; }

        public async Task OnGetAsync()
        {
            Members = await _context.Members.ToListAsync();
            ViewData["Title"] = "用戶管理系統";

            // 初始化 LevelOptions
            LevelOptions = new List<SelectListItem>
            {
                new SelectListItem { Value = "Root", Text = "Root" },
                new SelectListItem { Value = "Admin", Text = "Admin" },
                new SelectListItem { Value = "Member", Text = "Member" }
            };
        }


        public async Task<IActionResult> OnPostSearchAsync()
        {
            var query = _context.Members.AsQueryable();

            if (!string.IsNullOrEmpty(SearchColumn) && !string.IsNullOrEmpty(SearchKeyword))
            {
                switch (SearchColumn.ToLower())
                {
                    case "username":
                        query = query.Where(m => m.UserName.Contains(SearchKeyword));
                        break;
                    case "phone":
                        query = query.Where(m => m.Phone.ToString().Contains(SearchKeyword));
                        break;
                    case "email":
                        query = query.Where(m => m.Email.Contains(SearchKeyword));
                        break;
                    case "level":
                        query = query.Where(m => m.Level.Contains(SearchKeyword));
                        break;
                }
            }

            Members = await query.ToListAsync();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int memberId, string userName, string userPassword, int phone, string email, string level)
        {
            var member = await _context.Members.FindAsync(memberId);
            if (member == null)
            {
                return NotFound();
            }

            // 更新資料
            member.UserName = userName;
            member.UserPassword = userPassword;
            member.Phone = phone;
            member.Email = email;
            member.Level = level;

            await _context.SaveChangesAsync();

            return RedirectToPage();
        }
    }
}
