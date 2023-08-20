using MBlogCore.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
namespace MBlogCore.Web.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class ReviewController:Controller
	{
		private MBlogContext context;
		public ReviewController(MBlogContext context)
		{
			this.context = context;
		}
		public IActionResult Index()
		{
			var reviews=context.reviews.AsNoTracking().ToList();
			return View(reviews);
		}
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

