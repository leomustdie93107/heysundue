using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Heysundue.Models;
using System.Linq;

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

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "模型验证失败");
                return Page();
            }

            // 查詢資料庫中的 Member 表，檢查是否有匹配的用戶名和密碼
            var member = _context.Members
                .FirstOrDefault(m => m.UserName == Login.Username && m.UserPassword == Login.Password);

            if (member != null)
            {
                // 如果找到匹配的用戶，將 Level 存入 Session
                HttpContext.Session.SetString("UserRole", member.Level);
                return RedirectToPage("./Index");
            }

            ModelState.AddModelError(string.Empty, "无效的登录尝试");
            return Page();
        }
    }
}
