using System.ComponentModel.DataAnnotations.Schema;

namespace BrasserieTest.Models.Entities
{
    public class Beer
    {
        public Guid Id { get; set; }
        public required string name { get; set; }
        public required string alcohol_content { get; set; }
        public required decimal price { get; set; }

        [ForeignKey("Brewery")]
        public Guid breweryId { get; set; }

        public ICollection<WholesalerBeer> WholesalerBeers {  get; set; }
       
    }
}
