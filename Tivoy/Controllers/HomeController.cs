using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Tivoy.Models;

namespace Tivoy.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(UserManager<User> userManager,
                               SignInManager<User> signInManager
                             ) : base(userManager, signInManager)
        {

        }
        public IActionResult Index()
        {
            var user = new User { UserName = "test@mail.ru", Email = "test@mail.ru",FirstName = "a", LastName = "b" };
            UserManager.CreateAsync(user);
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
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
