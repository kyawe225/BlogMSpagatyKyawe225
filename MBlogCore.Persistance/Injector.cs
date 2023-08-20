using System;
using System.Runtime.CompilerServices;
using MBlogCore.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MBlogCore.Persistance
{
	public static class Injector
	{
		public static void Postgresql(this IServiceCollection collection, IConfiguration config)
		{
			collection.AddDbContext<MBlogContext>(options=> options.UseNpgsql(config.GetConnectionString("local")));
		}
	}
}