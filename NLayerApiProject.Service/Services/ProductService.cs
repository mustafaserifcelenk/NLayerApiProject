using NLayerApiProject.Core.Models;
using NLayerApiProject.Core.Repository;
using NLayerApiProject.Core.Service;
using NLayerApiProject.Core.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NLayerApiProject.Service.Services
{
    public class ProductService : Service<Product>, IProductService
    {
        public ProductService(IUnitOfWork unitOfWork, IRepository<Product> repository) : base(unitOfWork, repository)
        {
        }

        public async Task<Product> GetWithCategoryByIdAsync(int productId)
        {
            return await _unitOfWork.Product.GetWithCategoryByIdAsync(productId);
        }
    }
}
