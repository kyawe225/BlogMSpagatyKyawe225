using System;
namespace MBlogCore.Web.Models
{
	public class UserDetailViewModel
	{
		public string Name { set; get; }
		public bool IsActive { set; get; }
		public string Email { set; get; }
		public string? PhoneNumber { set; get; }
		public DateTime? DOB { set; get; }
		public string? Address { set; get; }
		public bool IsFullyActivated { set; get; }
		public UserDetailViewModel()
		{
		}
	}
	public class UserUpdateViewModel
	{
        public string Name { set; get; }
        public string Email { set; get; }
        public string PhoneNumber { set; get; }
        public DateTime DOB { set; get; }
        public string? Address { set; get; }
    }
}

