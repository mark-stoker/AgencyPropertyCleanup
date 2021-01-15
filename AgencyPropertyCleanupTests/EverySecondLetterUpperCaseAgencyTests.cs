using AgencyPropertyCleanup;
using AgencyPropertyCleanup.AgencyFactoryMethod;
using AgencyPropertyCleanup.AgencyFactoryMethod.Interfaces;
using AgencyPropertyCleanup.Interfaces;
using NUnit.Framework;

namespace AgencyPropertyCleanupTests
{
	public class EverySecondLetterUpperCaseAgencyTests
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
				Address = "32 sIr JoHn YoUnG cReScEnT, sYdNeY nSw",
				AgencyCode = "OTBRE",
				Name = "sUpEr HiGh ApArTmEnTs, SyDnEy",
				Longitude = -33.87053923302913m,
				Latitude = 151.19248064675406m
			};
		}

		[Test]
		public void EverySecondLetterUpperCaseMatchingRules_PropertyNameAndAddressCassingDoesntMatchDB_MatchMethodReturnsTrue()
		{
			//Arrange
			IAgencyFactory agencyFactory = new SecondLetterUpperCaseAgencyFactory();
			IAgency agency = agencyFactory.CreateAgency();

			//Act
			var expectedResult = true;
			var result = agency.IsMatch(_agencyProperty, _databaseProperty);
			
			//Assert
			Assert.AreEqual(expectedResult, result);
		}
	}
}