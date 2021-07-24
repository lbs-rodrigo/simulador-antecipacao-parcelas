using Microsoft.AspNetCore.Mvc;

namespace Simulador.Calculos.Core.ResponseBase
{
    public class SingleResponse
    {
        protected IActionResult SuccessResponse<T>(T data)
        {
            return new OkObjectResult(data);
        }

        protected IActionResult SuccessResponse()
        {
            return new OkResult();
        }

        public IActionResult Created()
        {
            return new CreatedResult("", null);
        }

        public IActionResult Created<T>(T data)
        {
            return new CreatedResult("", data);
        }

        public IActionResult NoContent()
        {
            return new NoContentResult();
        }

        protected IActionResult ErrorResponse(string message)
        {
            return new BadRequestObjectResult(new ErrorResponse(message));
        }

        protected IActionResult ErrorResponseDecision()
        {
            return new ConflictResult();
        }

        protected IActionResult ErrorResponseSpecific(int statusCode, string message)
        {
            return new ObjectResult(new ErrorResponse(message)) { StatusCode = statusCode };
        }

        protected IActionResult ErrorResponseSpecific(int statusCode, string message, string email)
        {
            return new ObjectResult(new ErrorResponseSpecific() { message = message, email = email }) { StatusCode = statusCode };
        }
    }

    public class ErrorResponse
    {
        public ErrorResponse()
        {

        }

        public ErrorResponse(string msg)
        {
            this.message = msg;
        }

        public string message { get; set; }
    }

    public class ErrorResponseSpecific
    {
        public string message { get; set; }
        public string email { get; set; }
    }
}
