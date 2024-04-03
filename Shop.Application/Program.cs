using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Cors;
using Microsoft.EntityFrameworkCore;
using Shop.Services;
using Shop.Services.Repositoryes;
using Shop.ServicesInterfaces;
using WebApplication2.Controllers.Products.Api;

namespace WebApplication2;

public class Program
{
	public static void Main(string[] args)
	{
		WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

		string? connection = builder.Configuration.GetConnectionString("DefaultConnection");
		EnableCorsAttribute enableCorsAttribute = new();
		builder.Services.AddScoped<NewsRepository>();
		builder.Services.AddScoped<UserRepository>();
		builder.Services.AddDbContext<WebApplicationContext>(options => options.UseSqlServer(connection));

		builder.Services.AddControllers();
		builder.WebHost.UseStaticWebAssets();
		builder.Services.AddFluentValidationAutoValidation();
		builder.Services.AddTransient<IProductsRepository, ProductsRepository>();
		builder.Services.AddTransient<ProductsApiController>();
		
		builder.Services.AddCors(options =>
		{
			options.AddPolicy("AllowOrigin",
				a =>
				{
					a.AllowAnyOrigin()
						.AllowAnyMethod()
						.AllowAnyHeader();
				});
		});
		
		
		// builder.Services.Configure<CookiePolicyOptions>(
		// 	options =>
		// 	{
		// 		options.MinimumSameSitePolicy = SameSiteMode.Lax;
		//
		// 		options.OnAppendCookie = cookieContext =>
		// 			CheckSameSite(cookieContext.Context, cookieContext.CookieOptions);
		// 		options.OnDeleteCookie = cookieContext =>
		// 			CheckSameSite(cookieContext.Context, cookieContext.CookieOptions);
		// 	}
		// );
		var app = builder.Build();

		if (!app.Environment.IsDevelopment())
		{
			app.UseHsts();
			app.UseSwaggerUI();
		}
		app.UseCors("AllowOrigin");
		app.UseHttpsRedirection();
		app.UseStaticFiles();

		app.UseRouting();
		
		app.UseAuthorization();

		app.MapControllers();

		app.Run();
	}

	private static void CheckSameSite(HttpContext httpContext, CookieOptions options)
	{
		if (options.SameSite != SameSiteMode.None)
			return;

		var userAgent = httpContext.Request.Headers.UserAgent.ToString();

		if (IsKnownBrowser(userAgent))
			options.SameSite = SameSiteMode.Unspecified;
		else
			options.SameSite = SameSiteMode.Lax;
	}

	private static bool IsKnownBrowser(string userAgent) =>
		userAgent.Contains("Chrome") || userAgent.Contains("Firefox") ||
		userAgent.Contains("Safari") || userAgent.Contains("Opera") ||
		userAgent.Contains("Edge") || userAgent.Contains("IE");
}