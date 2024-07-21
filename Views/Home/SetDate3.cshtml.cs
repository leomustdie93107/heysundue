using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Heysundue.Data;
using Heysundue.Models;

public class SetDate3Model : PageModel
{
    private readonly ArticleContext _context;

    public SetDate3Model(ArticleContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Person Person { get; set; }

    public List<Person> Persons { get; set; }

    public IActionResult OnGet()
    {
        Persons = _context.Persons.ToList();
        ViewData["Title"] = "研討會日期設定";
        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid)
        {
            Persons = _context.Persons.ToList(); // 如果 ModelState 驗證失敗，重新獲取 Persons 數據
            return Page();
        }

        _context.Persons.Add(Person);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
}
