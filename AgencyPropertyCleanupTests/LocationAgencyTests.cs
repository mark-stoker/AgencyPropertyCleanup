using AgencyPropertyCleanup;
using AgencyPropertyCleanup.AgencyFactoryMethod;
using AgencyPropertyCleanup.AgencyFactoryMethod.Interfaces;
using AgencyPropertyCleanup.Interfaces;
using NUnit.Framework;

namespace AgencyPropertyCleanupTests
{
	public class LocationAgencyTests
	{
		//I need to pre-populate these, autofixture?
		private IProperty _agencyProperty;
		private IProperty _databaseProperty;

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
		public void LocationRealEstatePropertyMatchingRules_CoordinatesAre69mApart_MatchMethodReturnsTrue()
		{
			//Arrange
			IAgencyFactory agencyFactory = new LocationAgencyFactory();
			IAgency agency = agencyFactory.CreateAgency();

			_agencyProperty.Latitude = -33.86974404504831m;
			_agencyProperty.Longitude = 151.192819601541m;

			//Act
			var expectedResult = true;
			var result = agency.IsMatch(_agencyProperty, _databaseProperty);

			//Assert
			Assert.AreEqual(expectedResult, result);
		}

		[Test]
		public void LocationRealEstatePropertyMatchingRules_CoordinatesAre190mApart_MatchMethodReturnsTrue()
		{
			//Arrange
			IAgencyFactory agencyFactory = new LocationAgencyFactory();
			IAgency agency = agencyFactory.CreateAgency();

			_agencyProperty.Latitude = -33.869998418662725m;
			_agencyProperty.Longitude = 151.19388990421092m;

			//Act
			var expectedResult = true;
			var result = agency.IsMatch(_agencyProperty, _databaseProperty);

			//Assert
			Assert.AreEqual(expectedResult, result);
		}

		[Test]
		public void LocationRealEstatePropertyMatchingRules_CoordinatesAre210mApart_MatchMethodReturnsFalse()
		{
			//Arrange
			IAgencyFactory agencyFactory = new LocationAgencyFactory();
			IAgency agency = agencyFactory.CreateAgency();

			_agencyProperty.Latitude = -33.86995770861321m;
			_agencyProperty.Longitude = 151.19433375715846m;

			//Act
			var expectedResult = true;
			var result = agency.IsMatch(_agencyProperty, _databaseProperty);

			//Assert
			Assert.AreEqual(expectedResult, result);
		}

		[Test]
		public void LocationRealEstatePropertyMatchingRules_CoordinatesAre350mApart_MatchMethodReturnsFalse()
		{
			//Arrange
			IAgencyFactory agencyFactory = new LocationAgencyFactory();
			IAgency agency = agencyFactory.CreateAgency();

			_agencyProperty.Latitude = -33.871077461586744m;
			_agencyProperty.Longitude = 151.19495614459848m;

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