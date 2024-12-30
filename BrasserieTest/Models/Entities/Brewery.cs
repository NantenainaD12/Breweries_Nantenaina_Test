namespace BrasserieTest.Models.Entities
{
    public class Brewery
    {
        public Guid Id { get; set; }
        public required string BreweryName { get; set; }

        public ICollection<Beer> beers { get; set; }
    }

}
