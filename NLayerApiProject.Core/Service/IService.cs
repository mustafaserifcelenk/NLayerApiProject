using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NLayerApiProject.Core.Service
{
    public interface IService<TEntity> where TEntity:class
    {
        Task<TEntity> GetByIdAsync(int id);
        Task<IEnumerable<TEntity>> GetAllAsync();

        // Func : Bu bir fonksiyon olacak
        // TEntity alacak ve dönüş tipi bool olacak
        // Func ve predicate bir delege 
        Task<IEnumerable<TEntity>> Where(Expression<Func<TEntity, bool>> predicate);

        // x => x.name == "Kalem"; 'x': TEntity, 'x.name == Kalem' : bool
        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> AddAsync(TEntity entity);
        Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
        TEntity Update(TEntity entity);
    }
}
