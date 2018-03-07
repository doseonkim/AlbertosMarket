using AlbertosMarket.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;

namespace AlbertosMarket.Tests.Controllers
{
    [TestClass]
    public class ManageControllerTest
    {
        [TestMethod]
        public void ChangePassword()
        {
            // Arrange
            ManageController controller = new ManageController();

            // Act
            ViewResult result = (ViewResult) controller.ChangePassword() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void AddPhoneNumber()
        {
            // Arrange
            ManageController controller = new ManageController();

            // Act
            ViewResult result = controller.AddPhoneNumber() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

    }


}
