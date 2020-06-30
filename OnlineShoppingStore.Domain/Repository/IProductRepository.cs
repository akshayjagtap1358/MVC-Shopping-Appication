using OnlineShoppingStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingStore.Domain.Repository
{
    public interface IProductRepository
    {
        IEnumerable<Product> products { get; }
    }
}