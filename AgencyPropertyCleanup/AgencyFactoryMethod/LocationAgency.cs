using System;
using AgencyPropertyCleanup.AgencyFactoryMethod.Interfaces;
using AgencyPropertyCleanup.Interfaces;
//using GeoCoordinatePortable;


namespace AgencyPropertyCleanup.AgencyFactoryMethod
{
	public class LocationAgency : IAgency
	{
		private const int PropertyRadius = 200;

		public string Name { get; set; }
		public string AgencyCode { get; set; }

		public LocationAgency()
		{
			Name = "Location Real Estate";
			AgencyCode = "LRE";
		}

		public bool IsMatch(IProperty agencyProperty, IProperty databaseProperty)
		{
			if (!String.Equals(agencyProperty.AgencyCode, databaseProperty.AgencyCode))
				return false;

			if (CalculateDistance(agencyProperty, databaseProperty) <= PropertyRadius)
				return true;

			return false;
		}

		private double CalculateDistance(IProperty agencyProperty, IProperty databaseProperty)
		{
			//var agencyCoordinates = new GeoCoordinate((double)agencyProperty.Latitude, (double)agencyProperty.Longitude);
			//var databaseCoordinates = new GeoCoordinate((double)databaseProperty.Latitude, (double)databaseProperty.Longitude);
			//return agencyCoordinates.GetDistanceTo(databaseCoordinates);

			return GetDistance((double)agencyProperty.Longitude, (double)agencyProperty.Latitude,
				(double)databaseProperty.Longitude, (double)databaseProperty.Latitude);
		}

		//Returns distance in metres between two points
		//The requirements state: assume that 1 degree of agencyLatitude or agencyLongitude is equal to 111km, I'm not sure how to apply this
		private double GetDistance(double agencyLongitude, double agencyLatitude, double databaseLongitude, double databaseLatitude)
		{
			var d1 = agencyLatitude * (Math.PI / 180.0);
			var num1 = agencyLongitude * (Math.PI / 180.0);
			var d2 = databaseLatitude * (Math.PI / 180.0);
			var num2 = databaseLongitude * (Math.PI / 180.0) - num1;
			var d3 = Math.Pow(Math.Sin((d2 - d1) / 2.0), 2.0) + Math.Cos(d1) * Math.Cos(d2) * Math.Pow(Math.Sin(num2 / 2.0), 2.0);

			return 6376500.0 * (2.0 * Math.Atan2(Math.Sqrt(d3), Math.Sqrt(1.0 - d3)));
		}
	}
}
