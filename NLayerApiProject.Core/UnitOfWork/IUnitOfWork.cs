using NLayerApiProject.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerApiProject.Core.UnitOfWork
{
    public interface IUnitOfWork
    {
        // Bunları dependency injection olarak verebilirdik bu daha bestpractice
        IProductRepository Product { get; }
        ICategoryRepository Category { get; }
        Task CommitAsync();
        void Commit();
    }
}
