using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorSandbox.Data.Models
{
    public partial class Character
	{
        public int Id { get; set; }

		public string FirstName { get; set; } = "";

		public string LastName { get; set; } = "";

		[NotMapped]
        public string Name {  get { return $"{FirstName} {LastName}"; } }

		public Alignment Alignment { get; set; }

		public int HomePlanetId { get; set; }

		public Planet? HomePlanet { get; set; }

        public int RaceId { get; set; }

        public Race? Race { get; set; }

		public Character() { }

        public Character(int id, string firstName, string lastName, int homePlanetId, int raceId)
		{
			Id = id;
			FirstName = firstName;
			LastName = lastName;
            HomePlanetId = homePlanetId;
            RaceId = raceId;
		}
	}
}
