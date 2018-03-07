using AlbertosMarket.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;

namespace AlbertosMarket.Tests.Controllers
{
    [TestClass]
    public class AuthorControllerTest
    {
        [TestMethod]
        public void Create()
        {
            // Arrange
            AuthorController controller = new AuthorController();

            // Act
            ViewResult result = controller.Create() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

    }
}
