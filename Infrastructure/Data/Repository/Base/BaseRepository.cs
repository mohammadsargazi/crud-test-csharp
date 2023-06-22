using Domain.Entities.Base;
using Domain.Interfaces.Base;
using Domain.ResultModel;
using MongoDB.Entities;
using Domain.Extensions;

namespace Data.Repository.Base;

public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
{
    public async Task<PagedData<T>> GetAll(int pageNumber, int pageSize, CancellationToken cancellationToken)
    {
        var res = await DB.PagedSearch<T>().PageNumber(pageNumber).PageSize(pageSize)
            .Sort(s => s.Descending(d => d.CreateDate)).ExecuteAsync(cancellationToken);
        return res.Results.ToPagedData(res.TotalCount);
    }

    public async Task<T> GetById(string id, CancellationToken cancellationToken)
    {
        return await DB.Find<T>().OneAsync(id, cancellationToken);
    }

    public async Task<T> InsertAsync(T entity, CancellationToken cancellationToken)
    {
        await entity.SaveAsync(null, cancellationToken);
        return entity;
    }

    public async Task<bool> UpdateAsync(T entity, CancellationToken cancellationToken)
    {
        var result = await DB.Update<T>()
                 .MatchID(entity.ID)
                 .ModifyExcept(x => new { x.ID }, entity)
                 .ExecuteAsync(cancellationToken);

        return result.ModifiedCount != 0;
    }

    public async Task<bool> DeleteAsync(T entity, CancellationToken cancellationToken)
    {
        var result = await DB.DeleteAsync<T>(entity.ID, null, cancellationToken);

        return result.DeletedCount != 0;

    }
}
