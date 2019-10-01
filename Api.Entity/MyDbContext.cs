using Api.Core.Models.Configuration;
using Api.Entity.Entity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Text;


namespace Api.Entity
{
	public partial class MyDbContext : DbContext
	{

		private readonly ConnectionStrings _connectionStrings;
		public MyDbContext()
		{
			string appsettingsPath;
#if DEBUG
			appsettingsPath = $"{AppDomain.CurrentDomain.BaseDirectory}appsettings.Development.json";
#else
			appsettingsPath = $"{AppDomain.CurrentDomain.BaseDirectory}appsettings.json";
#endif
			_connectionStrings = JsonConvert.DeserializeObject<AppSettings>(File.ReadAllText(appsettingsPath, Encoding.UTF8)).ConnectionStrings;
		}

		public DbSet<Cidade> Cidade { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseMySql(_connectionStrings.MyDbContext);
			}
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
		}
	}
}
