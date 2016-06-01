using Autofac.Extras.Moq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
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
        public void GetVehiclesShouldReturnVehicles()
        {
            using (var mock = AutoMock.GetLoose())
            {

                // Arrange - configure the mock
                var mockVehicleRepository = mock.Mock<IVehicleRepository>().Setup(x => x.GetAll()).Returns(new List<Vehicle>
                          {
                                             new Vehicle { Id = 1,
                                                            Make =  "Honda",
                                                            Model = "Civic",
                                                            Year =  2000
                                            },

                                              new Vehicle { Id = 1,
                                                            Make =  "Ford",
                                                            Model = "Focus",
                                                            Year =  2001 }
                          });


                var controller = mock.Create<VehiclesController>();

                //Act
                var Vehicles = controller.GetVehicles();

                // Assert
                Assert.IsNotNull(Vehicles);

                Assert.IsTrue(Vehicles.Count == 2);
            }
        }


        [TestMethod]
        public void GetVehiclesShouldReturnNotFound()
        {

            using (var mock = AutoMock.GetLoose())
            {

                // Arrange - configure the mock
                var mockVehicleRepository = mock.Mock<IVehicleRepository>().Setup(x => x.GetAll()).Returns(new List<Vehicle> { });

                var controller = mock.Create<VehiclesController>();

                //Act
                var Vehicles = controller.GetVehicles();

                // Assert
                Assert.IsNotNull(Vehicles);

                Assert.IsFalse(Vehicles.Count == 2);
            }
        }



        [TestMethod]
        public void GetVehicleShouldReturnVehicle()
        {
            using (var mock = AutoMock.GetLoose())
            {

                // Arrange - configure the mock
                var mockVehicleRepository = mock.Mock<IVehicleRepository>().Setup(x => x.Get(1)).Returns(new Vehicle
                {
                    Id = 1,
                    Year = 2000,
                    Make = "Subaru",
                    Model = "Forrester"
                });

                var controller = mock.Create<VehiclesController>();

                // Act
                var httpResponse = controller.GetVehicle(1);

                // Assert
                Assert.IsNotNull(httpResponse);

                OkNegotiatedContentResult<Vehicle> okHttpResponse = (OkNegotiatedContentResult<Vehicle>)httpResponse;
                Assert.IsNotNull(okHttpResponse);
                Assert.IsNotNull(okHttpResponse.Content);

                var domainResponse = okHttpResponse.Content;

                Assert.AreEqual(domainResponse.Id, 1);
            }
        }


        [TestMethod]
        public void GetVehicleShouldReturnNotFound()
        {
            using (var mock = AutoMock.GetLoose())
            {

                // Arrange - configure the mock
                var mockVehicleRepository = mock.Mock<IVehicleRepository>().Setup(x => x.Get(1)).Returns(new Vehicle
                {
                    Id = 1,
                    Year = 2000,
                    Make = "Subaru",
                    Model = "Forrester"
                });

                var controller = mock.Create<VehiclesController>();

                // Act
                var httpResponse = controller.GetVehicle(2);

                // Assert - assert on the mock
                Assert.IsNotNull(httpResponse);
                Assert.IsInstanceOfType(httpResponse, typeof(NotFoundResult));
            }
        }


        [TestMethod]
        public void PutVehicleReturnStatusCode()
        {

            using (var mock = AutoMock.GetLoose())
            {
                // Arrange
                var mockVehicleRepository = mock.Mock<IVehicleRepository>().Setup(x => x.Get(10))
                                .Returns(new Vehicle
                                {
                                    Id = 1,
                                    Year = 2000,
                                    Make = "Subaru",
                                    Model = "Forrester"
                                });

                var controller = mock.Create<VehiclesController>();

                // Act
                IHttpActionResult actionResult = controller.PutVehicle(new Vehicle { Id = 10, Model = "Chevy", Make = "Impala", Year = 2004 });
                var contentResult = actionResult as StatusCodeResult;

                // Assert

                Assert.IsNotNull(contentResult);
                Assert.IsTrue(contentResult.StatusCode == HttpStatusCode.NoContent);

            }
        }
    }

}
