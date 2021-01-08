using AgencyPropertyCleanup;
using AgencyPropertyCleanup.AgencyFactoryMethod;
using AgencyPropertyCleanup.AgencyFactoryMethod.Interfaces;
using NUnit.Framework;

namespace AgencyPropertyCleanupTests
{
	public class ContraryAgencyTests
	{
		private IProperty _agencyProperty;
		private IProperty _databaseProperty;

		[SetUp]
		public void Setup()
		{
			_agencyProperty = new Property
			{
				Address = "32 Sir John-Young Crescent, Sydney, NSW.",
				AgencyCode = "OTBRE",
				Name = "Apartments Summit The",
				Longitude = -33.87053923302913m,
				Latitude = 151.19248064675406m
			};

			_databaseProperty = new Property
			{
				Address = "32 Sir John Young Crescent Sydney NSW",
				AgencyCode = "OTBRE",
				Name = "The Summit Apartments",
				Longitude = -33.87053923302913m,
				Latitude = 151.19248064675406m
			};
		}
		
		[Test]
		public void ContraryRealEstateMatchingRules_PropertyNameReversedAndMatchesDB_MatchMethodReturnsTrue()
		{
			//Arrange
			IAgencyFactory agencyFactory = new ContraryAgencyFactory();
			IAgency agency = agencyFactory.CreateAgency();

			//Act
			var result = agency.IsMatch(_agencyProperty, _databaseProperty);

			//Assert
			Assert.AreEqual(true, result);
		}

		[Test]
		public void ContraryRealEstateMatchingRules_PropertyNameReversedAndDontMatchesDB_MatchMethodReturnsFalse()
		{
			//Arrange
			IAgencyFactory agencyFactory = new ContraryAgencyFactory();
			IAgency agency = agencyFactory.CreateAgency();
			_agencyProperty.Name = "some new value";

			//Act
			var result = agency.IsMatch(_agencyProperty, _databaseProperty);

			//Assert
			Assert.AreEqual(false, result);
		}

		[Test]
		public void ContraryRealEstateMatchingRules_PropertyNameIsNull_MatchMethodReturnsFalse()
		{
			//Arrange
			IAgencyFactory agencyFactory = new ContraryAgencyFactory();
			IAgency agency = agencyFactory.CreateAgency();
			_agencyProperty.Name = null;

			//Act
			var result = agency.IsMatch(_agencyProperty, _databaseProperty);

			//Assert
			Assert.AreEqual(false, result);
		}
	}
}