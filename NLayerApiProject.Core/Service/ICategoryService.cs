using NLayerApiProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerApiProject.Core.Service
{
    public interface ICategoryService : IService<Category>
    {
        Task<Category> GetWithProductsByIdAsync(int categoryId);

        // Category'ye özgü ICategoryRepository'den(veritabanı işlerinden) bağımsız metotlar varsa burada tanımlanabilir
    }
}
