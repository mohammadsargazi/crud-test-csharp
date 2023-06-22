namespace Application.ViewModels;

public class PagedDataViewModel<T>
{
    public PagedDataViewModel()
    {
        Data = new List<T>(0);
    }
    public List<T> Data { get; set; }
    public long TotalCount { get; set; }
}