using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidator;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Serko.Core.Api.Controllers;

namespace Serko.Core.Test
{
    [TestClass]
    public class BaseControllerUnitTests : BaseController
    {
        private List<Notification> _notifications;

        [TestMethod]
        public void Method_Response_When_ParameterObjectIsValidParameterNotificationIsZero_Should_ReturnOk()
        {
            const string paramObject = "Success";

            _notifications = new List<Notification>();

            var result = Response(paramObject, _notifications);
            var badRequestResult = result.Result as OkObjectResult;

            Assert.IsNotNull(badRequestResult);
            Assert.AreEqual(200, badRequestResult.StatusCode);

            var status = badRequestResult.Value.GetType().GetProperty("success").GetValue(badRequestResult.Value);
            Assert.AreEqual(true, status);

            var data = badRequestResult.Value.GetType().GetProperty("data").GetValue(badRequestResult.Value) as string;
            Assert.AreEqual(paramObject, data);
        }

        [TestMethod]
        public void Method_Response_When_ParameterNotificationContainsItems_Should_ReturnBadRequest()
        {
            _notifications = new List<Notification>();
            var notification = new Notification(string.Empty, string.Empty);

            _notifications.Add(notification);

            var response = Response(null, _notifications);
            var okRequestResult = response.Result as OkObjectResult;

            Assert.IsNotNull(okRequestResult);
            Assert.AreEqual(200, okRequestResult.StatusCode);

            var status = okRequestResult.Value.GetType().GetProperty("success").GetValue(okRequestResult.Value);
            Assert.AreEqual(false, status);

            var errors = okRequestResult.Value.GetType().GetProperty("errors").GetValue(okRequestResult.Value) as IEnumerable<Notification>;
            Assert.IsTrue(errors.Any());
        }

        [TestMethod]
        public void Method_Response_When_ParameterNotificationIsNull_Should_ReturnBadRequestWithInnerException()
        {
            var response = Response(null, null);
            var badRequestResult = response.Result as BadRequestObjectResult;

            Assert.IsNotNull(badRequestResult);
            Assert.AreEqual(400, badRequestResult.StatusCode);

            var status = badRequestResult.Value.GetType().GetProperty("success").GetValue(badRequestResult.Value);
            Assert.AreEqual(false, status);

            var errors = badRequestResult.Value.GetType().GetProperty("errors").GetValue(badRequestResult.Value) as Exception;
            Assert.AreEqual(null, errors);
        }
    }
}