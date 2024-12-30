using BrasserieTest.Data;
using BrasserieTest.Models;
using BrasserieTest.Models.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BrasserieTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrewerysController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public BrewerysController(ApplicationDbContext dbContext) 
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult GetAllBrewerys()
        {
            var allBrewerys = dbContext.Brewerys.ToList();

            return Ok(allBrewerys);

        }
        [HttpPost]
        public IActionResult AddBrewery(AddBreweryDto addBreweryDto)
        {
            var breweryEntity = new Brewery()
            {
                BreweryName = addBreweryDto.BreweryName
            };

            dbContext.Brewerys.Add(breweryEntity);
            dbContext.SaveChanges();

            return Ok(breweryEntity);
        }

        //[HttpGet]
        //[Route("{idBrewery:guid}")]
        //public IActionResult GetBreweryById(Guid idBrewery)
        //{
        //    var brewery = dbContext.Brewerys.Find(idBrewery);
        //    if (brewery is null)
        //    {
        //        return NotFound("empty result");
        //    }
        //    return Ok(brewery);
        //}

        [HttpPut]
        [Route("{idBrewery:guid}")]
        public IActionResult UpdateBrewery(Guid idBrewery, AddBreweryDto addBreweryDto)
        {
            var brewery = dbContext.Brewerys.Find(idBrewery);
            if (brewery is null)
            {
                return NotFound();
            }

            brewery.BreweryName = addBreweryDto.BreweryName;

            dbContext.SaveChanges();
            return Ok(brewery);
        }


        [HttpDelete]
        [Route("{idBrewery:guid}")]
        public IActionResult DeleteBrewery(Guid idBrewery)
        {
            var brewery = dbContext.Brewerys.Find(idBrewery);

            if(brewery is null)
            {
                return NotFound();
            }

            dbContext.Brewerys.Remove(brewery);
            dbContext.SaveChanges();

            return Ok();
        }
    }
}
