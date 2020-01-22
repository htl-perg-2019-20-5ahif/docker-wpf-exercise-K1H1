using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Model
{
	public class BookingRequest
	{
		public int CarID { get; set; }
		public DateTime BookingDate { get; set; }

		public bool IsValid()
		{
			return BookingDate != null && BookingDate.Date > DateTime.Now;
		}
	}
}
