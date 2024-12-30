using System.ComponentModel.DataAnnotations;

namespace BrasserieTest.Models.Entities
{
    public class WholesalerBeer
    {
        [Key]
        public Guid IdBeer { get; set; }
        public Beer Beer { get; set; }

        [Key]
        public Guid IdWholesaler { get; set; }
        public Wholesaler Wholesaler { get; set; }

        public DateTime Date { get; set; }
    }
}
