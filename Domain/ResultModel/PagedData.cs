namespace Domain.ResultModel;

public class PagedData<T>
{
    public PagedData()
    {
        Data = new List<T>();
    }
    public long TotalCount { get; set; }
    public List<T> Data { get; set; }
}