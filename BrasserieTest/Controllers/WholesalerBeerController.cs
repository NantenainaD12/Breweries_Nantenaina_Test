using BrasserieTest.Data;
using BrasserieTest.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace BrasserieTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WholesalerBeerController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public WholesalerBeerController(ApplicationDbContext context)
        {
            dbContext = context;
        }

        // POST: api/WholesalerBeer
        [HttpPost("AddWholesalerBeer")]
        public IActionResult AddWholesalerBeer(Guid idBeer, Guid idWholesaler, DateTime date)
        {
            // Check if the beer exists
            var beerExists = dbContext.Beers.Find(idBeer);
            if (beerExists is null)
            {
                return BadRequest($"Beer with ID {idBeer} does not exist.");
            }

            // Check if the wholesaler exists
            var wholesalerExists = dbContext.Wholesalers.Find(idWholesaler);
            if (wholesalerExists is null)
            {
                return BadRequest($"Wholesaler with ID {idWholesaler} does not exist.");
            }

            // Create the WholesalerBeer entity
            var wholesalerBeerEntity = new WholesalerBeer()
            {
                IdBeer = idBeer,
                IdWholesaler = idWholesaler,
                Date = date
            };

            // Add the new WholesalerBeer to the database
            dbContext.WholesalersBeers.Add(wholesalerBeerEntity);
            dbContext.SaveChanges();

            // Return the created WholesalerBeer
            return Ok(wholesalerBeerEntity);
        }
    }
}
