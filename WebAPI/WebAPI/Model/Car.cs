using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Model
{
	public class Car
	{
		
		public int CarID { get; set; }

		[Required]
		public string Make { get; set; }

		[Required]
		public string Model { get; set; }

		public List<Booking> Bookings { get; set; }

	}
}
