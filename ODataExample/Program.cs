using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;

namespace ODataExample
{
	public class Program
	{
		public static void Main(string[] args)
		{
			const string con = @"Server=(localdb)\mssqllocaldb;Database=ProductsDB;Trusted_Connection=True";

			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddDbContext<MyContext>(opt => opt.UseSqlServer(con));

			builder.Services.AddControllers()
				.AddOData(opt => opt.Filter().Select());
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();

			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}
}