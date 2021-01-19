using AgencyPropertyCleanup;
using AgencyPropertyCleanup.AgencyFactoryMethod;
using AgencyPropertyCleanup.AgencyFactoryMethod.Interfaces;
using AgencyPropertyCleanup.Interfaces;
using NUnit.Framework;

namespace AgencyPropertyCleanupTests
{
	public class OnlyTheBestAgencyTests
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
				Name = "*Super*-High! APARTMENTS (Sydney)",
				Longitude = -33.87053923302913m,
				Latitude = 151.19248064675406m
			};

			_databaseProperty = new Property
			{
				Address = "32 Sir John Young Crescent, Sydney NSW",
				AgencyCode = "OTBRE",
				Name = "Super High Apartments, Sydney",
				Longitude = -33.87053923302913m,
				Latitude = 151.19248064675406m
			};
		}

		[Test]
		public void OnlyTheBestPropertyMatchingRules_PropertyNameAndAddressHavePunctuation_MatchMethodReturnsTrue()
		{
			//Arrange
			IAgencyFactory agencyFactory = new AgencyFactory();
			IAgency agency = agencyFactory.CreateAgency("Only The Best");

			//Act
			var expectedResult = true;
			var result = agency.IsMatch(_agencyProperty, _databaseProperty);
			
			//Assert
			Assert.AreEqual(expectedResult, result);
		}

		[Test]
		public void OnlyTheBestPropertyMatchingRules_PropertyNameAndAddressHaveNoPunctuation_MatchMethodReturnsTrue()
		{
			//Arrange
			IAgencyFactory agencyFactory = new AgencyFactory();
			IAgency agency = agencyFactory.CreateAgency("Only The Best");

			_agencyProperty.Name = "Super High APARTMENTS Sydney";
			_agencyProperty.Address = "32 Sir John Young Crescent, Sydney, NSW.";

			//Act
			var expectedResult = true;
			var result = agency.IsMatch(_agencyProperty, _databaseProperty);

			//Assert
			Assert.AreEqual(expectedResult, result);
		}

		[Test]
		public void OnlyTheBestPropertyMatchingRules_PropertyNameAndAddressAreNull_MatchMethodReturnsFalse()
		{
			//Arrange
			IAgencyFactory agencyFactory = new AgencyFactory();
			IAgency agency = agencyFactory.CreateAgency("Only The Best");

			_agencyProperty.Name = null;
			_agencyProperty.Address = null;

			//Act
			var expectedResult = false;
			var result = agency.IsMatch(_agencyProperty, _databaseProperty);

			//Assert
			Assert.AreEqual(expectedResult, result);
		}

		[Test]
		public void OnlyTheBestPropertyMatchingRules_PropertyNameAndAddressAreEmptyStrings_MatchMethodReturnsFalse()
		{
			//Arrange
			IAgencyFactory agencyFactory = new AgencyFactory();
			IAgency agency = agencyFactory.CreateAgency("Only The Best");

			_agencyProperty.Name = string.Empty;
			_agencyProperty.Address = string.Empty;

			//Act
			var expectedResult = false;
			var result = agency.IsMatch(_agencyProperty, _databaseProperty);

			//Assert
			Assert.AreEqual(expectedResult, result);
		}

		[Test]
		public void OnlyTheBestPropertyMatchingRules_PropertyNameAndAdressAllUpperCase_MatchMethodReturnsTrue()
		{
			//Arrange
			IAgencyFactory agencyFactory = new AgencyFactory();
			IAgency agency = agencyFactory.CreateAgency("Only The Best");

			_agencyProperty.Name = "SUPER HIGH APARTMENTS SYDNEY";
			_agencyProperty.Address = "32 SIR JOHN YOUNG CRESCENT SYDNEY NSW";

			//Act
			var expectedResult = true;
			var result = agency.IsMatch(_agencyProperty, _databaseProperty);

			//Assert
			Assert.AreEqual(expectedResult, result);
		}

		[Test]
		public void OnlyTheBestPropertyMatchingRules_PropertyNameAndAddressAllLowerCase_MatchMethodReturnsTrue()
		{
			//Arrange
			IAgencyFactory agencyFactory = new AgencyFactory();
			IAgency agency = agencyFactory.CreateAgency("Only The Best");

			_agencyProperty.Name = "super high apartments sydney";
			_agencyProperty.Address = "32 sir john young crescent sydney nsw";

			//Act
			var expectedResult = true;
			var result = agency.IsMatch(_agencyProperty, _databaseProperty);

			//Assert
			Assert.AreEqual(expectedResult, result);
		}

		[Test]
		public void OnlyTheBestPropertyMatchingRules_PropertyNameAndAddressContainsRandomSpaces_MatchMethodReturnsTrue()
		{
			//Arrange
			IAgencyFactory agencyFactory = new AgencyFactory();
			IAgency agency = agencyFactory.CreateAgency("Only The Best");

			_agencyProperty.Name = "super     high     apartments         sydney";
			_agencyProperty.Address = "32         sir   john      young    crescent             sydney            nsw";

			//Act
			var expectedResult = true;
			var result = agency.IsMatch(_agencyProperty, _databaseProperty);

			//Assert
			Assert.AreEqual(expectedResult, result);
		}

		[Test]
		public void OnlyTheBestPropertyMatchingRules_PropertyNameAndAddressContainsASCIIAcentedCharacters_MatchMethodReturnsTrue()
		{
			//Arrange
			IAgencyFactory agencyFactory = new AgencyFactory();
			IAgency agency = agencyFactory.CreateAgency("Only The Best");

			_agencyProperty.Name = "*Sùpér*-High! ÃPARTMENTS (Sydnéy)";
			_agencyProperty.Address = "32 Sir John-Young Créscént, Sydnéy, NSW.";

			_databaseProperty.Name = "Sùpér High Ãpartments Sydnéy";
			_databaseProperty.Address = "32 Sir John Young Créscént Sydnéy NSW";

			//Act
			var expectedResult = true;
			var result = agency.IsMatch(_agencyProperty, _databaseProperty);

			//Assert
			Assert.AreEqual(expectedResult, result);
		}

		[Test]
		public void OnlyTheBestPropertyMatchingRules_PropertyNameAndAddressContainsRandomWhiteSpace_MatchMethodReturnsTrue()
		{
			//Arrange
			IAgencyFactory agencyFactory = new AgencyFactory();
			IAgency agency = agencyFactory.CreateAgency("Only The Best");

			_agencyProperty.Name = "Super\n\r\t  High\n\r\t APARTMENTS\n\r\t  Sydney\n\r\t ";
			_agencyProperty.Address = "32\n\r\t  Sir\n\r\t  John\n\r\t  Young\n\r\t  Crescent\n\r\t , Sydney\n\r\t , NSW.\n\r\t ";

			//Act
			var result = agency.IsMatch(_agencyProperty, _databaseProperty);

			//Assert
			Assert.AreEqual(true, result);
		}
	}
}