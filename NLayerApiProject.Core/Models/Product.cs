using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerApiProject.Core.Models
{
    internal class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public bool IsDeleted { get; set; }
        public string InnerBarcode  { get; set; }

        // Virtual : EntityFramework virtual'ı kullanarak Category üzerinde yapılan değişiklikleri izlicek
        public virtual Category Category { get; set; }
    }
}
