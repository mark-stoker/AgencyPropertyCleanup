using System;
using AgencyPropertyCleanup.AgencyFactoryMethod.Interfaces;
using GeoCoordinatePortable;

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

		public double CalculateDistance(IProperty agencyProperty, IProperty databaseProperty)
		{
			//Todo implement the alg too, just to understand it
			//var d1 = agencryProperty.Latitude * ((decimal)Math.PI / 180.0m);
			//var num1 = agencryProperty.Longitude * ((decimal)Math.PI / 180.0m);
			//var d2 = databaseProperty.Latitude * ((decimal)Math.PI / 180.0m);
			//var num2 = databaseProperty.Longitude * ((decimal)Math.PI / 180.0m) - num1;
			//var d3 = Math.Pow(Math.Sin((d2 - d1) / 2.0m), 2.0m) +
			//         Math.Cos(d1) * Math.Cos(d2) * Math.Pow(Math.Sin(num2 / 2.0m), 2.0m);
			//return 6376500.0m * (2.0m * Math.Atan2(Math.Sqrt(d3), Math.Sqrt(1.0m - d3)));

			var agencyCoordinates = new GeoCoordinate((double)agencyProperty.Longitude, (double)agencyProperty.Latitude);
			var databaseCoordinates = new GeoCoordinate((double)databaseProperty.Longitude, (double)databaseProperty.Latitude);

			return agencyCoordinates.GetDistanceTo(databaseCoordinates);
		}

		//public double GetDistanceTo(GeoCoordinate other)
		//{
		//	if (double.IsNaN(this.Latitude) || double.IsNaN(this.Longitude) || (double.IsNaN(other.Latitude) || double.IsNaN(other.Longitude)))
		//		throw new ArgumentException("Argument latitude or longitude is not a number");
		//	double d1 = this.Latitude * 0.0174532925199433;
		//	double num1 = this.Longitude * 0.0174532925199433;
		//	double d2 = other.Latitude * 0.0174532925199433;
		//	double num2 = other.Longitude * 0.0174532925199433 - num1;
		//	double d3 = Math.Pow(Math.Sin((d2 - d1) / 2.0), 2.0) + Math.Cos(d1) * Math.Cos(d2) * Math.Pow(Math.Sin(num2 / 2.0), 2.0);
		//	return 6376500.0 * (2.0 * Math.Atan2(Math.Sqrt(d3), Math.Sqrt(1.0 - d3)));
		//}
	}
}
