using Asma.DAL.Data;
using Asmaa.DAL.Model;
using Asmaa.Pl.mapping;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Asma.pl
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
			builder.Services.AddDbContext<ApplicationDbContext>(options =>
				options.UseSqlServer(connectionString));

			builder.Services.AddDatabaseDeveloperPageExceptionFilter();

			builder.Services.AddIdentity<ApplicationUser, IdentityRole>
				(options => options.SignIn.RequireConfirmedAccount = true)//ممنوع اي حدا يعمل تسجيل دخول ع المشروع الا يكون عامل حساب و تاكيد للحساب
				.AddEntityFrameworkStores<ApplicationDbContext>()
				.AddDefaultUI()   //بحطها لاني استعملت الاد ايدينتتي
				.AddDefaultTokenProviders();//عشان اعمل الفورجيت باسوورد 
				builder.Services.AddControllersWithViews();
			builder.Services.AddAutoMapper(Assembly.GetAssembly(typeof(MappingProfile)));

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseMigrationsEndPoint();
			}
			else
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			app.UseHttpsRedirection();
			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();

			app.MapControllerRoute(
				 name: "areas",
			pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");
			app.MapRazorPages();

			app.Run();
		}
	}
}
