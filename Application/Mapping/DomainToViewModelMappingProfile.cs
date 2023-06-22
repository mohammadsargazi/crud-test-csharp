using Application.ViewModels;
using AutoMapper;
using Domain.Entities;


namespace Application.Mapping;

public class DomainToViewModelMappingProfile : Profile
{
    public DomainToViewModelMappingProfile()
    {
        CreateMap<Customer, CustomerViewModel>().ReverseMap();

    }
}
