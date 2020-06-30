using OnlineShoppingStore.Domain.Entities;
using System.Data.Entity;

namespace OnlineShoppingStore.Domain.Concrete_database
{
    public class EFContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
    }
}
