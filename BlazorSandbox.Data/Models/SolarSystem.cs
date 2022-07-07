namespace BlazorSandbox.Data.Models
{
    public partial class SolarSystem
    {
        public int Id { get; set; }

        public string Name { get; set; } = "";

        public int SectorId { get; set; }

        public Sector? Sector { get; set; }

        public List<Planet> Planets { get; set; }

        public SolarSystem()
        {
            Planets = new List<Planet>();
        }

        public SolarSystem(int id, string name, int sectorId) : this()
        {
            Id = id;
            Name = name;
            SectorId = sectorId;
        }
    }
}
