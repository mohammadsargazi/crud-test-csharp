using Application.ViewModels.CommandViewModels;
using AutoMapper;
using Domain.Commands;

namespace Application.Mapping;

public class ViewModelToDomainMappingProfile : Profile
{
    public ViewModelToDomainMappingProfile()
    {
        CreateMap<RegisterNewCustomerCommandViewModel, RegisterNewCustomerCommand>();
        CreateMap<UpdateCustomerCommandViewModel, UpdateCustomerCommand>();
        CreateMap<DeleteCustomerCommandViewModel, DeleteCustomerCommand>();
    }

}
