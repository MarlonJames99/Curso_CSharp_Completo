using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S10_HerancaEPolimorfismo.Entities
{
    class UsedProduct : Product
    {
        public DateTime ManufactureDate { get; set; }

        public UsedProduct() { }

        public UsedProduct(string name, Double price, DateTime manufactureDate) : base (name, price)
        {
            manufactureDate = ManufactureDate;
        }

        public override string PriceTag()
        {
            return base.PriceTag() + $" (Data de Fabricação: ${ManufactureDate})";
        }
    }
}
