using AgencyPropertyCleanup.AgencyFactoryMethod.Interfaces;

namespace AgencyPropertyCleanup.AgencyFactoryMethod
{
	public class OnlyTheBestAgencyFactory : IAgencyFactory
	{
		public IAgency CreateAgency()
		{
			return new OnlyTheBestAgency();
		}
	}
}
