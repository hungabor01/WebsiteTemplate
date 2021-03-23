using Hungabor01Website.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Shared.Resources;
using System;
using Xunit;

namespace Hungabor01Website.Tests.Controllers
{
    public class ErrorControllerTests
    {
        private readonly Mock<ILogger<ErrorController>> mockLogger;
        private readonly ErrorController errorController;

        public ErrorControllerTests()
        {
            mockLogger = new Mock<ILogger<ErrorController>>();
            errorController = new ErrorController(mockLogger.Object);
        }

        [Fact]
        public void ExceptionCodeHandler_StatusCode404_ReturnViewWithErrorMessage()
        {
            var actionResult = errorController.ExceptionCodeHandler(404);

            var viewResult = Assert.IsType<ViewResult>(actionResult);
            Assert.Equal("Error", viewResult.ViewName);
            Assert.Equal(2, viewResult.ViewData.Count);
            Assert.Equal(404, viewResult.ViewData["ErrorCode"]);
            Assert.Equal(Strings.Error404, viewResult.ViewData["ErrorMessage"]);
            mockLogger.Verify(l => l.Log(
                It.IsAny<LogLevel>(),
                It.IsAny<EventId>(),
                It.IsAny<It.IsAnyType>(),
                It.IsAny<Exception>(),
                (Func<It.IsAnyType, Exception, string>)It.IsAny<object>()),
                Times.Once);
        }

        [Fact]
        public void ExceptionCodeHandler_NoStatusCode_ReturnViewWithErrorMessage()
        {
            var actionResult = errorController.ExceptionCodeHandler(0);

            var viewResult = Assert.IsType<ViewResult>(actionResult);
            Assert.Equal("Error", viewResult.ViewName);
            Assert.Equal(2, viewResult.ViewData.Count);
            Assert.Equal(0, viewResult.ViewData["ErrorCode"]);
            Assert.Equal(Strings.UnexpectedError, viewResult.ViewData["ErrorMessage"]);
            mockLogger.Verify(l => l.Log(
                It.IsAny<LogLevel>(),
                It.IsAny<EventId>(),
                It.IsAny<It.IsAnyType>(),
                It.IsAny<Exception>(),
                (Func<It.IsAnyType, Exception, string>)It.IsAny<object>()),
                Times.Once);
        }

        [Fact]
        public void UnhandledError_NoErrorInHttpContext_ReturnViewWithErrorMessage()
        {
            var actionResult = errorController.UnhandledError();

            var viewResult = Assert.IsType<ViewResult>(actionResult);
            Assert.Equal("Error", viewResult.ViewName);
            Assert.Single(viewResult.ViewData);
            Assert.Equal(Strings.UnexpectedError, viewResult.ViewData["ErrorMessage"]);
            mockLogger.Verify(l => l.Log(
                It.IsAny<LogLevel>(),
                It.IsAny<EventId>(),
                It.IsAny<It.IsAnyType>(),
                It.IsAny<Exception>(),
                (Func<It.IsAnyType, Exception, string>)It.IsAny<object>()),
                Times.Once);
        }
    }
}