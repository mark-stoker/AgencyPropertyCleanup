using AgencyPropertyCleanup.AgencyFactoryMethod.Interfaces;
using AgencyPropertyCleanup.Interfaces;

namespace AgencyPropertyCleanup.AgencyFactoryMethod
{
	public class SecondLetterUpperCaseAgencyFactory : IAgencyFactory
	{
		public IAgency CreateAgency()
		{
			return new SecondLetterUpperCaseAgency();
		}
	}
}