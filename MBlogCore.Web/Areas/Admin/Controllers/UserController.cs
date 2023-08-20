using System;
using MBlogCore.Persistance.Context;
using MBlogCore.Persistance.Tables;
using MBlogCore.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MBlogCore.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class UserController : Controller
    {
        private MBlogContext context;
        public UserController(MBlogContext context)
        {
            this.context = context;
        }
        /// <summary>
        /// This is the list page of user
        /// </summary>
        /// <returns>View</returns>
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ActionName("Create")]
        public IActionResult CreateAction(UserCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new User
                {
                    Name = model.Name,
                    Email = model.Email,
                    Password = model.Password,
                    DOB = model.DOB.ToUniversalTime(),
                    Address = model.Address,
                    PhoneNumber = model.PhoneNumber
                };
                this.context.users.Add(user);
                this.context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("Create", model);
        }
        [HttpGet]
        public IActionResult Update(string Id)
        {
            try
            {
                UserUpdateViewModel? user = context.users.AsNoTracking().Where(p => p.Id.Equals(Guid.Parse(Id))).Select(p => new UserUpdateViewModel
                {
                    Address = p.Address,
                    Name = p.Name,
                    DOB = p.DOB,
                    Email = p.Email,
                    IsActive = p.IsActive,
                    PhoneNumber = p.PhoneNumber,
                    Password = "****************"
                }).FirstOrDefault();
                if (user == null)
                {
                    throw new Exception();
                }
                return View("Update", user);
            }
            catch (Exception e)
            {
                return RedirectToAction("Index");
            }
        }
        [HttpPost]
        [ActionName("Update")]
        public IActionResult UpdateAction(string Id, UserUpdateViewModel model)
        {
            if (ModelState.IsValid)
            {
                User? user = context.users.Where(p => p.Id == Guid.Parse(Id)).FirstOrDefault();
                if (user != null)
                {
                    user.Name = model.Name;
                    user.Email = model.Email;
                    user.Password = model.Password;
                    user.DOB = model.DOB?.ToUniversalTime();
                    user.Address = model.Address;
                    user.PhoneNumber = model.PhoneNumber;
                    this.context.users.Add(user);
                    this.context.SaveChanges();
                    TempData["SuccessMessage"] = "Update User Successfully";
                    return RedirectToAction("Index");
                }
            }
            TempData["SuccessMessage"] = "Update User Failed";
            return View("Create", model);
        }
        [HttpPost]
        [ActionName("Delete")]
        public IActionResult Deleteaction(string Id)
        {
            if (ModelState.IsValid)
            {
                User? user = context.users.Where(p => p.Id == Guid.Parse(Id)).FirstOrDefault();
                if (user != null)
                {
                    this.context.users.Remove(user);
                    this.context.SaveChanges();
                    TempData["SuccessMessage"] = "DELETE User Successfully";
                    return RedirectToAction("Index");
                }
            }
            TempData["SuccessMessage"] = "DELETE User Failed";
            return RedirectToAction("Index");
        }
    }
}

