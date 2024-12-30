using BrasserieTest.Data;
using BrasserieTest.Models.Entities;
using BrasserieTest.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BrasserieTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public StockController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        [Route("{idWholeSaler:guid}")]
        public IActionResult GetStockByWholeSaler(Guid idWholeSaler)
        {
            // Query the Beers table to find all beers associated with the given brewery ID
            var stocks = dbContext.StockWholeSalers.Where(b => b.wholesalerId == idWholeSaler).ToList();

            return Ok(stocks);
        }

        [HttpPost("AddStock")]
        public IActionResult AddBeer(Guid idWholeSaler, Guid beerId,decimal stock)
        {
            var stockExists = dbContext.StockWholeSalers.Any(b => b.beerId == beerId && b.wholesalerId == idWholeSaler);
            if (stockExists)
            {
                return BadRequest($"The Beer  {beerId} alredy exist on wholeSaler {idWholeSaler}, Please Update the stock!!!.");
            }

            var stockEntity = new StockWholeSaler()
            {
                beerId = beerId,
                wholesalerId = idWholeSaler,
                StockLeft = stock,
            };

            dbContext.StockWholeSalers.Add(stockEntity);
            dbContext.SaveChanges();

            // Return the created beer
            return Ok(stockEntity);
        }

        [HttpPut]
        public IActionResult UpdateStock(Guid idWholeSaler, Guid beerId, decimal stock)
        {

            var stockExists = dbContext.StockWholeSalers.Where(b => b.beerId == beerId && b.wholesalerId == idWholeSaler).ToList();
            if (stockExists is null)
            {
                return NotFound($"The Beer  {beerId} does not exist on wholeSaler {idWholeSaler}, Please create a new stock!!!.");
            }

            stockExists[0].StockLeft = stock;

            dbContext.SaveChanges();
            return Ok(stockExists);
        }


        [HttpPost("ClientQuote")]
        public IActionResult Clientquote(List<ClientOrder> clientOrders, Guid idWholeSaler)
        {
            if (clientOrders.Count <= 0)
            {
                return BadRequest("Orders empty, please fill your order.");
            }

            var wholesaler = dbContext.Wholesalers.Find(idWholeSaler);
            if (wholesaler is null)
            {
                return BadRequest("Wholesaler not found.");
            }

            var validationResult = ValidateOrders(clientOrders, idWholeSaler);
            if (validationResult != null)
            {
                return validationResult;
            }

            var quoteSummary = CalculateQuote(clientOrders);

            return Ok(quoteSummary);
        }


        private IActionResult? ValidateOrders(List<ClientOrder> clientOrders, Guid idWholeSaler)
        {
            List<Guid> BeerIDs = new List<Guid>();

            foreach (var item in clientOrders)
            {
                var wholesalerBeer = dbContext.WholesalersBeers
                    .FirstOrDefault(wb => wb.IdBeer == item.beerId && wb.IdWholesaler == idWholeSaler);

                if (wholesalerBeer == null)
                {
                    return BadRequest($"Combination of BeerID {item.beerId} and WholesalerID {idWholeSaler} does not exist.");
                }

                if (BeerIDs.Contains(item.beerId))
                {
                    return BadRequest($"Duplicate BeerID {item.beerId} found in the order.");
                }

                var beer = dbContext.Beers.Find(item.beerId);
                if (beer == null)
                {
                    return BadRequest($"Beer with ID {item.beerId} not found.");
                }

                var stockWholeSaler = dbContext.StockWholeSalers
                    .FirstOrDefault(s => s.beerId == item.beerId && s.wholesalerId == idWholeSaler);

                if (stockWholeSaler == null)
                {
                    return BadRequest($"Stock information for BeerID {item.beerId} and WholesalerID {idWholeSaler} does not exist.");
                }

                if (item.quantity > stockWholeSaler.StockLeft)
                {
                    return BadRequest($"Not enough stock for BeerID {item.beerId}. Available: {stockWholeSaler.StockLeft}, Requested: {item.quantity}.");
                }

                BeerIDs.Add(item.beerId);
            }

            return null;
        }

        private object CalculateQuote(List<ClientOrder> clientOrders)
        {
            decimal totalAmount = 0;
            decimal AmountAfterDiscount = 0;
            int totalDrinks = 0;

            foreach (var item in clientOrders)
            {
                var beer = dbContext.Beers.Find(item.beerId);
                totalDrinks += item.quantity;
                totalAmount += beer.price * item.quantity;
            }

            decimal discount = 0;
            AmountAfterDiscount = totalAmount;
            if (totalDrinks > 20)
            {
                discount = AmountAfterDiscount * 0.20m;
            }
            else if (totalDrinks > 10)
            {
                discount = AmountAfterDiscount * 0.10m;
            }

            AmountAfterDiscount -= discount;

            var quoteSummary = new
            {
                TotalDrinks = totalDrinks,
                TotalAmount = totalAmount,
                AmountAfterDiscount = AmountAfterDiscount,
                Discount = discount
            };

            return quoteSummary;
        }



       

    }
}
