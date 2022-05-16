using Microsoft.EntityFrameworkCore;
using CodingTermsMinimalApi.Models.Base;

namespace CodingTermsMinimalApi.Dal.Repositories.Base
{
    public interface IRepoBase<TEntity> where TEntity : BaseEntity
    {
        DbSet<TEntity> Table { get; set; }
        int Create(TEntity entity, bool persist = true);
        int CreateRange(IEnumerable<TEntity> entities, bool persist = true);
        int Update(TEntity entity, bool persist = true);
        int UpdateRange(IEnumerable<TEntity> entities, bool persist = true);
        int Delete(TEntity entity, bool persist = true);
        int DeleteRange(IEnumerable<TEntity> entities, bool persist = true);
        (string Schema, string TableName) TableAndSchemaName { get; }
        IQueryable<TEntity> GetAllAsQueryableNoTracking();
        IQueryable<TEntity> GetAllActiveAsQueryableNoTracking();
        IQueryable<TEntity> GetAllAsQueryableNoTrackingIgnoreQueryFilters();
        TEntity FindById(int id);
        TEntity FindByIdIgnoreQueryFilters(int id);
        TEntity FindByIdNoTracking(int id);
        TEntity FindByIdNoTrackingIgnoreQueryFilters(int id);
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }
}