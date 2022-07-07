namespace BlazorSandbox.Data.Models
{
	public partial class Planet
	{
		public int Id { get; set; }

		public string Name { get; set; } = "";

        public int SystemId { get; set; }

        public SolarSystem? System { get; set; }

		//public virtual List<Race> NativeRaces { get; set; }

		public Planet()
		{
			//NativeRaces = new List<Race>();
		}

		public Planet(int id, string name, int systemId)//, List<Race> nativeRaces)
		{
			Id = id;
			Name = name;
            SystemId = systemId;
			//NativeRaces = nativeRaces;
		}
	}
}
