using AgencyPropertyCleanup.AgencyFactoryMethod.Interfaces;
using AgencyPropertyCleanup.Interfaces;

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
