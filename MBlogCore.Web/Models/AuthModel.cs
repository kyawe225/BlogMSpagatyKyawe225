using System;
namespace MBlogCore.Web.Models
{
	public class LoginModel
	{
		public string Email { set; get; }
		public string Password { set; get; }
	}

	public class RegisterModel
	{
		public string Email { set; get; }
		public string Password { set; get; }
		public string ConfirmPassword { set; get; }
		public string Name { set; get; }
		public DateTime DateOfBirth { set; get; }
	}
}

