using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Million.Book.Aplicacion.Abstract;
using Million.Book.Aplicacion.Helpers;
using Million.Book.Aplicacion.Implements;
using Million.Book.Infraestructura.Interfaces;
using Million.Book.Infraestructura.Repositorio;
using Million.Book.Modelo.EntityModel;



using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;

using Microsoft.EntityFrameworkCore;
using Million.Book.Comun.Helpers;

namespace Million.Book.UI
{
	public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			string conexionGeneral = this.Configuration.GetConnectionString("DefaultConnection");
			services.AddDbContext<MillionEntities>(options => options.UseSqlServer(conexionGeneral));

			CommonHelpers.Instance.MillionEntitiesConnectionString = conexionGeneral;
			services.AddControllersWithViews();
			services.AddScoped<ILibroService, LibroService>();
			services.AddScoped<ILibroRepository, LibroRepository>();
			services.AddScoped<IEditorialService, EditorialService>();
			services.AddScoped<IEditorialRepository, EditorialRepository>();

			//Configuracion de autommaper
			// Auto Mapper Configurations
			var mappingConfig = new MapperConfiguration(mc =>
			{
				mc.AddProfile(new MappingProfiles());
			});



			IMapper mapper = mappingConfig.CreateMapper();
			services.AddSingleton(mapper);

			services.AddMvc();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
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

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllerRoute(
					name: "default",
					pattern: "{controller=Home}/{action=Index}/{id?}");
			});

			

		}
	}
}
