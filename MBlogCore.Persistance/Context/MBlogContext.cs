using System;
using MBlogCore.Persistance.Tables;
using Microsoft.EntityFrameworkCore;

namespace MBlogCore.Persistance.Context
{
	public class MBlogContext:DbContext
	{
		public DbSet<ContactTable>contacts { set; get; }
        public DbSet<User> users { set; get; }
        public DbSet<ReviewTable> reviews { set; get; }
        public DbSet<BlogTable> blogs { set; get; }
        public DbSet<BlogContentTable> blogContent { set; get; }
		public MBlogContext(DbContextOptions<MBlogContext> options) : base(options)
		{

		}
	}
}

