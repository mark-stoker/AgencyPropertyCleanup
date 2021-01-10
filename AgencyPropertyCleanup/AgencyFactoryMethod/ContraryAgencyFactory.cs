using AgencyPropertyCleanup.AgencyFactoryMethod.Interfaces;
using AgencyPropertyCleanup.Interfaces;

namespace AgencyPropertyCleanup.AgencyFactoryMethod
{
	public class ContraryAgencyFactory : IAgencyFactory
	{
		public IAgency CreateAgency()
		{
			return new ContraryAgency();
		}
	}
}
