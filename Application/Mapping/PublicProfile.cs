using Application.ViewModels;
using AutoMapper;
using Domain.ResultModel;

namespace Application.Mapping;

public class PublicProfile : Profile
{
    public PublicProfile()
    {
        CreateMap(typeof(PagedData<>), typeof(PagedDataViewModel<>))
            .ConvertUsing(typeof(PagedDataConverter<,>));
    }

    private class PagedDataConverter<TSource, TDestination> : ITypeConverter<PagedData<TSource>, PagedDataViewModel<TDestination>>
        where TDestination : class
        where TSource : class
    {
        public PagedDataViewModel<TDestination> Convert(PagedData<TSource> source, PagedDataViewModel<TDestination> destination, ResolutionContext context)
        {
            destination ??= new PagedDataViewModel<TDestination>();
            destination.Data = context.Mapper.Map<List<TDestination>>(source.Data);
            destination.TotalCount = source.TotalCount;
            return destination;
        }
    }
}
