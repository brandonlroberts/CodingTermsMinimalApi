using Microsoft.EntityFrameworkCore;
using CodingTermsMinimalApi.Models.Base;
using CodingTermsMinimalApi.Dal.Data;

namespace CodingTermsMinimalApi.Dal.Repositories.Base
{
    public abstract class RepoBase<TEntity, TRepo> : IRepoBase<TEntity>
        where TEntity : BaseEntity
    {
        protected readonly ApplicationDbContext Context;
        public DbSet<TEntity> Table { get; set; }

        protected RepoBase(ApplicationDbContext context)
        {
            Context = context;
            Table = Context.Set<TEntity>();
        }

        public (string Schema, string TableName) TableAndSchemaName
        {
            get
            {
                var metaData = Context.Model.FindEntityType(typeof(TEntity).FullName);
                return (metaData.GetSchema(), metaData.GetTableName());
            }
        }

        public virtual int Create(TEntity entity, bool persist = true)
        {
            Table.Add(entity);
            return persist ? SaveChanges() : 0;
        }

        public virtual int CreateRange(IEnumerable<TEntity> entities, bool persist = true)
        {
            Table.AddRange(entities);
            return persist ? SaveChanges() : 0;
        }

        public virtual int Update(TEntity entity, bool persist = true)
        {
            Table.Update(entity);
            return persist ? SaveChanges() : 0;
        }
        public virtual int UpdateRange(IEnumerable<TEntity> entities, bool persist = true)
        {
            Table.UpdateRange(entities);
            return persist ? SaveChanges() : 0;
        }


        public int Delete(TEntity entity, bool persist = true)
        {
            Table.Remove(entity);
            return persist ? SaveChanges() : 0;
        }

        public int DeleteRange(IEnumerable<TEntity> entities, bool persist = true)
        {
            Table.RemoveRange(entities);
            return persist ? SaveChanges() : 0;
        }
        public virtual IQueryable<TEntity> GetAllAsQueryableNoTracking()
            => Table.AsQueryable().AsNoTracking();

        public virtual IQueryable<TEntity> GetAllActiveAsQueryableNoTracking()
            => Table.AsQueryable().AsNoTracking().Where(x => x.IsActive);

        public virtual IQueryable<TEntity> GetAllAsQueryableNoTrackingIgnoreQueryFilters()
            => Table.AsQueryable().AsNoTracking().IgnoreQueryFilters();

        public TEntity FindById(int id) => Table.Find(id);

        public TEntity FindByIdIgnoreQueryFilters(int id)
            => Table.IgnoreQueryFilters().OrderBy(x => x.Id).FirstOrDefault(x => x.Id == id);

        public TEntity FindByIdNoTracking(int id)
            => Table.AsNoTracking().OrderBy(x => x.Id).FirstOrDefault(x => x.Id == id);

        public TEntity FindByIdNoTrackingIgnoreQueryFilters(int id)
        {
            return Table.IgnoreQueryFilters().AsNoTracking().OrderBy(x => x.Id).FirstOrDefault(x => x.Id == id);
        }

        public int SaveChanges()
        {
            return Context.SaveChanges();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await Context.SaveChangesAsync();
        }

    }
}