using System;
using System.Linq;
using AgencyPropertyCleanup.AgencyFactoryMethod.Interfaces;
using AgencyPropertyCleanup.Interfaces;

namespace AgencyPropertyCleanup.AgencyFactoryMethod
{
	public class OnlyTheBestAgency : IAgency, IPropertyMatcher
	{
		public string Name { get; set; }
		public string AgencyCode { get; set; }

		public OnlyTheBestAgency()
		{
			Name = "Only The Best Real Estate!";
			AgencyCode = "OTBRE";
		}

		public bool IsMatch(IProperty agencyProperty, IProperty databaseProperty)
		{
			var agencySourceProperty = RemovePunctuation(agencyProperty.Name + agencyProperty.Address);
			var databaseTargetProperty = RemovePunctuation(databaseProperty.Name + databaseProperty.Address);

			return String.Equals(RemoveWhitespace(agencySourceProperty), RemoveWhitespace(databaseTargetProperty));
		}

		private string RemovePunctuation(string agencyString)
		{
			return new string(agencyString.Where(c => !char.IsPunctuation(c)).ToArray());
		}

		private string RemoveWhitespace(string input)
		{
			return new string(input.ToCharArray()
				.Where(c => !Char.IsWhiteSpace(c))
				.ToArray())
				.ToLower();
		}
	}
}
