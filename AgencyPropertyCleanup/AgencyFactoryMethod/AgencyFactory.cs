using System;
using AgencyPropertyCleanup.AgencyFactoryMethod.Interfaces;

namespace AgencyPropertyCleanup.AgencyFactoryMethod
{
	public class AgencyFactory : IAgencyFactory
	{
		public IAgency CreateAgency(string agency)
		{
			switch (agency)
			{
				case "Contrary":
					return new ContraryAgency();
				case "Location":
					return new LocationAgency();
				case "Only The Best":
					return new OnlyTheBestAgency();
				default:
					throw new Exception("Agency not recognised");
			}
		}
	}
}
