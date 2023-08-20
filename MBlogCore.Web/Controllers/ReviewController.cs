using System;
using MBlogCore.Persistance.Context;
using MBlogCore.Persistance.Tables;
using MBlogCore.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace MBlogCore.Web.Controllers
{
	public class ReviewController:ControllerBase
	{
		private MBlogContext context;
		public ReviewController(MBlogContext context)
		{
			this.context = context;
		}
		[HttpGet]
		public IActionResult Index()
		{
			return Ok("Hello World");
		}
		[HttpPost]
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

