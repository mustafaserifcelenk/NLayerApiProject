using Microsoft.EntityFrameworkCore;
using NLayerApiProject.Core.Models;
using NLayerApiProject.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerApiProject.Data.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {

        // Repository Base'de ki contexti AppDbContext'e dönüştürdük çünkü artık ne olduğunu biliyoruz, eğer bunu yapmazsak sorgu yaparken istediğimiz değerler elimize gelmez
        private AppDbContext _appDbContext { get => _context as AppDbContext; }

        // Repository'de bir tane constructor olduğundan dolayı ve biz de onu miras aldığımızdan dolayı burada da constructor olmak zorunda
        // burdan gönderilen context ile Repository'deki context doluyor
        public ProductRepository(AppDbContext context) : base(context)
        {
        }


        public async Task<Product> GetWithCategoryByIdAsync(int productId)
        {
            return await _appDbContext.Products.Include(x => x.Category).SingleOrDefaultAsync(x => x.Id == productId);
        }
    }
}