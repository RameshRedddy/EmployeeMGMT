using EmployeeMGMT.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace EmployeeMGMT.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{
		}
		public DbSet<Users> Users { get; set; }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			//base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<Users>().HasData(
				new Users
				{
					Id = 1,
					Name = "Rama",
					Email = "Rama@gmail.com",
					Password = "Rama",
					Role = "Admin",
					CreatedDate =  DateTime.Now

				},
			   new Users
			   {
				   Id = 2,
				   Name = "Sita",
				   Email = "Sita@gmail.com",
				   Password = "Sita",
				   Role = "IT",
				   CreatedDate = DateTime.Now
			   },
			   new Users
			   {
				   Id = 3,
				   Name = "Laxman",
				   Email = "Laxman@gmail.com",
				   Password = "Laxman",
				   Role = "Sales Executive",
				   CreatedDate = DateTime.Now
			   },

				new Users
				{
					Id = 4,
					Name = "Hanuman",
					Email = "Hanuman@gmail.com",
					Password = "Hanuman",
					Role = "Software",
					CreatedDate = DateTime.Now
				});
		}
	}
}
