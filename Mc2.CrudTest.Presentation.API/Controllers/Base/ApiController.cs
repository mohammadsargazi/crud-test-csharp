using Application.ViewModels;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Mc2.CrudTest.Presentation.API.Controllers.Base
{
    [ApiController]
    public class ApiController : ControllerBase
    {
        private readonly ICollection<string> _errors = new List<string>();

        protected ActionResult CustomResponse(ResultViewModel result, bool finalstep)
        {
            if (IsOperationValid())
            {
                result.FailedResults = new ValidationResult();
                if (result.SucceedResult != null)
                    return Ok(result.SucceedResult);
            }

            return BadRequest(new ValidationProblemDetails(new Dictionary<string, string[]>
            {
                { "Messages", _errors.ToArray() }
            }));
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            var errors = modelState.Values.SelectMany(e => e.Errors);
            foreach (var error in errors)
            {
                AddError(error.ErrorMessage);
            }

            return CustomResponse(new ResultViewModel(), true);
        }

        protected ActionResult CustomResponse(ResultViewModel Result)
        {
            if (Result.FailedResults != null)
            {
                foreach (var error in Result.FailedResults.Errors)
                {
                    AddError(error.ErrorMessage);
                }
            }

            return CustomResponse(Result, true);
        }

        protected bool IsOperationValid()
        {
            return !_errors.Any();
        }

        protected void AddError(string erro)
        {
            _errors.Add(erro);
        }

        protected void ClearErrors()
        {
            _errors.Clear();
        }
    }
}
