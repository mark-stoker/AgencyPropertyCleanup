using AgencyPropertyCleanup.AgencyFactoryMethod.Interfaces;

namespace AgencyPropertyCleanup.AgencyFactoryMethod
{
	public class LocationAgencyFactory : IAgencyFactory
	{
		public IAgency CreateAgency()
		{
			return new LocationAgency();
		}
	}
}
