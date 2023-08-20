using System;
using System.ComponentModel.DataAnnotations;

namespace MBlogCore.Persistance.Tables
{
	public class BlogTable:BaseTable
	{
		[StringLength(200)]
		public string Title { set; get; }
		public bool IsHidden { set; get; }
		public Guid CreatedUserId { set; get; }
		public Guid UpdatedUserId { set; get; }
		public BlogTable()
		{
		}
	}
}

