using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S10_HerancaEPolimorfismo.Entities.Enums;

namespace S10_HerancaEPolimorfismo.Entities
{
    abstract class Shape
    {
        public Color Color { get; set; }

        public Shape (Color color)
        {
            Color = color;
        }

        public abstract double Area();
    }
}
