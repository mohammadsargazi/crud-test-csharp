using Application.ViewModels;
using Application.ViewModels.CommandViewModels;

namespace Application.Interfaces;

public interface ICustomerAppService
{
    Task<PagedDataViewModel<CustomerViewModel>> GetAll(int pageNumber, int pageSize, CancellationToken cancellationToken);
    Task<CustomerViewModel> GetById(string id, CancellationToken cancellationToken);
    Task<ResultViewModel> Insert(RegisterNewCustomerCommandViewModel commandViewModel, CancellationToken cancellationToken);
    Task<ResultViewModel> Update(UpdateCustomerCommandViewModel commandViewModel, CancellationToken cancellationToken);
    Task<ResultViewModel> Delete(DeleteCustomerCommandViewModel commandViewModel, CancellationToken cancellationToken);
}
