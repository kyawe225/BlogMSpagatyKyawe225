using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace MBlogCore.Web.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class BlogController:Controller
	{
		public IActionResult Index()
		{
			return View("Index");
		}
	}
}

