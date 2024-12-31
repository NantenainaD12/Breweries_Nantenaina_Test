using BrasserieTest.Data;
using BrasserieTest.Models.Entities;
using BrasserieTest.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BrasserieTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WholeSalerController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public WholeSalerController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult GetAllWholeSaler()
        {
            // Query the Beers table to find all beers associated with the given brewery ID
            var allWholesalers = dbContext.Wholesalers.ToList();

            return Ok(allWholesalers);
        }
        [HttpPost]
        public IActionResult AddWholeSaler(string wholeSalerName)
        {
            var newWholeSaler = new Wholesaler()
            {
                Name = wholeSalerName
            };

            dbContext.Wholesalers.Add(newWholeSaler);
            dbContext.SaveChanges();

            return Ok(newWholeSaler);
        }
    }
}
