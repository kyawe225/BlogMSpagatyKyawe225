using MBlogCore.Persistance.Context;
using MBlogCore.Persistance.Tables;
using MBlogCore.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MBlogCore.Web.Controllers
{
	public class ReviewController:Controller
	{
		private MBlogContext context;
		public ReviewController(MBlogContext context)
		{
			this.context = context;
		}
		[HttpGet]
		public IActionResult Index(string Id)
		{
			try
			{
                Guid BlogId = Guid.Parse(Id);
                var reviews=context.reviews.AsNoTrackingWithIdentityResolution().Where(p=> p.BlogId.Equals(BlogId)).ToList();
                return Ok(new {data= reviews});
            }
			catch(Exception e)
			{
				return BadRequest("something wrong");
			}
			
		}
		[HttpPost]
		[ActionName("Create")]
		public IActionResult Insert(ReviewViewModel model)
		{
			if (ModelState.IsValid)
			{
				ReviewTable table = new ReviewTable
				{
					Message = model.Message,
					BlogId = Guid.Parse(model.BlogId),
					UserId=Guid.NewGuid()
				};
				context.reviews.Add(table);
				context.SaveChanges();
				return Ok("Saved Successfully");
			}
			return BadRequest("something wrong");
		}
	}
}

