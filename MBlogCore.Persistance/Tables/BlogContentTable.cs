using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MBlogCore.Persistance.Tables
{
	public class BlogContentTable:BaseTable
	{
		[StringLength(500)]
		public string Content { set; get; }
		[StringLength(30)]
		public string Type { set; get; }
		public Guid BlogId { set; get; }
		public BlogContentTable()
		{
		}
	}
}

