using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace S4_ClassesAtributosMetodos
{
    internal class Aluno
    {
        public string Nome;
        public double Nota1, Nota2, Nota3;

        public double NotaFinal()
        {
            return Nota1 + Nota2 + Nota3;
        }

        /* Minha solução:
        public void Aprovacao()
        {
            if (NotaFinal() >= 60)
            {
                Console.WriteLine("Aprovado!");
            } 
            else
            {
                Console.WriteLine("Reprovado!");
                Console.WriteLine("Faltaram " + (60 - NotaFinal()).ToString("F2", CultureInfo.InvariantCulture) + " Pontos.");
            }
        }
        */

        public bool Aprovacao() // Solução do professor:
        {
            if (NotaFinal() >= 60)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public double NotaRestante()
        {
            if (Aprovacao())
            {
                return 0.0;
            }
            else
            {
                return 60.0 - NotaFinal();
            }
        }
    }
}
