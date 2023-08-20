using System.Diagnostics;
using MBlogCore.Persistance.Context;
using Microsoft.AspNetCore.Mvc;
namespace MBlogCore.Web.Controllers
{
	public class BlogController:Controller
	{
		private readonly MBlogContext c;
		public BlogController(MBlogContext context)
		{
			this.c = context;
		}
        [HttpGet] 
        public IActionResult Detail(int Id)
        {
			Debug.WriteLine(Id);
            return View("Detail");
        }

        [HttpGet]
		[ActionName("Index")]
		public IActionResult List()
		{
			return View();
		}
		
	}
}

