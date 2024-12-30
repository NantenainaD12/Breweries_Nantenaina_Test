using BrasserieTest.Models.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace BrasserieTest.Models
{
    public class AddBeerDto
    {
        public required string name { get; set; }
        public required string alcohol_content { get; set; }
        public required decimal price { get; set; }
        public Guid breweryId { get; set; }
    }
}
