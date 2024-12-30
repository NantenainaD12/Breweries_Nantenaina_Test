using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BrasserieTest.Models.Entities
{
    public class WholesalerBeer
    {
        public Guid Id { get; set; }

        [ForeignKey("Beer")]
        public Guid IdBeer { get; set; }


        [ForeignKey("Wholesaler")]
        public Guid IdWholesaler { get; set; }

        public DateTime Date { get; set; }
    }
}
