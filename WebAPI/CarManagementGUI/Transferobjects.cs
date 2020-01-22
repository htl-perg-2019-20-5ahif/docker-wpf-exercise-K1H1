using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace CarManagementGUI
{
	public class Car
	{

		[JsonPropertyName("carID")]
		public int CarID { get; set; }

		[JsonPropertyName("make")]
		public string Make { get; set; }

		[JsonPropertyName("model")]
		public string Model { get; set; }

		[JsonPropertyName("bookings")]
		public List<Booking> Bookings { get; set; }
	}


	public class Booking {

		[JsonPropertyName("bookingId")]
		public int BookingId { get; set; }


		[JsonPropertyName("bookedDate")]
		public DateTime BookedDate { get; set; }


		[JsonPropertyName("carID")]
		public int CarId { get; set; }

		[JsonPropertyName("car")]
		public Car Car { get; set; }
	}
	
	public class BookingRequest {
		[JsonPropertyName("CarId")]
		public int CarID { get; set; }
		[JsonPropertyName("BookingDate")]
		public DateTime BookingDate { get; set; }

		public bool IsValid()
		{
			return BookingDate != null && BookingDate.Date > DateTime.Now;
		}
	}
}
