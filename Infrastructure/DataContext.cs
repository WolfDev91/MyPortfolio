using Core.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions<DataContext> options) : base(options)
		{

		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<Owner>().Property(x => x.Id).HasDefaultValueSql("NEWID()");
			modelBuilder.Entity<PortfolioItem>().Property(x => x.Id).HasDefaultValueSql("NEWID()");

			modelBuilder.Entity<Owner>().HasData(
				new Owner()
				{
					Id = Guid.NewGuid(),
					Avatar= "AHMED_HUSSEIN.png",
					FlluName="AHMED HUSSEIN",
					Profil=".NET DEVELOPER / FRONT-END ANGULAR"
				}
				) ;

		}

		public DbSet<Owner>Owner { get;  set; } 
		public DbSet<PortfolioItem> PortfolioItems { get;  set; } 
	}
}
