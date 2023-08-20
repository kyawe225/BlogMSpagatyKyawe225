using System;
using System.ComponentModel.DataAnnotations;
namespace MBlogCore.Persistance.Tables
{
	public class ContactTable:BaseTable
	{
		[StringLength(70)]
		public string Name { set; get; }
        [StringLength(70)]
        public string Email { set; get; }
        [StringLength(200)]
        public string Message { set; get; }
		public ContactTable()
		{
		}
	}
}

