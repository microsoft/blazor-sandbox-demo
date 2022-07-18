namespace BlazorSandbox.Data.Models
{
	public partial class Sector
	{
        public int Id { get; set; }

        public string Name { get; set; } = "";

        public int TerritoryId { get; set; }

        public Territory? Territory { get; set; }

        public List<SolarSystem> Systems { get; set; }

        public Sector() 
        {
            Systems = new List<SolarSystem>();
        }

        public Sector(int id, string name, int territoryId) : this()
        {
            Id = id;
            Name = name;
            TerritoryId = territoryId;
        }
    }
}
