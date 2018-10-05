using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Tivoy.Models;

namespace Tivoy.Controllers
{
    public class BaseController : Controller
    {
        protected readonly UserManager<User> UserManager;
        protected readonly SignInManager<User> SignInManager;
        public BaseController(UserManager<User> userManager,
           SignInManager<User> signInManager
     )
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }
    }
}