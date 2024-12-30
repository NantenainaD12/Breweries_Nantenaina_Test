using BrasserieTest.Data;
using BrasserieTest.Models.Entities;
using BrasserieTest.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BrasserieTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BeerController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public BeerController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        [Route("{idBrewery:guid}")]
        public IActionResult GetAllBeerByBrewery(Guid idBrewery)
        {
            // Query the Beers table to find all beers associated with the given brewery ID
            var allBeer = dbContext.Beers.Where(b => b.breweryId == idBrewery).ToList();
            
            return Ok(allBeer);
        }

        [HttpPost("AddBeer")]
        public IActionResult AddBeer(AddBeerDto addBeerDto)
        {
            // Check if the breweryId exists in the Brewery table
            var breweryExists = dbContext.Brewerys.Any(b => b.Id == addBeerDto.breweryId);
            if (!breweryExists)
            {
                return BadRequest($"Brewery with ID {addBeerDto.breweryId} does not exist.");
            }

            // Create the beer entity
            var beerEntity = new Beer()
            {
                name = addBeerDto.name,
                alcohol_content = addBeerDto.alcohol_content,
                price = addBeerDto.price,
                breweryId = addBeerDto.breweryId,
            };

            // Add the new beer to the database
            dbContext.Beers.Add(beerEntity);
            dbContext.SaveChanges();

            // Return the created beer
            return Ok(beerEntity);
        }

        [HttpDelete("{idBeer:guid}")]
        public IActionResult DeleteBeer(Guid idBeer, [FromQuery] Guid breweryId)
        {
            // Check if the beer exists and has the specified breweryId
            var beer = dbContext.Beers.FirstOrDefault(b => b.Id == idBeer && b.breweryId == breweryId);

            if (beer is null)
            {
                return NotFound("The beer is not defined or does not belong to the specified brewery.");
            }

            dbContext.Beers.Remove(beer);
            dbContext.SaveChanges();

            return Ok("Beer deleted successfully.");
        }
    }

}
