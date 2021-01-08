namespace AgencyPropertyCleanup.AgencyFactoryMethod.Interfaces
{
	public interface IAgency : IPropertyMatcher
	{
		string Name { get; set; }
		string AgencyCode { get; set; }
	}
}
