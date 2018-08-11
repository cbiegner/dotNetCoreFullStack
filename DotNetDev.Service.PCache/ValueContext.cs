using Microsoft.EntityFrameworkCore;

namespace DotNetDev.Service.PCache
{
	using Model;

	public class ValueContext : DbContext
	{
		public ValueContext(DbContextOptions<ValueContext> options)
			: base(options)
		{
		}

		public DbSet<Person> Persons { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Person>().OwnsOne(p => p.Address);
			modelBuilder.Entity<Person>().OwnsOne(p => p.Communication);
		}
	}
}
