namespace BlazorSandbox.Data.Models
{
	public partial class Territory
	{
        public int Id { get; set; }

        public string Name { get; set; } = "";

        public List<Sector> Sectors { get; set; }

        public Territory() 
        {
            Sectors = new List<Sector>();
        }

        public Territory(int id, string name) : this()
        {
            Id = id;
            Name = name;
        }
    }
}
