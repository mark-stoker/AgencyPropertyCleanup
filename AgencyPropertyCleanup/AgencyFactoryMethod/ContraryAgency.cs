using System;
using System.Linq;
using AgencyPropertyCleanup.AgencyFactoryMethod.Interfaces;
using AgencyPropertyCleanup.Interfaces;

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

			var reversedSentence = ReverseSentence(agencyProperty.Name);

			return String.Equals(RemoveWhitespace(reversedSentence), RemoveWhitespace(databaseProperty.Name));
		}

		private static string ReverseSentence(string name)
		{
			string[] wordArray = name.Split(' ');
			Array.Reverse(wordArray);
			string reversedSentence = string.Join(" ", wordArray);
			return reversedSentence;
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
