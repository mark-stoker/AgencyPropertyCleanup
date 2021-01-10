using System;
using AgencyPropertyCleanup.AgencyFactoryMethod.Interfaces;
using AgencyPropertyCleanup.Interfaces;

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
			return GetDistance((double)agencyProperty.Latitude, (double)agencyProperty.Longitude,
				(double)databaseProperty.Latitude, (double)databaseProperty.Longitude);
		}

		//TODO 1 degree of latitude or longitude is equal to 111km
		private double GetDistance(double agencyLatitude, double agencyLongitude, double databaseLatitude, double databaseLongitude)
		{
			var radiansOverDegrees = (Math.PI / 180.0);

			var agencyLatitudeRadians = agencyLatitude * radiansOverDegrees;
			var agencyLongitudeRadians = agencyLongitude * radiansOverDegrees;
			var databaseLatitudeRadians = databaseLatitude * radiansOverDegrees;
			var databaseLongitudeRadians = databaseLongitude * radiansOverDegrees - agencyLongitudeRadians;

			var haversineFormulaResult = Math.Pow(Math.Sin((databaseLatitudeRadians - agencyLatitudeRadians) / 2.0), 2.0) + Math.Cos(agencyLatitudeRadians) * Math.Cos(databaseLatitudeRadians) * Math.Pow(Math.Sin(databaseLongitudeRadians / 2.0), 2.0);

			var radiusOfEarth = 6376500.0; //Meters
			return radiusOfEarth * (2.0 * Math.Atan2(Math.Sqrt(haversineFormulaResult), Math.Sqrt(1.0 - haversineFormulaResult)));
		}
	}
}
