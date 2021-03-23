using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Shared;
using Shared.Resources;

namespace Hungabor01Website.Controllers
{
    [Route("error")]
    public class ErrorController : Controller
    {
        private readonly ILogger<ErrorController> logger;

        public ErrorController(ILogger<ErrorController> logger)
        {
            this.logger = logger;
        }

        [AllowAnonymous]
        [Route("error-code-handler/{errorCode}")]
        public IActionResult ExceptionCodeHandler(int errorCode)
        {
            ViewBag.ErrorCode = errorCode;
            var errorMessage = errorCode switch
            {
                404 => Strings.Error404,
                _ => Strings.UnexpectedError,
            };
            ViewBag.ErrorMessage = errorMessage;
            logger.LogWarning(EventIds.ExceptionCodeHandlerError, errorMessage);
            return View("Error");
        }

        [AllowAnonymous]
        [Route("unhandled-error")]
        public IActionResult UnhandledError()
        {
            string errorMessage;
            try
            {
                var exceptionHandlerPathFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
                errorMessage = exceptionHandlerPathFeature.Error.Message;
            }
            catch
            {
                errorMessage = Strings.UnexpectedError;
            }

            ViewBag.ErrorMessage = errorMessage;
            logger.LogWarning(EventIds.UnhandledErrorError, errorMessage);
            return View("Error");
        }
    }
}