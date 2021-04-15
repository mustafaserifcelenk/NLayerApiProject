using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NLayerApiProject.Core.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetByIdAsync(int id);
        Task<IEnumerable<TEntity>> GetAllAsync();

        // Func : Bu bir fonksiyon olacak
        // TEntity alacak ve dönüş tipi bool olacak
        // Func ve predicate bir delege 
        IEnumerable<TEntity> Where(Expression<Func<TEntity, bool>> predicate);

        // x => x.name == "Kalem"; 'x': TEntity, 'x.name == Kalem' : bool
        Task<TEntity> SingleOrDefaultASync(Expression<Func<TEntity, bool>> predicate);
        Task AddAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entities);
        void RemoveAsync(TEntity entity);
        void RemoveRangeAsync(IEnumerable<TEntity> entities);
        TEntity Update(TEntity entity);

    }
}
