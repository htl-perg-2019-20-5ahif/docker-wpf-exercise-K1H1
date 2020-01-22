using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Model;

namespace WebAPI
{
	public class CarDbContext:DbContext
	{
		public DbSet<Car> Cars { get; set; }

		public DbSet<Booking> Bookings { get; set; }


		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Server=tcp:localhost;Database=CarBookings;User Id=sa;Password=password1234!!!!;");
		}
	}

}
