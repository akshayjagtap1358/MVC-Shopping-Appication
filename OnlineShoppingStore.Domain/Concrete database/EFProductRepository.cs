using OnlineShoppingStore.Domain.Entities;
using OnlineShoppingStore.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingStore.Domain.Concrete_database
{
    public class EFProductRepository : IProductRepository
    {
        private readonly EFContext eFContext = new EFContext();
        public IEnumerable<Product> products {
            get { return eFContext.Products; } 
        }
    }
}
