using System.ComponentModel.DataAnnotations.Schema;

namespace BrasserieTest.Models
{
    public class ClientOrder
    {
        public Guid beerId { get; set; }

        public int quantity { get; set; }
    }
}
