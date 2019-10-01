using Api.Core.Models.Configuration;
using Api.Injection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;
using System.IO;
using System.Text;

namespace Api.Net._3
{
	public class Startup
	{
		public IConfiguration Configuration { get; }
		public AppSettings AppSettings { get; set; }

		public Startup(IConfiguration configuration, IHostEnvironment env)
		{
			Configuration = configuration;

			string appsettingsPath;

#if DEBUG
			appsettingsPath = $"{AppDomain.CurrentDomain.BaseDirectory}appsettings.{env.EnvironmentName}.json";
#else
			appsettingsPath = $"{AppDomain.CurrentDomain.BaseDirectory}appsettings.json";
#endif
			var builder = new ConfigurationBuilder()
		   .AddJsonFile(appsettingsPath, optional: false, reloadOnChange: true)
		   .AddEnvironmentVariables();

			AppSettings = JsonConvert.DeserializeObject<AppSettings>(File.ReadAllText(appsettingsPath, Encoding.UTF8));
			Configuration = builder.Build();
		}

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers();

			// Injections
			services.AddInjectionsBll();

			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
			});
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			app.UseSwagger();
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
				c.RoutePrefix = string.Empty;
				c.DocExpansion(DocExpansion.None);
			});

			app.UseHttpsRedirection();
			app.UseRouting();
			app.UseAuthorization();
			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
