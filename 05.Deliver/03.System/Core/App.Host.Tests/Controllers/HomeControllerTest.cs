using App.Host.Presentation.Controllers;

namespace App.Core.Application.Tests.Controllers
{
    using System.Web.Mvc;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Index()
        {
            // Arrange
            var controller = new AboutController(null);

            // Act
            var result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        //[TestMethod]
        //public void About()
        //{
        //    // Arrange
        //    var controller = new AboutController(null);

        //    // Act
        //    var result = controller.About() as ViewResult;

        //    // Assert
        //    Assert.AreEqual("Your application description page.", result.ViewBag.Message);
        //}
    }
}