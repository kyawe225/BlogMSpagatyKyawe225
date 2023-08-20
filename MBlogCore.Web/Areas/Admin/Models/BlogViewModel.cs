namespace MBlogCore.Web.Areas.Admin.Models
{
	public class BlogCreateViewModel
	{
		public string Title;
		//public bool isHidden;
		//public IList<BlogContentCreateViewModel> contents;
	}
	public class BlogContentCreateViewModel
	{
		public string Content;
		public string Type;
	}
}

