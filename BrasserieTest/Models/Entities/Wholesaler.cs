namespace BrasserieTest.Models.Entities
{
    public class Wholesaler
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }

        public ICollection<WholesalerBeer> WholesalerBeers { get; set; }
    }
}
