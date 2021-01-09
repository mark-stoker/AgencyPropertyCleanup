namespace AgencyPropertyCleanup.Interfaces
{
	public interface IProperty
	{
		string Address { get; set; }
		string AgencyCode { get; set; }
		string Name { get; set; }
		decimal Longitude { get; set; }
		decimal Latitude { get; set; }
	}
}
