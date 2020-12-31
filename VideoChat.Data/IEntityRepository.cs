using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace VideoChat.Data
{
    public interface IEntityRepository<TEntity> where TEntity: class
    {
        IQueryable<TEntity> GetEntities();
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        Task<List<TEntity>> ToListAsync(IQueryable<TEntity> queryable, CancellationToken cancellationToken = default);
        Task<TEntity> FirstOrDefaultAsync(IQueryable<TEntity> queryable, CancellationToken cancellationToken = default);
    }
}
