using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Models;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using DataModels;

namespace Tivoy.Controllers
{
    public class TourController : BaseController
    {
        public TourController(UserManager<User> userManager,
                             SignInManager<User> signInManager,
                             IUnitOfWork unitOfWork
                           ) : base(userManager, signInManager, unitOfWork)
        {

        }

        public async Task<IActionResult> Index()
        {
            var tours = await UnitOfWork.TourRepository.GetAll();
            return View(tours);
        }

        [HttpGet]
        public async Task<IActionResult> Add(int? id)
        {
            var model = id.HasValue ? await UnitOfWork.TourRepository.GetById(id.Value) : new TourViewModel();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(TourViewModel model)
        {


            try
            {
                if (ModelState.IsValid)
                {
                    await UnitOfWork.TourRepository.Add(model);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);

            }
            return View("Add", model);

        }
    }
}