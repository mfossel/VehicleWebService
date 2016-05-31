using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
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
        Mock<IVehicleRepository> _mockVehicleRepository;

        VehiclesController controller;

        [TestInitialize]
        public void Initialize()
        {

            _mockVehicleRepository = new Mock<IVehicleRepository>();

            controller = new VehiclesController(_mockVehicleRepository.Object);

        }

        [TestMethod]
        public void GetVehiclesShouldReturnVehicles()
        {
            //Arrange
            _mockVehicleRepository.Setup(m => m.GetAll())
                     .Returns(new List<Vehicle>
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

            // Act
            var Vehicles = controller.GetVehicles();

            // Assert
            Assert.IsNotNull(Vehicles);

            Assert.IsTrue(Vehicles.Count == 2);
        }

        [TestMethod]
        public void GetVehiclesShouldReturnNotFound()
        {
            // Arrange
            _mockVehicleRepository.Setup(m => m.GetAll())
                                          .Returns(new List<Vehicle>
                                          { });

            // Act
            var httpResponse = controller.GetVehicles();

            // Assert
            Assert.IsNotNull(httpResponse);
            Assert.IsTrue(httpResponse.Count == 0);

        }

        [TestMethod]
        public void GetVehicleShouldReturnVehicle()
        {
            //Arrange
            _mockVehicleRepository.Setup(m => m.Get(1))
                                  .Returns(new Vehicle
                                  {
                                      Id = 1,
                                      Year = 2000,
                                      Make = "Subaru",
                                      Model = "Forrester"
                                  });

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

        [TestMethod]
        public void GetVehicleShouldReturnNotFound()
        {
            // Arrange
            _mockVehicleRepository.Setup(m => m.Get(1))
                                   .Returns(new Vehicle
                                   {
                                       Id = 1,
                                       Year = 2000,
                                       Make = "Subaru",
                                       Model = "Forrester"
                                   });

            // Act
            var httpResponse = controller.GetVehicle(2);

            // Assert
            Assert.IsNotNull(httpResponse);
            Assert.IsInstanceOfType(httpResponse, typeof(NotFoundResult));
        }

        [TestMethod]
        public void PutVehicleReturnStatusCode()
        {
            // Arrange
            _mockVehicleRepository.Setup(m => m.Get(10))
                                .Returns(new Vehicle
                                {
                                    Id = 1,
                                    Year = 2000,
                                    Make = "Subaru",
                                    Model = "Forrester"
                                });


            // Act
            IHttpActionResult actionResult = controller.PutVehicle(new Vehicle { Id = 10, Model = "Chevy", Make = "Impala", Year =2004 });
            var contentResult = actionResult as StatusCodeResult;

            // Assert
            _mockVehicleRepository.Verify(tr => tr.Update(It.IsAny<Vehicle>()), Times.Once);

            Assert.IsNotNull(contentResult);
            Assert.IsTrue(contentResult.StatusCode == HttpStatusCode.NoContent);
        }

    }

}
