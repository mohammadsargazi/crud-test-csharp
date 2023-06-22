namespace Domain.Interfaces.Base;
public interface IBaseRepository<T> where T : BaseEntity
{
    Task<PagedData<T>> GetAll(int skip, int limit, CancellationToken cancellationToken);
    Task<T> GetById(string id, CancellationToken cancellationToken);
    Task<T> InsertAsync(T entity,CancellationToken cancellationToken);
    Task<bool> UpdateAsync(T entity, CancellationToken cancellationToken);
    Task<bool> DeleteAsync(T entity, CancellationToken cancellationToken);
}

