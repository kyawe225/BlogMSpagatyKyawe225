
using System.ComponentModel.DataAnnotations;

namespace MBlogCore.Web.Models
{
	public class ReviewViewModel
	{
		public string BlogId { set; get; }
		[StringLength(256)]
		public string Message { set; get; }
	}
}

