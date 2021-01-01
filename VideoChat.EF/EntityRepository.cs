using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace VideoChat.EF
{
    public class EntityRepository<TEntity> : IEntityRepository<TEntity> where TEntity : class
    {
        protected readonly IDatabaseFactory DatabaseFactory;

        protected DbContext Context => DatabaseFactory.Get();

        protected DbSet<TEntity> Entities => Context.Set<TEntity>();

        public EntityRepository(IDatabaseFactory databaseFactory)
        {
            DatabaseFactory = databaseFactory;
        }

        public void Add(TEntity entity)
        {
            Entities.Add(entity);
        }

        public void Delete(TEntity entity)
        {
            if (Context.Entry(entity).State != EntityState.Detached)
            {
                Entities.Remove(entity);
            }
            else
            {
                Entities.Attach(entity);
                Context.Entry(entity).State = EntityState.Deleted;
            }
        }

        public IQueryable<TEntity> GetEntities()
        {
            return Entities;
        }

        public Task<TEntity> FirstOrDefaultAsync(IQueryable<TEntity> queryable, CancellationToken cancellationToken = default)
        {
            return queryable.FirstOrDefaultAsync(cancellationToken);
        }

        public Task<List<TEntity>> ToListAsync(IQueryable<TEntity> queryable, CancellationToken cancellationToken = default)
        {
            return queryable.ToListAsync(cancellationToken);
        }

        public void Update(TEntity entity)
        {
            if (Context.Entry(entity).State != EntityState.Detached)
            {
            }
            else
            {
                Entities.Attach(entity);
                Context.Entry(entity).State = EntityState.Modified;
            }
        }
    }
}
