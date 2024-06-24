using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Heysundue.Data;
using Heysundue.Models;
using Microsoft.Extensions.Logging;

public class SetDate3Model : PageModel
{
    private readonly ArticleContext _context;

    private readonly ILogger<SetDate3Model> _logger;
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
            Persons = _context.Persons.ToList(); // 如果 ModelState 验证失败，重新获取 Persons 数据
            return Page();
        }

    try
    {
        _context.Persons.Add(Person);
        await _context.SaveChangesAsync();

        return RedirectToPage("./Index");
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, "Error saving person information.");
        throw; // 抛出异常以便于调试，可以选择捕获异常并返回视图
    }
    }
}