using CSharpFunctionalExtensions;
using Microsoft.AspNetCore.Mvc;
using Sahra.Student.Api.Infra;
using System;
using System.Linq;
using System.Web.Mvc.Html;

namespace Sahra.Student.Api.Controllers
{
    public class BaseController : ControllerBase
    {
        protected new IActionResult Ok()
        {
            var response = new Envelope<string>();
            response.OK();

            return base.Ok(response);
        }
        protected IActionResult Ok<T>(T result)
        {
            var response = new Envelope<T>();
            response.OK(result);
            return base.Ok(response);
        }
        protected IActionResult ErrorModelState()
        {
            var response = new Envelope<string>();
            var error = new ErrorInfo(
                    (int)ErrorCodeEnum.BadRequest,
                    string.Join(";", ModelState.Values
                                            .SelectMany(x => x.Errors)
                                            .Select(x => x.ErrorMessage))
                    );
            response.SetError(error);

            return BadRequest(response);
        }
        protected IActionResult FromResult(Result result)
        {
            return result.IsSuccess ? Ok() : BadRequest(result);
        }
        protected IActionResult FromResult<T>(Result<T> result) where T : class
        {
            return result.IsSuccess ? Ok(result.Value) : BadRequest(result);
        }
        private IActionResult BadRequest(Result result)
        {
            var errorMessage = result.Error;
            ErrorCodeEnum errorCodeEnum;
            if (Enum.TryParse(errorMessage, out errorCodeEnum))
                errorMessage = EnumHelper<ErrorCodeEnum>.GetDisplayValue(errorCodeEnum);

            var envelope = new Envelope<string>();
            envelope.SetError(new ErrorInfo((int)errorCodeEnum, errorMessage));
            return BadRequest(envelope);
        }
    }
}
