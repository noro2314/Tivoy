using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Models;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

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
        public async Task<IActionResult> Index(string searchString, string currentFilter, int? page, int? pageSize)
        {
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }
            ViewBag.CurrentFilter = searchString;
            int pSize = pageSize ?? 10;
            ViewBag.PageSize = pSize;

            if (searchString != null)
            {
                searchString = searchString.Trim();
            }

            page = page ?? 1;

            var orders = await UnitOfWork.OrderRepository.GetAllPagedList(page.Value,pSize,searchString);
            return Request.IsAjaxRequest()
               ? (ActionResult)PartialView("_List", orders)
               : View(orders);
        }
    }
}