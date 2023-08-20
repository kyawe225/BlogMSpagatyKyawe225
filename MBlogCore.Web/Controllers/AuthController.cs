using System.Security.Claims;
using MBlogCore.Persistance.Context;
using MBlogCore.Persistance.Tables;
using MBlogCore.Web.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace MBlogCore.Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly MBlogContext context;

        public AuthController(MBlogContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View("Login");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View("Register");
        }

        [HttpPost]
        [ActionName("Login")]
        public IActionResult LoginAction(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                User? user = context.users.Where(p => p.Email.Equals(model.Email)).FirstOrDefault();
                if (user != null)
                {
                    bool password = user.Password.Equals(model.Password);
                    if (password)
                    {
                        IEnumerable<Claim> claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.Name,user.Name),
                            new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
                            new Claim(ClaimTypes.Role,"Admin Or User")
                        };
                        ClaimsIdentity identity = new ClaimsIdentity(claims);
                        ClaimsPrincipal principal = new ClaimsPrincipal(identity);
                        this.HttpContext.SignInAsync(principal);
                        TempData["ErrorMessage"] = "Login Successfully";
                        return RedirectToAction("Index", "Home");
                    }
                }
            }
            TempData["ErrorMessage"] = "Fail to Login";
            IEnumerable<ModelErrorMessage> messages = ModelState.Keys.Where(p => ModelState[p]?.Errors.Count > 0).Select(p => new ModelErrorMessage
            {
                fieldName = p,
                errorMessage = ModelState[p]?.Errors[0]?.ErrorMessage
            }).ToList();
            TempData["FieldErrors"] = messages;
            return View("Login", model);
        }

        [HttpPost]
        [ActionName("Register")]
        public IActionResult RegisterAction(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.Password.Equals(model.ConfirmPassword))
                {
                    User user = new User()
                    {
                        Name = model.Name,
                        Email = model.Email,
                        Password = model.Password,
                        DOB = model.DateOfBirth.ToUniversalTime()
                    };
                    context.users.Add(user);
                    context.SaveChanges();
                    TempData["SuccessMessage"] = "Successfully Register";
                    return RedirectToAction("Index", "Home");
                }
            }
            TempData["ErrorMessage"] = "Fail to Register";
            IEnumerable<ModelErrorMessage> messages = ModelState.Keys.Where(p => ModelState[p]?.Errors.Count > 0).Select(p => new ModelErrorMessage
            {
                fieldName = p,
                errorMessage = ModelState[p]?.Errors[0]?.ErrorMessage
            }).ToList();
            TempData["FieldErrors"] = messages;
            return View("Register", model);
        }

        [HttpPost]
        [ActionName("Logout")]
        [Authorize]
        public IActionResult LogoutAction()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}

