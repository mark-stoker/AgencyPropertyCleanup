using AgencyPropertyCleanup;
using AgencyPropertyCleanup.AgencyFactoryMethod;
using AgencyPropertyCleanup.AgencyFactoryMethod.Interfaces;
using AgencyPropertyCleanup.Interfaces;
using NUnit.Framework;

namespace AgencyPropertyCleanupTests
{
	public class LocationAgencyTests
	{
		private Property _agencyProperty;
		private Property _databaseProperty;

		[SetUp]
		public void Setup()
		{
			_agencyProperty = new Property
			{
				Address = "32 Sir John-Young Crescent, Sydney, NSW.",
				AgencyCode = "OTBRE",
				Name = "*Super*-High! APARTMENTS (Sydney)",
				Latitude = -33.87053923302913m,
				Longitude = 151.19248064675406m,
				
				
			};

			_databaseProperty = new Property
			{
				Address = "32 Sir John Young Crescent Sydney NSW",
				AgencyCode = "OTBRE",
				Name = "Super High Apartments Sydney",
				Latitude = -33.87053923302913m,
				Longitude = 151.19248064675406m
			};
		}

		[Test]
		public void LocationRealEstatePropertyMatchingRules_CoordinatesMatchExactly_MatchMethodReturnsTrue()
		{
			//Arrange
			IAgencyFactory agencyFactory = new LocationAgencyFactory();
			IAgency agency = agencyFactory.CreateAgency();

			//Act
			var expectedResult = true;
			var result = agency.IsMatch(_agencyProperty, _databaseProperty);

			//Assert
			Assert.AreEqual(expectedResult, result);
		}

		[Test]
		public void LocationRealEstatePropertyMatchingRules_CoordinatesAre74mApart_MatchMethodReturnsTrue()
		{
			//Arrange
			IAgencyFactory agencyFactory = new LocationAgencyFactory();
			IAgency agency = agencyFactory.CreateAgency();

			_agencyProperty.Latitude = -33.8704650641735m;
			_agencyProperty.Longitude = 151.19327692034656m;

			//Act
			var expectedResult = true;
			var result = agency.IsMatch(_agencyProperty, _databaseProperty);

			//Assert
			Assert.AreEqual(expectedResult, result);
		}

		[Test]
		public void LocationRealEstatePropertyMatchingRules_CoordinatesAre198mApart_MatchMethodReturnsTrue()
		{
			//Arrange
			IAgencyFactory agencyFactory = new LocationAgencyFactory();
			IAgency agency = agencyFactory.CreateAgency();

			_agencyProperty.Latitude = -33.87026908171481m;
			_agencyProperty.Longitude = 151.19459586212446m;

			//Act
			var expectedResult = true;
			var result = agency.IsMatch(_agencyProperty, _databaseProperty);

			//Assert
			Assert.AreEqual(expectedResult, result);
		}

		[Test]
		public void LocationRealEstatePropertyMatchingRules_CoordinatesAre201mApart_MatchMethodReturnsFalse()
		{
			//Arrange
			IAgencyFactory agencyFactory = new LocationAgencyFactory();
			IAgency agency = agencyFactory.CreateAgency();

			_agencyProperty.Latitude = -33.87026113647057m;
			_agencyProperty.Longitude = 151.19462297459012m;

			//Act
			var expectedResult = false;
			var result = agency.IsMatch(_agencyProperty, _databaseProperty);

			//Assert
			Assert.AreEqual(expectedResult, result);
		}

		[Test]
		public void LocationRealEstatePropertyMatchingRules_CoordinatesAre325mApart_MatchMethodReturnsFalse()
		{
			//Arrange
			IAgencyFactory agencyFactory = new LocationAgencyFactory();
			IAgency agency = agencyFactory.CreateAgency();

			_agencyProperty.Latitude = -33.86979898682514m;
			_agencyProperty.Longitude = 151.1958797170757m;

			//Act
			var expectedResult = false;
			var result = agency.IsMatch(_agencyProperty, _databaseProperty);

			//Assert
			Assert.AreEqual(expectedResult, result);
		}

		[Test]
		public void LocationRealEstatePropertyMatchingRules_CoordinatesAre171kmAway_MatchMethodReturnsFalse()
		{
			//Arrange
			IAgencyFactory agencyFactory = new LocationAgencyFactory();
			IAgency agency = agencyFactory.CreateAgency();

			_agencyProperty.Latitude = -32.92175413965179m;
			_agencyProperty.Longitude = 151.78209440879309m;

			//Act
			var expectedResult = false;
			var result = agency.IsMatch(_agencyProperty, _databaseProperty);

			//Assert
			Assert.AreEqual(expectedResult, result);
		}

		[Test]
		public void LocationRealEstatePropertyMatchingRules_CoordinatesPropertiesAreZero_MatchMethodReturnsFalse()
		{
			//Arrange
			IAgencyFactory agencyFactory = new LocationAgencyFactory();
			IAgency agency = agencyFactory.CreateAgency();

			_agencyProperty.Latitude = 0.00m;
			_agencyProperty.Longitude = 0.00m;

			//Act
			var expectedResult = false;
			var result = agency.IsMatch(_agencyProperty, _databaseProperty);

			//Assert
			Assert.AreEqual(expectedResult, result);
		}

		[Test]
		public void LocationRealEstatePropertyMatchingRules_AgencyCodesDontMatch_MatchMethodReturnsFalse()
		{
			//Arrange
			IAgencyFactory agencyFactory = new LocationAgencyFactory();
			IAgency agency = agencyFactory.CreateAgency();

			_agencyProperty.AgencyCode = "CRE";

			//Act
			var expectedResult = false;
			var result = agency.IsMatch(_agencyProperty, _databaseProperty);

			//Assert
			Assert.AreEqual(expectedResult, result);
		}

		[Test]
		public void LocationRealEstatePropertyMatchingRules_AgencyCodesAreNull_MatchMethodReturnsFalse()
		{
			//Arrange
			IAgencyFactory agencyFactory = new LocationAgencyFactory();
			IAgency agency = agencyFactory.CreateAgency();

			_agencyProperty.AgencyCode = null;

			//Act
			var expectedResult = false;
			var result = agency.IsMatch(_agencyProperty, _databaseProperty);

			//Assert
			Assert.AreEqual(expectedResult, result);
		}
	}
}