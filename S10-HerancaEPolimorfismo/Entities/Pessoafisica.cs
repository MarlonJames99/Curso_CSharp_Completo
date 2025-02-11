using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S10_HerancaEPolimorfismo.Entities
{
    class Pessoafisica : Taxpayer
    {
        public double Healthcare { get; set; }

        public Pessoafisica(string name, double income, double healthcare)
        {
            Name = name;
            Income = income;
            Healthcare = healthcare;
        }

        public override double Tax()
        {
            if (Income < 20000.00)
            {
                return (Income * 0.15) - (Healthcare * 0.5);
            }
            else
            {
                return (Income * 0.25) - (Healthcare * 0.5);
            }
        }
    }
}
