using AgencyPropertyCleanup.AgencyFactoryMethod;
using AgencyPropertyCleanup.AgencyFactoryMethod.Interfaces;
using AgencyPropertyCleanup.Interfaces;

namespace AgencyPropertyCleanupTests
{
	public class SecondLetterUpperCaseAgencyFa : IAgencyFactory
	{
		public IAgency CreateAgency()
		{
			return new ContraryAgency();
		}
	}
}