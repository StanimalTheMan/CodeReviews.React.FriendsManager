using FriendsManager.StanimalTheMan.Server.Controllers;
using FriendsManager.StanimalTheMan.Server.Models;
using FriendsManager.StanimalTheMan.Server.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace FriendsManager.StanimalTheMan.Server.Tests
{
    [TestClass]
    public class CategoryControllerTests
    {
        [TestMethod]
        public async Task GetCategories_Returns_OkResult()
        {
            // Arrange
            var mockCategoryService = new Mock<ICategoryService>();
            mockCategoryService.Setup(x => x.GetAllCategoriesAsync())
                                .ReturnsAsync(new List<Category>());

            var controller = new CategoryController(mockCategoryService.Object);

            // Act
            var result = await controller.GetCategories();

            // Assert
            Assert.IsInstanceOfType(result.Result, typeof(OkObjectResult));
        }

        [TestMethod]
        public async Task GetCategoryById_InvalidId_Returns_NotFound()
        {
            // Arrange
            int invalidId = 999;  // Assuming this ID is invalid and doesn't exist in the database

            // Mocking the category service
            var mockCategoryService = new Mock<ICategoryService>();
            mockCategoryService.Setup(x => x.GetCategoryByIdAsync(invalidId))
                               .ReturnsAsync((Category)null); // Return null for invalid ID

            var controller = new CategoryController(mockCategoryService.Object);

            // Act
            var result = await controller.GetCategoryById(invalidId);

            // Assert
            Assert.IsInstanceOfType(result.Result, typeof(NotFoundResult));
        }

        [TestMethod]
        public async Task UpdateCategory_MismatchId_Returns_BadRequest()
        {
            int categoryIdInPath = 123;
            int categoryIdInBody = 456;

            var controller = new CategoryController(null);

            var result = await controller.UpdateCategory(categoryIdInPath, new Category { CategoryID = categoryIdInBody });

            Assert.IsInstanceOfType(result, typeof(BadRequestObjectResult));
        }
    }
}