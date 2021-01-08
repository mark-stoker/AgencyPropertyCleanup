using System;
using AgencyPropertyCleanup.AgencyFactoryMethod.Interfaces;

namespace AgencyPropertyCleanup.AgencyFactoryMethod
{
	public class ContraryAgencyFactory : IAgencyFactory
	{
		public IAgency CreateAgency()
		{
			return new ContraryAgency();
		}
	}
}
