using AgencyPropertyCleanup.AgencyFactoryMethod.Interfaces;

namespace AgencyPropertyCleanup.Interfaces
{
	public interface IAgencyFactory
	{
		IAgency CreateAgency();
	}
}
