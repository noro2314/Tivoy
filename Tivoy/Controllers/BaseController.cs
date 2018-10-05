using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Models;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Tivoy.Controllers
{
    public class BaseController : Controller
    {
        protected readonly UserManager<User> UserManager;
        protected readonly SignInManager<User> SignInManager;
        protected readonly IUnitOfWork UnitOfWork;

        public BaseController(UserManager<User> userManager,
           SignInManager<User> signInManager,
           IUnitOfWork unitOfWork)
        {

            UserManager = userManager;
            SignInManager = signInManager;
            UnitOfWork = unitOfWork;
        }
    }
}