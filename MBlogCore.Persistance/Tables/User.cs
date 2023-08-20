using System;
using System.ComponentModel.DataAnnotations;

namespace MBlogCore.Persistance.Tables
{
	public class User:BaseTable
	{
		[StringLength(70)]
		public string Email { set; get; }
		[StringLength(200)]
		public string Name { set; get; }
		[StringLength(50)]
		public string Password { set; get; }
		[StringLength(200)]
		public string? Address { set; get; }
		[StringLength(20)]
        public string? PhoneNumber { set; get; }
		public DateTime? DOB { set; get; }
		public bool IsFullyActivated { set; get; }
        public bool IsActive { set; get; }
		public User()
		{
		}
	}
}

