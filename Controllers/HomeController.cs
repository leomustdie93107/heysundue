using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Heysundue.Models;
using Heysundue.Views.Home;


using Microsoft.EntityFrameworkCore;


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
                var persons = _context.Persons.ToList();
                var model = new SetDate3ViewModel
                {
                    Persons = persons,
                    Person = new Person()
                };
                return View(model);
        }



        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Login2()
        {
            return View();
        }

        public IActionResult Registration()
        {
            return View();
        }

        public IActionResult Registration2()
        {
            return View(new Registration());
        }

        public IActionResult Joinlist()
        {
            return View();
        }

        public IActionResult Joinlist2()
        {
                var model = new Joinlist
    {
        AllJoinlist = new List<Joinlist>
        {
            // 初始化一些数据，作为示例
            new Joinlist { ID = 1, RegNo = "001", FirstName = "John", LastName = "Doe", ChineseName = "约翰", Country = "USA", RegistrationStatus = "Registered" },
            new Joinlist { ID = 2, RegNo = "002", FirstName = "Jane", LastName = "Smith", ChineseName = "简", Country = "Canada", RegistrationStatus = "Pending" }
        }
    };

    return View(model);
        }


        public IActionResult Accessdoor()
        {
            return View();
        }

        public IActionResult Accessdoor2()
        {
            return View(new Accessdoor());
        }

        public IActionResult Doorsystem()
        {
            return View();
        }

        public IActionResult Doorsystem2()
        {
            return View(new Doorsystem());
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
        public async Task<IActionResult> SetDate3(SetDate3ViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Persons.Add(model.Person);  // 添加断点，检查 model.Person 的值是否正确
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }

                // 如果 ModelState 验证失败，重新显示视图以显示验证错误信息
                model.Persons = _context.Persons.ToList();
                return View(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error saving person information.");
                throw; // 抛出异常以便于调试，可以选择捕获异常并返回视图
            }
        }

        [HttpPost]
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

        [HttpPost]
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

        [HttpPost]
        public async Task<IActionResult> Joinlist2([Bind("RegistrationStatus,Country,RegNo,FirstName,LastName,ChineseName,ID,Number,Title,Link,ReleaseDate,Gender,Count,Date,Time,Location")] Joinlist Joinlist)
        {
            if (ModelState.IsValid)
            {
                _context.Joinlists.Add(Joinlist);
                await _context.SaveChangesAsync();
                return RedirectToAction("Joinlist2");
            }

            return View(Joinlist);
        }

        [HttpPost]
        public async Task<IActionResult> Doorsystem2([Bind("ID,Number,Session,SessionName,Room,TimeRange")] Doorsystem Doorsystem)
        {
            if (ModelState.IsValid)
            {
                _context.Doorsystem.Add(Doorsystem);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(Doorsystem);
        }

        [HttpPost]
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



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
