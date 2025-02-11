using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S10_HerancaEPolimorfismo.Entities
{
    class Pessoajuridica : Taxpayer
    {
        public int Employees { get; set; }

        public Pessoajuridica(string name, double income, int employees)
        {
            Name = name; 
            Income = income;
            Employees = employees;
        }

        public override double Tax()
        {
            if (Employees > 10) 
            {
                return Income * 0.14;
            }
            else
            {
                return Income * 0.16;
            }
        }
    }
}
