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
    public class OrderController : BaseController
    {
        public OrderController(UserManager<User> userManager,
                              SignInManager<User> signInManager,
                              IUnitOfWork unitOfWork
                            ) : base(userManager, signInManager, unitOfWork)
        {

        }
        public async Task<IActionResult> Index()
        {
            var orders = await UnitOfWork.OrderRepository.GetAll();
            return View(orders);
        }


    }
}