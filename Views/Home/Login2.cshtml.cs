using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using Heysundue.Models;
using System;

namespace Heysundue.Pages
{
    public class Login2Model : PageModel
    {
        private readonly Dictionary<string, string> _credentials = new Dictionary<string, string>
        {
            { "root", "rootpassword" },
            { "admin", "adminpassword" },
            { "guest", "guestpassword" }
        };

        private readonly Dictionary<string, string> _roles = new Dictionary<string, string>
        {
            { "root", "Root" },
            { "admin", "Admin" },
            { "guest", "Guest" }
        };

        public Login2Model()
        {
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
            Console.WriteLine("OnPost 方法被调用");

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "模型验证失败");
                Console.WriteLine("模型验证失败");
                foreach (var error in ModelState)
                {
                    Console.WriteLine($"错误键: {error.Key}, 错误信息: {string.Join(", ", error.Value.Errors.Select(e => e.ErrorMessage))}");
                }
                return Page();
            }

            Console.WriteLine("模型验证成功");

            if (_credentials.ContainsKey(Login.Username) && _credentials[Login.Username] == Login.Password)
            {
                HttpContext.Session.SetString("UserRole", _roles[Login.Username]);
                Console.WriteLine("登录成功，用户角色：" + _roles[Login.Username]);
                return RedirectToPage("./Index");
            }

            ModelState.AddModelError(string.Empty, "无效的登录尝试");
            Console.WriteLine("登录失败，用户名或密码错误。");
            return Page();
        }
    }
}
