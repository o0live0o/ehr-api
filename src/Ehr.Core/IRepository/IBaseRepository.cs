using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Ehr.Core.Data;

namespace Ehr.Core.IRepository
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> QueryAsync(Expression<Func<T, bool>> @where);
        Task<IEnumerable<T>> QueryAsync();
        void Add(T t);
        Task<T> FirstAsync(Expression<Func<T, bool>> @where);
        Task<int> SaveChangeAsync();
        void RejectChanges();
    }
}