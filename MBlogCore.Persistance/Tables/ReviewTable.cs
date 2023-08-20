using System;
using System.ComponentModel.DataAnnotations;

namespace MBlogCore.Persistance.Tables
{
	public class ReviewTable:BaseTable
	{
		[StringLength(256)]
		public string Message { set; get; }
		public Guid UserId { set; get; }
		public Guid BlogId { set; get; }
		public ReviewTable()
		{
		}
	}
}

