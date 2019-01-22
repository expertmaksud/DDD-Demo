using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PX.Core.Abstraction;
using PX.Core.Audit;

namespace PX.Data.Factory
{
    public abstract class Repository<T> : IRepository<T> where T : BaseEntity
    {
        protected ApplicationDbContext _dbContext;

        public Repository(ApplicationDbContext context)
        {
            _dbContext = context;

        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbContext.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> FindBy(Expression<Func<T, bool>> predicate)
        {
            return await this._dbContext.Set<T>().Where(predicate).ToListAsync();
        }

        public async Task<T> GetById(Expression<Func<T, bool>> predicate)
        {
            return await _dbContext.Set<T>()
                .AsNoTracking()
                .FirstOrDefaultAsync(predicate);
        }

        public async Task Create(T entity)
        {
            await this._dbContext.Set<T>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            this._dbContext.Set<T>().Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
