using System.ComponentModel.DataAnnotations;
using MBlogCore.Persistance.Context;
using MBlogCore.Persistance.Tables;
using MBlogCore.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace MBlogCore.Web.Controllers
{
	public class ContactController:Controller
	{
		private readonly MBlogContext c;
		public ContactController(MBlogContext context)
		{
			this.c = context;
		}
		[HttpGet]
		public IActionResult Index()
		{
			return View("Index");
		}
		[HttpPost]
		[ActionName("Index")]
		public IActionResult Create(ContactCreateViewModel model)
		{
			if (ModelState.IsValid)
			{
				ContactTable contact = new ContactTable()
				{
					Email=model.Email,
					Name=model.Name,
					Message=model.Message
				};
				c.contacts.Add(contact);
				c.SaveChanges();
				TempData["SuccessMessage"] = "Successfully Added!";
				return RedirectToAction("Index","Contact");
            }
            TempData["SuccessMessage"] = "Errors Occour!";
            return View("Index",model);
		}
	}
}

