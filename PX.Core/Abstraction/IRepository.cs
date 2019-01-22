using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PX.Core.Audit;

namespace PX.Core.Abstraction
{
    public interface IRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAll();

        Task<IEnumerable<T>> FindBy(Expression<Func<T, bool>> predicate);

        Task<T> GetById(Expression<Func<T, bool>> predicate);

        Task Create(T entity);

        Task Update(T entity);

        Task Delete(int id);
    }
}
