using System.ComponentModel.DataAnnotations.Schema;

namespace BrasserieTest.Models.Entities
{
    public class StockWholeSaler
    {
        public Guid Id { get; set; }

        [ForeignKey("Beer")]
        public Guid beerId { get; set; }

        [ForeignKey("Wholesaler")]
        public Guid wholesalerId { get; set; }
        public required decimal StockLeft { get; set; }
    }
}
