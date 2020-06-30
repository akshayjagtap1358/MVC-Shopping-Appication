using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShoppingStore.Domain.Entities
{
    public class Cart
    {
        private List<CartLine> cartLines = new List<CartLine>();

        public void AddItem(Product product, int quantity)
        {
            var lineCollection = cartLines.Where(p => p.Product.ProductId == product.ProductId).FirstOrDefault();
            if (lineCollection == null)
            {
                cartLines.Add(new CartLine()
                {
                    Product = product,
                    Quantity = quantity
                });
            }
            else
            {
                lineCollection.Quantity += quantity;
            }
        }

        public void RemoveItem(Product product)
        {
            cartLines.RemoveAll(p => p.Product.ProductId == product.ProductId);
        }

        public decimal CalculateTotalSum()
        {
            return cartLines.Sum(p => p.Product.Price * p.Quantity);
        }

        public IEnumerable<CartLine> CartLines { get { return cartLines; } }

        public void ClearItems()
        {
            cartLines.Clear();
        }
    }
}
