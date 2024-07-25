using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace S9_EnumeracoesEComposicao.Entities
{
    class OrderItem
    {
        public int Quantity { get; set; }
        public double Price { get; set; }
        public Product Product { get; set; }

        public OrderItem() { }

        public OrderItem(int quantity, double price, Product produto)
        {
            Quantity = quantity;
            Price = price;
            Product = produto;
        }

        public double SubTotal()
        {
            return Quantity * Price;
        }

        public override string ToString()
        {
            return Product.Name + 
                ", $" +
                Price.ToString("F2", CultureInfo.InvariantCulture) +
                ", " +
                "Quantity: " +
                Quantity.ToString() +
                ", " +
                "Subtotal: $" +
                SubTotal().ToString("F2", CultureInfo.InvariantCulture);
        }
    }
}
