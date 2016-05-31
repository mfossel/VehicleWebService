using Autofac.Extras.Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Web.Http.Results;
using VehicleWebService.API.Controllers;
using VehicleWebService.API.Data;
using VehicleWebService.CORE;

namespace VehicleWebService.API.Tests.Controllers
{
    [TestClass]
    public class VehiclesControllerTests
    {
        [TestMethod]
        public void GetVehicleShouldReturnVehicle()
        {
            // Arrange

            //var _mockVehicleRepository = new Mock<IVehicleRepository>();
            //_mockVehicleRepository.Setup(m => m.Get(1))
            //                       .Returns(new Vehicle
            //                       {
            //                           Id = 1,
            //                           Year = 2000,
            //                           Make = "Subaru",
            //                           Model = "Forrester"
            //                       });



            //var controller = new VehiclesController(_mockVehicleRepository.Object);

            //// Act
            //var httpResponse = controller.GetVehicle(1);

            //// Assert
            //Assert.IsNotNull(httpResponse);

            //OkNegotiatedContentResult<Vehicle> okHttpResponse = (OkNegotiatedContentResult<Vehicle>)httpResponse;
            //Assert.IsNotNull(okHttpResponse);
            //Assert.IsNotNull(okHttpResponse.Content);

            //var domainVehicle = okHttpResponse.Content;

            //Assert.AreEqual(domainVehicle.Id, 1);

        }

        //    [TestMethod]
        //    public void GetVehicleShouldReturnNotFound()
        //    {
        //        // Arrange
        //        var _mockVehicleRepository = new Mock<IVehicleRepository>();
        //        _mockVehicleRepository.Setup(m => m.Get(1))
        //                               .Returns(new Vehicle
        //                               {
        //                                    Id = 1,
        //                                    Year = 2000,
        //                                    Make = "Subaru",
        //                                    Model = "Forrester"
        //                                });


        //        var controller = new VehiclesController(_mockVehicleRepository.Object);

        //        // Act
        //        var httpResponse = controller.GetVehicle(2);

        //        // Assert
        //        Assert.IsNotNull(httpResponse);
        //        Assert.IsInstanceOfType(httpResponse, typeof(NotFoundResult));
        //    }
        //}

        //[TestMethod]
        //public void Test()
        //{
        //    using (var mock = AutoMock.GetLoose())
        //    {
        //        // Arrange - configure the mock
        //        mock.Mock<IVehicleRepository>().Setup(x => x.Get(1)).Returns(new Vehicle
        //        {
        //            Id = 1,
        //            Year = 2000,
        //            Make = "Subaru",
        //            Model = "Forrester"
        //        });

        //        var controller = mock.Create<VehiclesController>();

        //        // Act
        //        var httpResponse = controller.GetVehicle(2);

        //        // Assert - assert on the mock
        //        Assert.IsNotNull(httpResponse);
        //        Assert.IsInstanceOfType(httpResponse, typeof(NotFoundResult));
        //    }
        //}

    }

}
