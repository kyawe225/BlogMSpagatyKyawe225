
using MBlogCore.Persistance.Context;
using MBlogCore.Persistance.Tables;
using MBlogCore.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace MBlogCore.Web.Controllers
{
    public class UserController : Controller
    {
        private readonly MBlogContext context;
        public UserController(MBlogContext context)
        {
            this.context = context;
        }
        [HttpGet]
        [Authorize]
        public IActionResult Profile()
        {
            Claim? s = User.FindFirst(ClaimTypes.NameIdentifier);
            Guid userId = Guid.Parse(s.Value);
            UserDetailViewModel user = context.users.Where(p => p.Id == userId).Select(p => new UserDetailViewModel
            {
                Name = p.Name,
                Address = p.Address,
                PhoneNumber = p.PhoneNumber,
                DOB = p.DOB == null ? null : p.DOB,
                Email = p.Email,
                IsActive = p.IsActive,
                IsFullyActivated = p.IsFullyActivated
            }).First();
            return View("Profile", user);
        }
        [HttpGet]
        [Authorize]
        public IActionResult ProfileEdit()
        {
            Claim? s = User.FindFirst(ClaimTypes.NameIdentifier);
            Guid userId = Guid.Parse(s.Value);
            UserUpdateViewModel user = context.users.AsNoTracking().Where(p => p.Id == userId).Select(p => new UserUpdateViewModel
            {
                Name = p.Name,
                Address = p.Address,
                PhoneNumber = p.PhoneNumber == null ? "" : p.PhoneNumber,
                Email = p.Email,
            }).First();
            return View("Edit", user);
        }
        [HttpPost]
        [Authorize]
        [ActionName("ProfileEdit")]
        public IActionResult ProfileEditAction(UserUpdateViewModel model)
        {
            if (ModelState.IsValid)
            {
                Claim? s = User.FindFirst(ClaimTypes.NameIdentifier);
                Guid userId = Guid.Parse(s.Value);
                User user = context.users.Where(p => p.Id == userId).First();
                user.Name = model.Name;
                user.Email = model.Email;
                user.Address = model.Address;
                user.DOB = model.DOB;
                user.PhoneNumber = model.PhoneNumber;
                user.IsFullyActivated = true;
                context.users.Update(user);
                context.SaveChanges();
                TempData["SuccessMessage"] = "Successfully updated";
                return RedirectToAction("Profile", "User");
            }
            TempData["ErrorMessage"] = "Not Successfully";
            return View("Edit", model);
        }
    }
}

