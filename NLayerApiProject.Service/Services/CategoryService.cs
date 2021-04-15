using NLayerApiProject.Core.Models;
using NLayerApiProject.Core.Repository;
using NLayerApiProject.Core.Service;
using NLayerApiProject.Core.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerApiProject.Service.Services
{
    public class CategoryService : Service<Category>, ICategoryService
    {
        public CategoryService(IUnitOfWork unitOfWork, IRepository<Category> repository) : base(unitOfWork, repository)
        {
        }

        public async Task<Category> GetWithProductsByIdAsync(int categoryId)
        {
            return await _unitOfWork.Category.GetWithProductsByIdAsync(categoryId);
        }
    }
}
