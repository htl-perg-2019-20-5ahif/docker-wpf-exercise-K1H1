using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;


namespace CarManagementGUI
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private static HttpClient _client
			  = new HttpClient() { BaseAddress = new Uri("http://localhost:5000/api/") };

		public ObservableCollection<Car> CarList { get; set; } = new ObservableCollection<Car>();
		List<Booking> bookingList = new List<Booking>();

		public MainWindow()
		{
			InitializeComponent();
			DataContext = this;
		}


		public async void LoadCars(object sender, RoutedEventArgs e)
		{
			MessageBox.Text = "";
			var ApiResponse = await _client.GetAsync("Cars");
			ApiResponse.EnsureSuccessStatusCode();

			var ResponseBody = await ApiResponse.Content.ReadAsStringAsync();
			var Cars = JsonSerializer.Deserialize<Car[]>(ResponseBody, new JsonSerializerOptions { PropertyNameCaseInsensitive = false });
			ApiResponse.EnsureSuccessStatusCode();
		
		}


		private async void BookCar(object sender, RoutedEventArgs e)
		{

			if (Date.DisplayDate != default)
			{
				BookingRequest Booking = new BookingRequest()
				{
					CarID = Int32.Parse(CarID.Text),
					BookingDate = Date.DisplayDate
				};

				var Content = new StringContent(JsonSerializer.Serialize(Booking), Encoding.UTF8, "application/json");
				var ApiResponse = await _client.PostAsync("Bookings", Content);
				ApiResponse.EnsureSuccessStatusCode();
				
				MessageBox.Text = "Car booked successfully";
			}
			else
			{
				MessageBox.Text = "Please fill in a booking date!";
			}
		}

		private async void FilterCars(object sender, RoutedEventArgs e)
		{

			//get bookings
			var apiResponse = await _client.GetAsync("Bookings");
			apiResponse.EnsureSuccessStatusCode();
			var responseBody = await apiResponse.Content.ReadAsStringAsync();
			var Bookings = JsonSerializer.Deserialize<Booking[]>(responseBody, new JsonSerializerOptions { PropertyNameCaseInsensitive = false });

			List<Car> SortedList = new List<Car>();
			Car car;
			foreach (Booking b in Bookings)
			{
				if(b.BookedDate != Date.DisplayDate)
				{
					SortedList.Add(this.CarList[b.CarId]);
				}
			}
			DataContext = SortedList;

		}



	}

	
}
