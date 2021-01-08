using AgencyPropertyCleanup;
using AgencyPropertyCleanup.AgencyFactoryMethod;
using AgencyPropertyCleanup.AgencyFactoryMethod.Interfaces;
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
				Address = "32 Sir John Young Crescent Sydney NSW",
				AgencyCode = "OTBRE",
				Name = "Super High Apartments Sydney",
				Longitude = -33.87053923302913m,
				Latitude = 151.19248064675406m
			};
		}

		[Test]
		public void OnlyTheBestPropertyMatchingRules_PropertyNameAndAddressHavePunctuation_MatchMethodReturnsTrue()
		{
			//Arrange
			IAgencyFactory agencyFactory = new OnlyTheBestAgencyFactory();
			IAgency agency = agencyFactory.CreateAgency();

			//Act
			var result = agency.IsMatch(_agencyProperty, _databaseProperty);
			
			//Assert
			Assert.AreEqual(true, result);
		}

		[Test]
		public void OnlyTheBestPropertyMatchingRules_PropertyNameAndAddressHaveNoPunctuation_MatchMethodReturnsTrue()
		{
			//Arrange
			IAgencyFactory agencyFactory = new OnlyTheBestAgencyFactory();
			IAgency agency = agencyFactory.CreateAgency();

			_agencyProperty.Name = "Super High APARTMENTS Sydney";
			_agencyProperty.Address = "32 Sir John Young Crescent, Sydney, NSW.";

			_databaseProperty.Name = "Super High Apartments Sydney";
			_databaseProperty.Address = "32 Sir John Young Crescent Sydney NSW";

			//Act
			var result = agency.IsMatch(_agencyProperty, _databaseProperty);

			//Assert
			Assert.AreEqual(true, result);
		}

		[Test]
		public void OnlyTheBestPropertyMatchingRules_PropertyNameAndAddressAreNull_MatchMethodReturnsFalse()
		{
			//Arrange
			IAgencyFactory agencyFactory = new OnlyTheBestAgencyFactory();
			IAgency agency = agencyFactory.CreateAgency();

			_agencyProperty.Name = null;
			_agencyProperty.Address = null;

			_databaseProperty.Name = "Super High Apartments Sydney";
			_databaseProperty.Address = "32 Sir John Young Crescent Sydney NSW";

			//Act
			var result = agency.IsMatch(_agencyProperty, _databaseProperty);

			//Assert
			Assert.AreEqual(false, result);
		}

		[Test]
		public void OnlyTheBestPropertyMatchingRules_PropertyNameAndAdressAllUpperCase_MatchMethodReturnsTrue()
		{
			//Arrange
			IAgencyFactory agencyFactory = new OnlyTheBestAgencyFactory();
			IAgency agency = agencyFactory.CreateAgency();

			_agencyProperty.Name = "SUPER HIGH APARTMENTS SYDNEY";
			_agencyProperty.Address = "32 SIR JOHN YOUNG CRESCENT SYDNEY NSW";

			_databaseProperty.Name = "Super High Apartments Sydney";
			_databaseProperty.Address = "32 Sir John Young Crescent Sydney NSW";

			//Act
			var result = agency.IsMatch(_agencyProperty, _databaseProperty);

			//Assert
			Assert.AreEqual(true, result);
		}

		[Test]
		public void OnlyTheBestPropertyMatchingRules_PropertyNameAndAddressAllLowerCase_MatchMethodReturnsTrue()
		{
			//Arrange
			IAgencyFactory agencyFactory = new OnlyTheBestAgencyFactory();
			IAgency agency = agencyFactory.CreateAgency();

			_agencyProperty.Name = "super high apartments sydney";
			_agencyProperty.Address = "32 sir john young crescent sydney nsw";

			_databaseProperty.Name = "Super High Apartments Sydney";
			_databaseProperty.Address = "32 Sir John Young Crescent Sydney NSW";

			//Act
			var result = agency.IsMatch(_agencyProperty, _databaseProperty);

			//Assert
			Assert.AreEqual(true, result);
		}

		[Test]
		public void OnlyTheBestPropertyMatchingRules_PropertyNameAndAddressContainsRandomSpaces_MatchMethodReturnsTrue()
		{
			//Arrange
			IAgencyFactory agencyFactory = new OnlyTheBestAgencyFactory();
			IAgency agency = agencyFactory.CreateAgency();

			_agencyProperty.Name = "super   high     apartments       sydney";
			_agencyProperty.Address = "32   sir   john    young    crescent    sydney      nsw";

			_databaseProperty.Name = "Super High Apartments Sydney";
			_databaseProperty.Address = "32 Sir John Young Crescent Sydney NSW";

			//Act
			var result = agency.IsMatch(_agencyProperty, _databaseProperty);

			//Assert
			Assert.AreEqual(true, result);
		}

		//[Test]
		//public void OnlyTheBestPropertyMatchingRules_PropertyNameAndAddressContainsRandomWhiteSpace_MatchMethodReturnsTrue()
		//{
		//	//Arrange
		//	var agencyFactory = new OnlyTheBestAgencyFactory();
		//	var agency = agencyFactory.CreateAgency();

		//	_agencyProperty.Name = "Super High APARTMENTS Sydney";
		//	//sb.Append("\r\n\t");
		//	_agencyProperty.Address = "32 Sir John Young Crescent, Sydney, NSW.";

		//	_databaseProperty.Name = "Super High Apartments Sydney";
		//	_databaseProperty.Address = "32 Sir John Young Crescent Sydney NSW";

		//	//Act
		//	var result = agency.IsMatch(_agencyProperty, _databaseProperty);

		//	//Assert
		//	Assert.AreEqual(true, result);
		//}

		//TODO foreign language chars
	}
}