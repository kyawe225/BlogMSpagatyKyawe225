using MBlogCore.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using MBlogCore.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;

namespace MBlogCore.Web.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles ="Admin")]
	public class ReviewController:Controller
	{
		private MBlogContext context;
		public ReviewController(MBlogContext context)
		{
			this.context = context;
		}
		[HttpGet]
		public IActionResult Index()
		{
			var reviews=context.reviews.AsNoTracking().Select(p=> new ReviewViewModel
			{
				Id=p.Id.ToString(),
				Message=p.Message
			}).ToList();
			return View(reviews);
		}
		[HttpPost]
		public IActionResult Delete(string Id)
		{
			var review=context.reviews.Where(p => p.Id == Guid.Parse(Id)).FirstOrDefault();
			if (review != null)
			{
                context.reviews.Remove(review);
				context.SaveChanges();
				TempData["SuccessMessage"] = "Delete Successfully";
            }
			TempData["ErrorMessage"] = "Delete not successfully";
			return RedirectToAction("Index");	
		}
	}
}

