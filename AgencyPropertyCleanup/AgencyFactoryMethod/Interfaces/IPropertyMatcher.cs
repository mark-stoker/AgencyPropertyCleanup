namespace AgencyPropertyCleanup.AgencyFactoryMethod.Interfaces
{
	public interface IPropertyMatcher
	{
		bool IsMatch(IProperty agencyProperty, IProperty databaseProperty);
	}
}
