using Microsoft.EntityFrameworkCore;
using NLayerApiProject.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NLayerApiProject.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public Repository(DbContext context)
        {
            // _context : Veritabanına erişim
            _context = context;

            // Gelen entity'deki dbset'e göre ayarlıyoruz, dbset dönüyor
            // Tablolara erişim
            _dbSet = context.Set<TEntity>();
        }

        public async Task AddAsync(TEntity entity)
        {
            // await : Bu satırdaki kod işlemini bitirine kadar bu satırda bekle
            await _dbSet.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _dbSet.AddRangeAsync(entities);
        }

        // Task senkron programlamadaki voide karşılık gelir
        public IEnumerable<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public void RemoveAsync(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public void RemoveRangeAsync(IEnumerable<TEntity> entities)
        {
            _dbSet.RemoveRange(entities);
        }

        public async Task<TEntity> SingleOrDefaultASync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.SingleOrDefaultAsync(predicate);
        }

        public TEntity Update(TEntity entity)
        {
            // SaveChange'i gördüğü yerde gelen entityi veritabanında olanla değiştirir, kötü tarafı ise tek bir veri değişse bile tümünü değiştirir
            _context.Entry(entity).State = EntityState.Modified;
            return entity;
        }
    }
}
