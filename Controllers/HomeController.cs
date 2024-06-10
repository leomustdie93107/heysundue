using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Heysundue.Models;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace Heysundue.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ArticleContext _context;

        public HomeController(ILogger<HomeController> logger, ArticleContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SetDate()
        {
            return View();
        }
        public IActionResult SetDate2()
        {
            return View(new Article());
        }

        public IActionResult SetDate3()
        {
            return View(new Person());
        }

        [HttpPost]
        public async Task<IActionResult> SetDate2([Bind("ID,Number,Title,Link,ReleaseDate,Gender,Count,Date,Time,Location")] Article article)
        {
            if (ModelState.IsValid)
            {
                _context.Add(article);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(article);
        }

                [HttpPost]
        public async Task<IActionResult> SetDate3([Bind("ID,Number,Title,Link,ReleaseDate,Gender,Count,Date,Time,Location")] Person persons)
        {
            if (ModelState.IsValid)
            {
                _context.Persons.Add(persons);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(persons);
        }

         public async Task<IActionResult> Registration2([Bind("ID,Number,Title,Link,ReleaseDate,Gender,Count,Date,Time,Location")] Registration Registration)
        {
            if (ModelState.IsValid)
            {
                _context.Registration.Add(Registration);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(Registration);
        }

        public async Task<IActionResult> Login2([Bind("ID,Number,Title,Link,ReleaseDate,Gender,Count,Date,Time,Location")] Login Login)
        {
            if (ModelState.IsValid)
            {
                _context.Login.Add(Login);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(Login);
        }

        public async Task<IActionResult> Joinlist2([Bind("ID,Number,Title,Link,ReleaseDate,Gender,Count,Date,Time,Location")] Joinlist Joinlist)
        {
            if (ModelState.IsValid)
            {
                _context.Joinlist.Add(Joinlist);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(Joinlist);
        }

        public async Task<IActionResult> Doorsystem2([Bind("ID,Number,Title,Link,ReleaseDate,Gender,Count,Date,Time,Location")] Doorsystem Doorsystem)
        {
            if (ModelState.IsValid)
            {
                _context.Doorsystem.Add(Doorsystem);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(Doorsystem);
        }

        public async Task<IActionResult> Accessdoor2([Bind("ID,Number,Title,Link,ReleaseDate,Gender,Count,Date,Time,Location")] Accessdoor Accessdoor)
        {
            if (ModelState.IsValid)
            {
                _context.Accessdoor.Add(Accessdoor);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(Accessdoor);
        }

        public IActionResult Banner()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Registration()
        {
            return View();
        }

        public IActionResult Joinlist()
        {
            return View();
        }

        public IActionResult Accessdoor()
        {
            return View();
        }

        public IActionResult Doorsystem()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
