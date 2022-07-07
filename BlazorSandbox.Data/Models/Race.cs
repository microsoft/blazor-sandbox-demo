namespace BlazorSandbox.Data.Models
{
	public partial class Race
	{
		public int Id { get; set; }

		public string Name { get; set; } = "";

        public string Description { get; set; } = "";

        public Race() { }

        public Race(int id, string name, string description)
		{
			Id = id;
			Name = name;
			Description = description;
		}
	}
}
