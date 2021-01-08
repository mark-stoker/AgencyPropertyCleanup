using System;
using AgencyPropertyCleanup.AgencyFactoryMethod.Interfaces;

namespace AgencyPropertyCleanup.AgencyFactoryMethod
{
	public class ContraryAgency : IAgency
	{
		public string Name { get; set; }
		public string AgencyCode { get; set; }

		public ContraryAgency()
		{
			Name = "Contrary Real Estate";
			AgencyCode = "CRE";
		}

		public bool IsMatch(IProperty agencyProperty, IProperty databaseProperty)
		{
			if (agencyProperty.Name == null)
				return false;

			string[] wordArray = agencyProperty.Name.Split(' ');
			Array.Reverse(wordArray);
			string reversedSentence = string.Join(" ", wordArray);

			return String.Equals(reversedSentence, databaseProperty.Name);
		}
	}
}
