using NLayerApiProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerApiProject.Core.Repository
{
    internal interface IProductRepository:IRepository<Product>
    {
        Task<Product> GeWithCategoryByIdAsync(int productId); 
    }
}
