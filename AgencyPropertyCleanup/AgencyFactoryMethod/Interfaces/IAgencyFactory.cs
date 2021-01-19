namespace AgencyPropertyCleanup.AgencyFactoryMethod.Interfaces
{
	public interface IAgencyFactory
	{
		IAgency CreateAgency(string agency);
	}
}
