﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Models;
using DataAccess.Repositories;
using DataModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

            var orders = await UnitOfWork.OrderRepository.GetAllPagedList(page.Value, pSize, searchString);
            return Request.IsAjaxRequest()
               ? (ActionResult)PartialView("_List", orders)
               : View(orders);
        }
        [HttpGet]
        public async Task<IActionResult> Create(int? Id,int? tourId)
        {
            var users = await UnitOfWork.CustomerRepository.GetAll();
            if(Id.HasValue)
            {
               
                ViewBag.isOneUser = true;
            }
            ViewBag.Customers = new SelectList(users, "Id", "FullName",Id);

            var tours = await UnitOfWork.TourRepository.GetAll();
            ViewBag.Tours = new SelectList(tours, "Id", "Name",tourId);

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(OrderViewModel model)
        {
            await UnitOfWork.OrderRepository.Add(model);
            return RedirectToAction("Index");
        }
    }
}