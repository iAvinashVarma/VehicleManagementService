using NUnit.Framework;
using System.Web.Mvc;
using VehicleManagementSystemApi;
using VehicleManagementSystemApi.Controllers;

namespace VehicleManagementSystemApi.Tests.Controllers
{
    [TestFixture]
    public class HomeControllerTest
    {
        [Test]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Home Page", result.ViewBag.Title);
        }
    }
}
