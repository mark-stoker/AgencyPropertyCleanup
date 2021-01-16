using AgencyPropertyCleanup.Interfaces;

namespace AgencyPropertyCleanup.AgencyFactoryMethod.Interfaces
{
	public interface IPropertyMatcher
	{
		bool IsMatch(Property agencyProperty, Property databaseProperty);
	}
}
