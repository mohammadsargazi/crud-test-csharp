namespace Domain.Extensions;

public static class PagedDataExtensions
{
    public static PagedData<T> ToPagedData<T>(this IReadOnlyList<T> response, long totla) where T : class
    {
        return new PagedData<T>
        {
            Data = response?.ToList() ?? new List<T>(),
            TotalCount = totla
        };
    }
}