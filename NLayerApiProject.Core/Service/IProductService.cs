using NLayerApiProject.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerApiProject.Core.Service
{
    public interface IProductService : IService<Product>
    {
        Task<Product> GetWithCategoryByIdAsync(int productId);

        // Product nesnesi üzerinden veritabanıyla ilgili olmayan işlemlerde burada tanımlanır
        //bool ControlInnerBarcode(Product product);
    }
}
