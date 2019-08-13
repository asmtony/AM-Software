using Microsoft.AspNetCore.Mvc;
using Moq;
using StockTrackAspNetCore.Controllers;
using StockTrackAspNetCore.Models.DTO;
using StockTrackAspNetCore.Models.Services;
using StockTrackAspNetCore.Tests.Fakes;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace StockTrackAspNetCore.Tests.UnitTests
{
    public class ProductControllerTests
    {
        private IProductService _service;
        public ProductControllerTests()
        {
            _service = new ProductServiceFake();
        }

        [Fact]
        public async Task Index_ReturnsAViewResult_WithAListOfProducts()
        {
            // Arrange
            long companyId = 1;
            IProductService productServiceFake = new ProductServiceFake();
            var mockRepo = new Mock<IProductService>();
            mockRepo.Setup(repo => repo.Get(companyId))
                .Returns(productServiceFake.Get(companyId));
            //mockRepo.VerifyAll();

            ProductsController productsController = new ProductsController(mockRepo.Object);
            var result = await productsController.Index();

            var viewResult = Assert.IsType<ViewResult>(result);

            var model = Assert.IsAssignableFrom<List<ProductDto>>(viewResult.ViewData.Model);
            Assert.Equal(3, model.Count);
        }

        [Fact]
        public async Task Detail_ReturnsNotFoundResult_WhenInvalidProductIdOrWebCompanyId()
        {
            // Arrange
            long productId = 1000;
            long webCompanyId = 1000;
            IProductService productServiceFake = new ProductServiceFake();
            var mockRepo = new Mock<IProductService>();
            mockRepo.Setup(repo => repo.Get(productId))
                .Returns(productServiceFake.Get(productId));
            ProductsController productsController = new ProductsController(mockRepo.Object);
            var result = await productsController.Details(productId);
            var viewResult = Assert.IsType<NotFoundResult>(result);

        }
            /*
            [Fact]
            public async Task IndexPost_ReturnsBadRequestResult_WhenModelStateIsInvalid()
            {
                // Arrange
                long id = 1;
                IProductService productServiceFake = new ProductServiceFake();
                var mockRepo = new Mock<IProductService>();
                mockRepo.Setup(repo => repo.Get(id))
                    .Returns(productServiceFake.Get(id));
                var controller = new ProductsController(mockRepo.Object);
                controller.ModelState.AddModelError("SessionName", "Required");
                var newSession = new HomeController.NewSessionModel();

                // Act
                var result = await controller.Index(newSession);

                // Assert
                var badRequestResult = Assert.IsType<BadRequestObjectResult>(result);
                Assert.IsType<SerializableError>(badRequestResult.Value);
            }
    /*
            [Fact]
            public async Task IndexPost_ReturnsARedirectAndAddsSession_WhenModelStateIsValid()
            {
                // Arrange
                var mockRepo = new Mock<IProductService>();
                mockRepo.Setup(repo => repo.AddAsync(It.IsAny<BrainstormSession>()))
                    .Returns(Task.CompletedTask)
                    .Verifiable();
                var controller = new HomeController(mockRepo.Object);
                var newSession = new HomeController.NewSessionModel()
                {
                    SessionName = "Test Name"
                };

                // Act
                var result = await controller.Index(newSession);

                // Assert
                var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);
                Assert.Null(redirectToActionResult.ControllerName);
                Assert.Equal("Index", redirectToActionResult.ActionName);
                mockRepo.Verify();
            }

            [Fact]
            public void Get_WhenCalled_ReturnsOkResult()
            {
                // Act
                var okResult = _controller.Get(1);

                // Assert
                Assert.IsType<OkObjectResult>(okResult.Result);
            }

            [Fact]
            public void Get_WhenCalled_ReturnsAllItems()
            {
                // Act
                var okResult = _controller.Get().Result as OkObjectResult;

                // Assert
                var items = Assert.IsType<List<ShoppingItem>>(okResult.Value);
                Assert.Equal(3, items.Count);
            }
            [Fact]
            public void GetById_UnknownGuidPassed_ReturnsNotFoundResult()
            {
                // Act
                var notFoundResult = _controller.Get(Guid.NewGuid());

                // Assert
                Assert.IsType<NotFoundResult>(notFoundResult.Result);
            }

            [Fact]
            public void GetById_ExistingGuidPassed_ReturnsOkResult()
            {
                // Arrange
                var testGuid = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200");

                // Act
                var okResult = _controller.Get(testGuid);

                // Assert
                Assert.IsType<OkObjectResult>(okResult.Result);
            }

            [Fact]
            public void GetById_ExistingGuidPassed_ReturnsRightItem()
            {
                // Arrange
                var testGuid = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200");

                // Act
                var okResult = _controller.Get(testGuid).Result as OkObjectResult;

                // Assert
                Assert.IsType<ShoppingItem>(okResult.Value);
                Assert.Equal(testGuid, (okResult.Value as ShoppingItem).Id);
            }

            [Fact]
            public void Add_InvalidObjectPassed_ReturnsBadRequest()
            {
                // Arrange
                var nameMissingItem = new ShoppingItem()
                {
                    Manufacturer = "Guinness",
                    Price = 12.00M
                };
                _controller.ModelState.AddModelError("Name", "Required");

                // Act
                var badResponse = _controller.Post(nameMissingItem);

                // Assert
                Assert.IsType<BadRequestObjectResult>(badResponse);
            }

            [Fact]
            public void Add_ValidObjectPassed_ReturnsCreatedResponse()
            {
                // Arrange
                ShoppingItem testItem = new ShoppingItem()
                {
                    Name = "Guinness Original 6 Pack",
                    Manufacturer = "Guinness",
                    Price = 12.00M
                };

                // Act
                var createdResponse = _controller.Post(testItem);

                // Assert
                Assert.IsType<CreatedAtActionResult>(createdResponse);
            }

            [Fact]
            public void Add_ValidObjectPassed_ReturnedResponseHasCreatedItem()
            {
                // Arrange
                var testItem = new ShoppingItem()
                {
                    Name = "Guinness Original 6 Pack",
                    Manufacturer = "Guinness",
                    Price = 12.00M
                };

                // Act
                var createdResponse = _controller.Post(testItem) as CreatedAtActionResult;
                var item = createdResponse.Value as ShoppingItem;

                // Assert
                Assert.IsType<ShoppingItem>(item);
                Assert.Equal("Guinness Original 6 Pack", item.Name);
            }

            [Fact]
            public void Remove_NotExistingGuidPassed_ReturnsNotFoundResponse()
            {
                // Arrange
                var notExistingGuid = Guid.NewGuid();

                // Act
                var badResponse = _controller.Remove(notExistingGuid);

                // Assert
                Assert.IsType<NotFoundResult>(badResponse);
            }

            [Fact]
            public void Remove_ExistingGuidPassed_ReturnsOkResult()
            {
                // Arrange
                var existingGuid = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200");

                // Act
                var okResponse = _controller.Remove(existingGuid);

                // Assert
                Assert.IsType<OkResult>(okResponse);
            }

            [Fact]
            public void Remove_ExistingGuidPassed_RemovesOneItem()
            {
                // Arrange
                var existingGuid = new Guid("ab2bd817-98cd-4cf3-a80a-53ea0cd9c200");

                // Act
                var okResponse = _controller.Remove(existingGuid);

                // Assert
                Assert.Equal(2, _service.GetAllItems().Count());
            }
            */
        }
}
