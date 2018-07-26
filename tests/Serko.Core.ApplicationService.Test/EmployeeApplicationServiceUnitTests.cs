using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json.Linq;
using Serko.Core.Domain.Entities;
using Serko.Core.Domain.Interfaces.ApplicationService;
using Serko.Core.Domain.Interfaces.Service;
using Serko.Core.Domain.Interfaces.UnitOfWork;
#pragma warning disable 4014

namespace Serko.Core.ApplicationService.Test
{
    [TestClass]
    public class EmployeeApplicationServiceUnitTests
    {
        private Mock<IEmployeeService> _employeeServiceMock;
        private Mock<IUnitOfWork> _unitOfWorkMock;
        private IEmployeeApplicationService _employeeApplicationService;
        private const string RequestBarcode = @"{ ""barcode"" : ""123456"", ""Password"" : ""1234567890""  }";
        private const string RequestUsername = @"{ ""Username"" : ""john"", ""Password"" : ""1234567890"" }";
        private Task<Employee> _employeeTask;

        [TestInitialize]
        public void Initialise()
        {
            _employeeServiceMock = new Mock<IEmployeeService>();
            _unitOfWorkMock = new Mock<IUnitOfWork>();

            _employeeTask = Task.Factory.StartNew(() =>
            {
                var employee = new Employee
                {
                    EmployeeNumber = 123456,
                    FirstName = "John",
                    LastName = "Snow"
                };

                return employee;
            });
        }

        [TestMethod]
        public void Method_Authentication_When_ParameterRequestUsernameIsValid_Should_Return_EmployeeAuthenticated()
        {

            _employeeServiceMock.Setup(item => item.AuthenticationByUsernameAsync(It.IsAny<Employee>()))
                .Returns(_employeeTask);

            _employeeApplicationService = new EmployeeApplicationService(_employeeServiceMock.Object, _unitOfWorkMock.Object);

            var dynamicRequest = JObject.Parse(RequestUsername);
            var employeeAuth = _employeeApplicationService.AuthenticationAsync(dynamicRequest);

            Assert.IsNotNull(employeeAuth);
            Assert.IsTrue(employeeAuth.Result.EmployeeNumber > 0);
            Assert.AreEqual(0, _employeeApplicationService.ListNotifications().Count());
        }

        [TestMethod]
        public void Method_Authentication_When_ParameterRequestBarcodeIsValid_Should_Return_EmployeeAuthenticated()
        {
            _employeeServiceMock.Setup(item => item.AuthenticationByBarcodeAsync(It.IsAny<Employee>()))
                .Returns(_employeeTask);

            _employeeApplicationService = new EmployeeApplicationService(_employeeServiceMock.Object, _unitOfWorkMock.Object);

            var dynamicRequest = JObject.Parse(RequestBarcode);
            var employeeAuth = _employeeApplicationService.AuthenticationAsync(dynamicRequest);

            Assert.IsNotNull(employeeAuth);
            Assert.IsTrue(employeeAuth.Result.EmployeeNumber > 0);
            Assert.AreEqual(0, _employeeApplicationService.ListNotifications().Count());
        }


        [TestMethod]
        public void Method_Authentication_When_ParameterRequestUsernameNotFoundInDataBase_Should_ReturnNullAndNotification()
        {
            _employeeServiceMock.Setup(item => item.AuthenticationByUsernameAsync(It.IsAny<Employee>())).Returns((Task<Employee>)null);

            _employeeApplicationService = new EmployeeApplicationService(_employeeServiceMock.Object, _unitOfWorkMock.Object);

            var dynamicRequest = JObject.Parse(RequestUsername);
            var employeeAuth = _employeeApplicationService.AuthenticationAsync(dynamicRequest);
            
            Assert.IsNull(employeeAuth.Result);
            Assert.IsTrue(_employeeApplicationService.ListNotifications().Any());
        }

        [TestMethod]
        public void Method_Authentication_When_ParameterRequestBarcodeNotFoundInDataBase_Should_ReturnNullAndNotification()
        {
            _employeeServiceMock.Setup(item => item.AuthenticationByUsernameAsync(It.IsAny<Employee>())).Returns((Task<Employee>)null);

            _employeeApplicationService = new EmployeeApplicationService(_employeeServiceMock.Object, _unitOfWorkMock.Object);

            var dynamicRequest = JObject.Parse(RequestBarcode);
            var employeeAuth = _employeeApplicationService.AuthenticationAsync(dynamicRequest);

            Assert.IsNull(employeeAuth.Result);
            Assert.IsTrue(_employeeApplicationService.ListNotifications().Any());
        }

        [TestMethod]
        public void Method_Authentication_When_ParameterRequestIsNull_Should_ThrowInvalidCastException()
        {
            _employeeApplicationService = new EmployeeApplicationService(_employeeServiceMock.Object, _unitOfWorkMock.Object);

            Assert.ThrowsExceptionAsync<InvalidCastException>(() =>
                _employeeApplicationService.AuthenticationAsync(null));
        }
    }
}