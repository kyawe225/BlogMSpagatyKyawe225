using MBlogCore.Persistance.Context;
using MBlogCore.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
		[ActionName("Detail")]
        public IActionResult Detail(string Id)
        {
            BlogListViewModel? blog = c.blogs.AsNoTracking().Where(p=> p.Id==Guid.Parse(Id)).Select(p => new BlogListViewModel
            {
				Id=p.Id.ToString(),
                Title = p.Title
            }).FirstOrDefault();
			if (blog == null)
			{
				return NotFound();
			}
            return View("Detail",blog);
        }

        [HttpGet]
		[ActionName("Index")]
		public IActionResult List()
		{
			IEnumerable<BlogListViewModel> blogs=c.blogs.AsNoTracking().Select(p=> new BlogListViewModel
			{
				Id=p.Id.ToString(),
				Title=p.Title
			}).ToList();
			return View(blogs);
		}
		
	}
}

