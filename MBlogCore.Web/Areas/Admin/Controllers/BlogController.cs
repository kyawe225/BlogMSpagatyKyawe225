using MBlogCore.Persistance.Context;
using MBlogCore.Persistance.Tables;
using MBlogCore.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MBlogCore.Web.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles ="Admin")]
	public class BlogController:Controller
	{
		private readonly MBlogContext context;
		public BlogController(MBlogContext context)
		{
			this.context = context;
		}
		[HttpGet]
		public IActionResult Index()
		{
            IEnumerable<BlogListViewModel> model =context.blogs.AsNoTracking().Where(p=> p.IsDeleted==false).Select(p=> new BlogListViewModel
            {
				Title=p.Title,
				IsHidden=p.IsHidden,
				Id=p.Id.ToString()
			}).ToList();
			return View("Index",model);
		}

		[HttpGet]
		public IActionResult Create()
		{
			return View("Create");
		}

		[HttpPost]
		[ActionName("Create")]
		public IActionResult CreateAction(BlogCreateViewModel model)
		{
			if (ModelState.IsValid)
			{
				BlogTable blog = new BlogTable()
				{
					Title = model.Title,
					IsHidden = model.IsHidden
				};
				context.blogs.Add(blog);
				context.SaveChanges();
                TempData["SuccessMessage"] = "Blog Create Save Successfully!";
                return RedirectToAction("Index","Blog",new {area="Admin"});
			}
			TempData["ErrorMessage"] = "Blog Create Save Failed";
			return View("Create",model);
		}

		[HttpGet]
		public IActionResult Update(string Id)
		{
			BlogCreateViewModel? blog=context.blogs.AsNoTracking().Where(p=> p.Id==Guid.Parse(Id) && p.IsDeleted==false).Select(p=> new BlogCreateViewModel
			{
				IsHidden=p.IsHidden,
				Title=p.Title
			}).FirstOrDefault();
			if (blog != null)
			{
                return View("Update", blog);
            }
			return RedirectToAction("Index","Blog",new { area = "Admin" });
		}
        [HttpPost]
		[ActionName("Update")]
        public IActionResult UpdateAction(string Id,BlogCreateViewModel model)
        {
			if (ModelState.IsValid)
			{
				BlogTable? blog=context.blogs.Where(p => p.Id == Guid.Parse(Id) && p.IsDeleted == false).FirstOrDefault();
				blog.IsHidden = true;
				blog.Title = model.Title;
				context.blogs.Update(blog);
				context.SaveChanges();
            }
            return RedirectToAction("Index", "Blog", new { area = "Admin" });
        }

		[HttpPost]
		public IActionResult Delete(string Id)
		{
			BlogTable? blog=context.blogs.Where(p => p.Id == Guid.Parse(Id)).FirstOrDefault();
			if (blog != null)
			{
				if (blog.IsDeleted == false)
				{
                    blog.IsDeleted = true;
                    context.blogs.Update(blog);
                    context.SaveChanges();
                    TempData["ErrorMessage"] = "Delete Successfully";
                    return RedirectToAction("Index", "Blog", new { area = "Admin" });
                }
				TempData["ErrorMessage"] = "Already Deleted";
                return RedirectToAction("Index", "Blog", new { area = "Admin" });
            }
            TempData["ErrorMessage"] = "Fail to Delete!";
            return RedirectToAction("Index", "Blog", new { area = "Admin" });
        }
    }
}

