
using Moq;
using System;
using System.Collections.Generic;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using BrasserieTest.Controllers;
using BrasserieTest.Data;
using BrasserieTest.Models;
using BrasserieTest.Models.Entities;

namespace BrasserieTest.Unit_Test
{

    public class StockControllerTests
    {
        [Fact]
        public void Clientquote_EmptyClientOrders_ReturnsBadRequest()
        {
            // Arrange
            var mockContext = new Mock<ApplicationDbContext>();
            var controller = new StockController(mockContext.Object);
            var clientOrders = new List<ClientOrder>();
            var idWholeSaler = Guid.NewGuid();

            // Act
            var result = controller.Clientquote(clientOrders, idWholeSaler);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Orders empty, please fill your order.", badRequestResult.Value);
        }

        [Fact]
        public void Clientquote_WholesalerNotFound_ReturnsBadRequest()
        {
            // Arrange
            var mockContext = new Mock<ApplicationDbContext>();
            mockContext.Setup(c => c.Wholesalers.Find(It.IsAny<Guid>())).Returns((Wholesaler)null);
            var controller = new StockController(mockContext.Object);
            var clientOrders = new List<ClientOrder> { new ClientOrder { beerId = Guid.NewGuid(), quantity = 1 } };
            var idWholeSaler = Guid.NewGuid();

            // Act
            var result = controller.Clientquote(clientOrders, idWholeSaler);

            // Assert
            var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
            Assert.Equal("Wholesaler not found.", badRequestResult.Value);
        }

        [Fact]
        public void Clientquote_ValidOrders_ReturnsOk()
        {
            // Arrange
            var mockContext = new Mock<ApplicationDbContext>();
            var wholesaler = new Models.Entities.Wholesaler { Id = Guid.NewGuid(),Name="test" };
            mockContext.Setup(c => c.Wholesalers.Find(It.IsAny<Guid>())).Returns(wholesaler);
            mockContext.Setup(c => c.WholesalersBeers
                .FirstOrDefault(It.IsAny<Func<WholesalerBeer, bool>>()))
                .Returns(new WholesalerBeer());
            mockContext.Setup(c => c.Beers.Find(It.IsAny<Guid>())).Returns(new Beer { price = 10,name="test Beer",alcohol_content="5%" });
            mockContext.Setup(c => c.StockWholeSalers
                .FirstOrDefault(It.IsAny<Func<StockWholeSaler, bool>>()))
                .Returns(new StockWholeSaler { StockLeft = 10 });

            var controller = new StockController(mockContext.Object);
            var clientOrders = new List<ClientOrder> { new ClientOrder { beerId = Guid.NewGuid(), quantity = 1 } };
            var idWholeSaler = Guid.NewGuid();

            // Act
            var result = controller.Clientquote(clientOrders, idWholeSaler);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            Assert.NotNull(okResult.Value);
        }
    }

}