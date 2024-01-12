using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S4_ClassesAtributosMetodos
{
    internal class ConversorDeMoeda
    {
        public static double Cotacao;
        public static double QuantidadeDolares;

        public static double ValorConvertido()
        {
            return Cotacao * (QuantidadeDolares + (QuantidadeDolares * 0.06));
        }
    }
}
