namespace WebStoryFroEveryting.Models.Weather
{
	public class WeatherViewModel
	{
		public string CurrentTemperature { get; set; }
		public string UnitsOfMeasurement { get; set; }
		/// <summary>
		/// [['1', 1], [2, 1.2], [3, 2.3]]
		/// </summary>
		public List<List<string>> Temperatures {  get; set; } 
	}
}
