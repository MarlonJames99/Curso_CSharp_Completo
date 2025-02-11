using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S10_HerancaEPolimorfismo.Entities
{
    abstract class Taxpayer
    {
        public string Name { get; set; }
        public double Income { get; set; }
        public Taxpayer() { }

        public abstract double Tax();
    }
}
