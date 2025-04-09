﻿namespace WebStoryFroEveryting.Services.Apis.Dtos
{
	public class WeatherDto
	{
		public double latitude { get; set; }
		public double longitude { get; set; }
		public double generationtime_ms { get; set; }
		public int utc_offset_seconds { get; set; }
		public string timezone { get; set; }
		public string timezone_abbreviation { get; set; }
		public double elevation { get; set; }
		public CurrentUnits current_units { get; set; }
		public Current current { get; set; }
		public HourlyUnits hourly_units { get; set; }
		public Hourly hourly { get; set; }
	}

	public class Current
	{
		public string time { get; set; }
		public int interval { get; set; }
		public double temperature_2m { get; set; }
		public double wind_speed_10m { get; set; }
	}

	public class CurrentUnits
	{
		public string time { get; set; }
		public string interval { get; set; }
		public string temperature_2m { get; set; }
		public string wind_speed_10m { get; set; }
	}

	public class Hourly
	{
		public List<string> time { get; set; }
		public List<double> temperature_2m { get; set; }
		public List<int> relative_humidity_2m { get; set; }
		public List<double> wind_speed_10m { get; set; }
	}

	public class HourlyUnits
	{
		public string time { get; set; }
		public string temperature_2m { get; set; }
		public string relative_humidity_2m { get; set; }
		public string wind_speed_10m { get; set; }
	}
}
