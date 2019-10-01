using Microsoft.EntityFrameworkCore;

namespace Api.Entity
{
	public partial class MyDbContext : DbContext
	{
		public MyDbContext()
		{

		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				optionsBuilder.UseMySQL("Server=localhost;User Id=root;Password=1234;Database=treinaweb");
			}
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{ }
	}
}
