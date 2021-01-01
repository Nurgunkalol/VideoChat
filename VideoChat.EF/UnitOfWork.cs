using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace VideoChat.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly IDatabaseFactory DatabaseFactory;

        protected DbContext Context => DatabaseFactory.Get();

        public UnitOfWork(IDatabaseFactory databaseFactory)
        {
            DatabaseFactory = databaseFactory;
        }
        public Task CommitAsync(CancellationToken cancellationToken = default)
        {
            return Context.SaveChangesAsync(cancellationToken);
        }
    }
}
