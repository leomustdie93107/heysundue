using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Heysundue.Data;
using Heysundue.Models;

public class InputUser2Model : PageModel
{
    private readonly ArticleContext _context;

    public InputUser2Model(ArticleContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Member Member { get; set; }

    public List<Member> Members { get; set; }

    public IActionResult OnGet()
    {
        Members = _context.Members.ToList();

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            Members = _context.Members.ToList(); // 如果 ModelState 驗證失敗，重新獲取 Persons 數據
            return Page();
        }

        _context.Members.Add(Member);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
