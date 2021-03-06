﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DataModels;
using Microsoft.AspNetCore.Identity;
using DataAccess.Models;
using DataAccess.Repositories;

namespace Tivoy.Controllers
{
    public class CustomerController : BaseController
    {
        public CustomerController(UserManager<User> userManager,
                               SignInManager<User> signInManager,
                               IUnitOfWork unitOfWork
                             ) : base(userManager, signInManager, unitOfWork)
        {

        }
        public async Task<IActionResult> Index()
        {
            var model = await UnitOfWork.CustomerRepository.GetAll();
            return View(model);
        }
        [HttpGet]
        public  async Task<IActionResult> Add(int?id)
        {
            var model = id.HasValue ? await UnitOfWork.CustomerRepository.GetById(id.Value) : new CustomerViewModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CustomerViewModel model)
        {
            if(model.Id==0)
            {
 var user = new User
            { UserName = model.Email,
              Email = model.Email,

                };
           var result=await UserManager.CreateAsync(user,"Aa.1234566");
            if(result.Succeeded)
            {
                model.UserId = user.Id;
                int newCustomerId= await UnitOfWork.CustomerRepository.Add(model);
                return RedirectToAction("Profile", new { Id =newCustomerId});
            }
            }
            else
            {
                await UnitOfWork.CustomerRepository.Update(model);
                return RedirectToAction("Profile", new { model.Id });
            }
            return View();
        }

        public async Task<IActionResult> Profile(int Id)
        {
            var model = await UnitOfWork.CustomerRepository.GetById(Id);
            return View(model);
        }

        
        public async Task<JsonResult> AddNote(NoteViewModel model)
        {
            await UnitOfWork.CustomerRepository.AddNote(model.Text, model.UserId);
            return Json(new {success=true });
        }
    }
}