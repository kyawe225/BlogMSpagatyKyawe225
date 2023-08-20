using System;
namespace MBlogCore.Web.Areas.Admin.Models
{
	public class UserCreateViewModel
	{
		public string Email { set; get; }
		public string Name { set; get; }
		public string Password { set; get; }
		public string Address { set; get; }
		public string PhoneNumber { set; get; }
		public DateTime DOB { set; get; }
	}
    public class UserUpdateViewModel
    {
        public string Email { set; get; }
        public string Name { set; get; }
        public string Password { set; get; }
        public string? Address { set; get; }
        public string? PhoneNumber { set; get; }
        public DateTime? DOB { set; get; }
        public bool IsActive { set; get; }
    }
}

