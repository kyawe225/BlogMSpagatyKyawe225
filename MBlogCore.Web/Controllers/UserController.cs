
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;

namespace MBlogCore.Web.Controllers
{
	public class UserController:Controller
	{
		public UserController()
		{
		}
		public IActionResult Profile()
		{
			HttpContext.User.Identity.;
			return null;
		}
		public IActionResult ProfileEdit()
		{
			return null;
		}
		public IActionResult SavedBlogs()
		{
			return null;
		}
	}
}

