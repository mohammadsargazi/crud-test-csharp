using Application.Interfaces;
using Application.ViewModels.CommandViewModels;
using Application.ViewModels;
using AutoMapper;
using Domain.Commands;
using Domain.Interfaces;
using MediatR;

namespace Application.Services;

public class CustomerAppService : ICustomerAppService
{

    #region Fields
    private readonly ICustomerRepository _customerRepository;
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;
    #endregion

    #region Ctor
    public CustomerAppService(ICustomerRepository customerRepository
            , IMapper mapper
            , IMediator mediator)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
        _mediator = mediator;
    }
    #endregion
    public async Task<PagedDataViewModel<CustomerViewModel>> GetAll(int pageNumber, int pageSize, CancellationToken cancellationToken)
    {
        return _mapper.Map<PagedDataViewModel<CustomerViewModel>>(await _customerRepository.GetAll(pageNumber, pageSize, cancellationToken));
    }

    public async Task<CustomerViewModel> GetById(string id, CancellationToken cancellationToken)
    {
        return _mapper.Map<CustomerViewModel>(await _customerRepository.GetById(id, cancellationToken));
    }
            
    public async Task<ResultViewModel> Insert(RegisterNewCustomerCommandViewModel commandViewModel, CancellationToken cancellationToken)
    {
        var command = _mapper.Map<RegisterNewCustomerCommand>(commandViewModel);
        var res = await _mediator.Send(command);
        return new ResultViewModel() { SucceedResult = _mapper.Map<CustomerViewModel>(res.SucceedResult), FailedResults = res.FailedResults };
    }
        
    public async Task<ResultViewModel> Update(UpdateCustomerCommandViewModel commandViewModel, CancellationToken cancellationToken)
    {
        var command = _mapper.Map<UpdateCustomerCommand>(commandViewModel);
        var res = await _mediator.Send(command);
        return new ResultViewModel() { SucceedResult = _mapper.Map<CustomerViewModel>(res.SucceedResult), FailedResults = res.FailedResults };
    }

    public async Task<ResultViewModel> Delete(DeleteCustomerCommandViewModel commandViewModel, CancellationToken cancellationToken)
    {
        var command = _mapper.Map<DeleteCustomerCommand>(commandViewModel);
        var res = await _mediator.Send(command);
        return new ResultViewModel() { SucceedResult = _mapper.Map<CustomerViewModel>(res.SucceedResult), FailedResults = res.FailedResults };
    }
}