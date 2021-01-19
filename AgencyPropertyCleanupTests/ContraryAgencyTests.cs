using AgencyPropertyCleanup;
using AgencyPropertyCleanup.AgencyFactoryMethod;
using AgencyPropertyCleanup.AgencyFactoryMethod.Interfaces;
using AgencyPropertyCleanup.Interfaces;
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
			IAgencyFactory agencyFactory = new AgencyFactory();
			IAgency agency = agencyFactory.CreateAgency("Contrary");

			//Act
			var expectedResult = true;
			var result = agency.IsMatch(_agencyProperty, _databaseProperty);

			//Assert
			Assert.AreEqual(expectedResult, result);
		}

		[Test]
		public void ContraryRealEstateMatchingRules_PropertyNameWithExtraSpacesReversedAndMatchesDB_MatchMethodReturnsTrue()
		{
			//Arrange
			IAgencyFactory agencyFactory = new AgencyFactory();
			IAgency agency = agencyFactory.CreateAgency("Contrary");
			_agencyProperty.Name = "Apartments Summit    The";

			//Act
			var expectedResult = true;
			var result = agency.IsMatch(_agencyProperty, _databaseProperty);

			//Assert
			Assert.AreEqual(expectedResult, result);
		}

		[Test]
		public void ContraryRealEstateMatchingRules_PropertyNameWithMixexCaseReversedAndMatchesDB_MatchMethodReturnsTrue()
		{
			//Arrange
			IAgencyFactory agencyFactory = new AgencyFactory();
			IAgency agency = agencyFactory.CreateAgency("Contrary");
			_agencyProperty.Name = "ApArTmEnTs SuMmIt ThE";

			//Act
			var expectedResult = true;
			var result = agency.IsMatch(_agencyProperty, _databaseProperty);

			//Assert
			Assert.AreEqual(expectedResult, result);
		}

		[Test]
		public void ContraryRealEstateMatchingRules_PropertyNameWithASCIIAccentedCharactersReversedAndMatchesDB_MatchMethodReturnsTrue()
		{
			//Arrange
			IAgencyFactory agencyFactory = new AgencyFactory();
			IAgency agency = agencyFactory.CreateAgency("Contrary");
			_agencyProperty.Name = "Ápártménts Súmmít Thé";
			_databaseProperty.Name = "Thé Súmmít Ápártménts";

			//Act
			var expectedResult = true;
			var result = agency.IsMatch(_agencyProperty, _databaseProperty);

			//Assert
			Assert.AreEqual(expectedResult, result);
		}

		[Test]
		public void ContraryRealEstateMatchingRules_PropertyNameReversedAndDoesntMatchesDB_MatchMethodReturnsFalse()
		{
			//Arrange
			IAgencyFactory agencyFactory = new AgencyFactory();
			IAgency agency = agencyFactory.CreateAgency("Contrary");
			_agencyProperty.Name = "some new value";

			//Act
			var expectedResult = false;
			var result = agency.IsMatch(_agencyProperty, _databaseProperty);

			//Assert
			Assert.AreEqual(expectedResult, result);
		}

		[Test]
		public void ContraryRealEstateMatchingRules_PropertyNameIsNull_MatchMethodReturnsFalse()
		{
			//Arrange
			IAgencyFactory agencyFactory = new AgencyFactory();
			IAgency agency = agencyFactory.CreateAgency("Contrary");
			_agencyProperty.Name = null;

			//Act
			var expectedResult = false;
			var result = agency.IsMatch(_agencyProperty, _databaseProperty);

			//Assert
			Assert.AreEqual(expectedResult, result);
		}

		[Test]
		public void ContraryRealEstateMatchingRules_PropertyNameEmptyString_MatchMethodReturnsFalse()
		{
			//Arrange
			IAgencyFactory agencyFactory = new AgencyFactory();
			IAgency agency = agencyFactory.CreateAgency("Contrary");
			_agencyProperty.Name = string.Empty;

			//Act
			var expectedResult = false;
			var result = agency.IsMatch(_agencyProperty, _databaseProperty);

			//Assert
			Assert.AreEqual(expectedResult, result);
		}

		[Test]
		public void ContraryRealEstateMatchingRules_PropertyNameWithRandomWhiteSpaceCharactersReversedAndMatchesDB_MatchMethodReturnsTrue()
		{
			//Arrange
			IAgencyFactory agencyFactory = new AgencyFactory();
			IAgency agency = agencyFactory.CreateAgency("Contrary");
			_agencyProperty.Name = $"Apartments\n\r\t Summit\n\r\t The\n\r\t";
			
			//Act
			var expectedResult = true;
			var result = agency.IsMatch(_agencyProperty, _databaseProperty);

			//Assert
			Assert.AreEqual(expectedResult, result);
		}
	}
}