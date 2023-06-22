using Application.Interfaces;
using Application.ViewModels.CommandViewModels;
using Application.ViewModels;
using Mc2.CrudTest.Presentation.API.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace Mc2.CrudTest.Presentation.API.Controllers
{
    public class CustomerController : ApiController
    {
        #region Fields
        private readonly ICustomerAppService _customerAppService;
        #endregion

        #region Ctor
        public CustomerController(ICustomerAppService customerAppService)
        {
            _customerAppService = customerAppService;
        }
        #endregion

        #region Actions
        [HttpGet("customer")]
        public async Task<PagedDataViewModel<CustomerViewModel>> GetAll([FromQuery] int pageNumber, [FromQuery] int pageSize, CancellationToken cancellationToken) =>
             await _customerAppService.GetAll(pageNumber, pageSize, cancellationToken);

        [HttpGet("customer/{id:guid}")]
        public async Task<CustomerViewModel> Get(string id, CancellationToken cancellationToken) =>
             await _customerAppService.GetById(id, cancellationToken);

        [HttpPost]
        [Route("registernewcustomer")]
        public async Task<ActionResult<ResultViewModel>> Post([FromBody] RegisterNewCustomerCommandViewModel viewModel, CancellationToken cancellationToken)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState)
                : CustomResponse(await _customerAppService.Insert(viewModel, cancellationToken));
        }
        [HttpPut("customer")]
        public async Task<ActionResult<ResultViewModel>> Put([FromBody] UpdateCustomerCommandViewModel viewModel, CancellationToken cancellationToken)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState)
                : CustomResponse(await _customerAppService.Update(viewModel, cancellationToken));
        }

        [HttpDelete("customer")]
        public async Task<ActionResult<ResultViewModel>> Delete([FromBody] DeleteCustomerCommandViewModel viewModel, CancellationToken cancellationToken)
        {
            return !ModelState.IsValid ? CustomResponse(ModelState)
                : CustomResponse(await _customerAppService.Delete(viewModel, cancellationToken));
        }
        #endregion
    }
}
