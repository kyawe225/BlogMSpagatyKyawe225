namespace MBlogCore.Web.Areas.Admin.Models
{
	public class BlogCreateViewModel
	{
		public string Title { set; get; }
		public bool IsHidden { set; get; }
		//public IList<BlogContentCreateViewModel> contents;
	}
    public class BlogListViewModel
    {
        public string Title { set; get; }
        public bool IsHidden { set; get; }
		public string Id { set; get; }
        //public IList<BlogContentCreateViewModel> contents;
    }
    public class BlogContentCreateViewModel
	{
		public string Content;
		public string Type;
	}
}

