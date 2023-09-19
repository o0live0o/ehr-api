using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Ehr.Core.Data;
using Ehr.Core.IRepository;
using Microsoft.EntityFrameworkCore;

namespace Ehr.Infrastructure.SqlServer
{
    public class EhrRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly EhrDbContext _dbContext;

        public EhrRepository(EhrDbContext context)
        {
            this._dbContext = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Add(T t)
        {
            _dbContext.Set<T>().Add(t);
        }

        public async Task<T> FirstAsync(Expression<Func<T, bool>> where)
        {
            return await _dbContext.Set<T>().Where(@where).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<T>> QueryAsync(Expression<Func<T, bool>> where)
        {
            return await _dbContext.Set<T>().Where(@where).ToListAsync();
        }

        public async Task<IEnumerable<T>> QueryAsync()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<int> SaveChangeAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public void RejectChanges()
        {
            foreach (var entry in _dbContext.ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Modified:
                    case EntityState.Deleted:
                        entry.State = EntityState.Modified; 
                        entry.State = EntityState.Unchanged;
                        break;
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                }
            }
        }
    }
}