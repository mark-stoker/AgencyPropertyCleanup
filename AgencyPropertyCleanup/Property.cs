namespace AgencyPropertyCleanup
{
	public class Property : IProperty
	{
		public string Address { get; set; }
		public string AgencyCode { get; set; }
		public string Name { get; set; }
		public decimal Longitude { get; set; }
		public decimal Latitude { get; set; }
	}
}
