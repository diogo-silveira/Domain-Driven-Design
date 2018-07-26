using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Serko.Core.Domain.Entities;
using Serko.Core.Domain.Interfaces.ApplicationService;
using Serko.Core.Api.Controllers;
using Serko.Core.Api.Security;

namespace Serko.Core.Whs.Test
{
    [TestClass]
    public class EmployeeControllerUnitTests
    {
        private Mock<IEmployeeApplicationService> _employeeApplicationServiceMock;
        private Mock<BaseController> _baseControllerMock;
        private EmployeeController _employeeController;
        private const string RequestParamater = @"{ ""barcode"" : ""1234567890"", ""Password"" : ""1234567890""  }";
        private Task<Employee> _employeeTask;

        [TestInitialize]
        public void Initialise()
        {
            _employeeApplicationServiceMock = new Mock<IEmployeeApplicationService>();
            _baseControllerMock = new Mock<BaseController>();

            Runtime.SecurityKey = "Serko.Security.Key";
            Runtime.Audience = "Serko.Security.Bearer";
            Runtime.Issuer = "Serko.Security.Bearer";

            _employeeTask = Task.Factory.StartNew(() =>
            {
                var employee = new Employee
                {
                    EmployeeNumber = 123456,
                    FirstName = "John",
                    LastName = "Snow",
                    UserName = "johnsnow"
                };

                return employee;
            });
        }


        [TestMethod]
        public void Method_Authentication_When_ParameterRequestIsValidAndUserIsValid_Should_ReturnOk()
        {
            _employeeApplicationServiceMock.Setup(item => item.AuthenticationAsync(It.IsAny<object>())).Returns(_employeeTask);

            _employeeController = new EmployeeController(_employeeApplicationServiceMock.Object);

            var result = _employeeController.Authentication(RequestParamater);

            var okResult = result.Result as OkObjectResult;

            Assert.IsNotNull(okResult);
            Assert.AreEqual((int)HttpStatusCode.OK, okResult.StatusCode);
        }

        [TestMethod]
        public void Method_Authentication_When_ParameterRequestIsNull_Should_ReturnBadRequest()
        {
            _employeeApplicationServiceMock.Setup(item => item.AuthenticationAsync(It.IsAny<object>())).Returns(_employeeTask);

            _employeeController = new EmployeeController(_employeeApplicationServiceMock.Object);

            var result = _employeeController.Authentication(null);
            var badRequestResult = result.Result as BadRequestObjectResult;

            Assert.IsNotNull(badRequestResult);
            Assert.AreEqual((int)HttpStatusCode.BadRequest, badRequestResult.StatusCode);
        }
    }
}