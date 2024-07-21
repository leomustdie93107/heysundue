using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Heysundue.Models;
using Heysundue.Views.Home;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Heysundue.Controllers
{
    public class HomeController : Controller
    {
        private readonly ArticleContext _context;

        public HomeController(ArticleContext context)
        {
            _context = context;
        }


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



        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult Login2()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login2(Login login)
        {
            Console.WriteLine("OnPost 方法被调用");

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "模型验证失败");
                Console.WriteLine("模型验证失败");
                return View(login);
            }

            Console.WriteLine("模型验证成功");

            if (_credentials.ContainsKey(login.Username) && _credentials[login.Username] == login.Password)
            {
                HttpContext.Session.SetString("UserRole", _roles[login.Username]);
                Console.WriteLine("登录成功，用户角色：" + _roles[login.Username]);
                return RedirectToAction("Index");
            }

            ModelState.AddModelError(string.Empty, "无效的登录尝试");
            Console.WriteLine("登录失败，用户名或密码错误。");
            return View(login);
        }


        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public IActionResult SetDate()
        {
            return View();
        }

        public IActionResult SetDate2()
        {
            return View(new Article());
        }

        [HttpGet]
        public IActionResult SetDate3()
        {
            var model = new SetDate3ViewModel
            {
                Persons = _context.Persons.ToList()
            };
            return View(model);
        }

        public IActionResult Login()
        {
            return View();
        }


        public IActionResult Registration()
        {
            return View();
        }

        public IActionResult Registration2()
        {
            var model = new Registration2ViewModel
            {
                Registrations = _context.Registrations.ToList()
            };
            return View(model);
        }


        public IActionResult Joinlist()
        {
            return View();
        }

        public IActionResult Joinlist2(string searchColumn, string searchKeyword)
        {
            var model = new Joinlist2ViewModel
            {
                Joinlists = _context.Joinlists.ToList()
            };
            return View(model);
        }

        public IActionResult Doorsystem2(string searchColumn, string searchKeyword)
        {
            var model = new Doorsystem2ViewModel
            {
                Doorsystems = _context.Doorsystems.ToList()
            };
            return View(model);
        }

        public IActionResult Accessdoor()
        {
            return View();
        }

        public IActionResult Accessdoor2()
        {
            var model = new Accessdoor2ViewModel
            {
                Accessdoors = _context.Accessdoors.ToList(),
                UniqueDates = _context.Accessdoors.Select(a => a.StartDate).Distinct().ToList(),
                UniqueRooms = _context.Accessdoors.Select(a => a.Room).Distinct().ToList(),
                UniqueSessions = _context.Accessdoors.Select(a => a.Session).Distinct().ToList()
            };
            return View(model);
        }

                [HttpPost]
        public async Task<IActionResult> SearchAccessdoor(string searchColumn, string searchKeyword)
        {
            var query = _context.Accessdoors.AsQueryable();

            if (!string.IsNullOrEmpty(searchColumn) && !string.IsNullOrEmpty(searchKeyword))
            {
                switch (searchColumn.ToLower())
                {
                    case "startdate":
                        if (DateTime.TryParse(searchKeyword, out DateTime date))
                        {
                            query = query.Where(j => j.StartDate == date);
                        }
                        break;
                    case "room":
                        query = query.Where(j => j.Room.Contains(searchKeyword));
                        break;
                    case "session":
                        query = query.Where(j => j.Session.Contains(searchKeyword));
                        break;
                }
            }

        var result = await query.ToListAsync();
            return PartialView("_AccessdoorTablePartial", result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAccessdoors()
        {
            var result = await _context.Accessdoors.ToListAsync();
            return PartialView("_AccessdoorTablePartial", result);
        }

        public IActionResult Doorsystem()
        {
            return View();
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
        public async Task<IActionResult> SearchJoinlist(string searchColumn, string searchKeyword)
        {
            var query = _context.Joinlists.AsQueryable();

            if (!string.IsNullOrEmpty(searchColumn) && !string.IsNullOrEmpty(searchKeyword))
            {
                switch (searchColumn.ToLower())
                {
                    case "regno":
                        query = query.Where(j => j.RegNo.Contains(searchKeyword));
                        break;
                    case "firstname":
                        query = query.Where(j => j.FirstName.Contains(searchKeyword));
                        break;
                    case "lastname":
                        query = query.Where(j => j.LastName.Contains(searchKeyword));
                        break;
                    case "chinesename":
                        query = query.Where(j => j.ChineseName.Contains(searchKeyword));
                        break;
                    case "country":
                        query = query.Where(j => j.Country.Contains(searchKeyword));
                        break;
                    case "registrationstatus":
                        query = query.Where(j => j.RegistrationStatus.Contains(searchKeyword));
                        break;
                }
            }

            var joinlists = await query.ToListAsync();
            return PartialView("_JoinlistTable", joinlists);
        }
        [HttpPost]
        public async Task<IActionResult> Joinlist2(Joinlist2ViewModel model)
        {
            if (ModelState.IsValid)
            {
                _context.Joinlists.Add(model.Joinlist);
                await _context.SaveChangesAsync();
                return RedirectToAction("Joinlist2");
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Doorsystem2(Doorsystem2ViewModel model)
        {
            if (ModelState.IsValid)
            {
                _context.Doorsystems.Add(model.Doorsystem);
                await _context.SaveChangesAsync();
                return RedirectToAction("Doorsystem2");
            }
            return View(model);
        }

        
        [HttpPost]
        public async Task<IActionResult> Registration2(Registration2ViewModel model)
        {
            if (ModelState.IsValid)
            {
                _context.Registrations.Add(model.Registration);
                await _context.SaveChangesAsync();
                return RedirectToAction("Registration2");
            }
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> SetDate3(SetDate3ViewModel model)
        {
            if (ModelState.IsValid)
            {
                _context.Persons.Add(model.Person);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            model.Persons = _context.Persons.ToList();
            return View(model);
        }






        [HttpPost]
        public async Task<IActionResult> Accessdoor2(Accessdoor2ViewModel model)
        {
            if (ModelState.IsValid)
            {
                _context.Accessdoors.Add(model.Accessdoor);
                await _context.SaveChangesAsync();
                return RedirectToAction("Accessdoor2");
            }

            return View(model);
        }

  

    }
}
