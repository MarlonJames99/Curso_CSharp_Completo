using System;

namespace S4_ClassesAtributosMetodos
{
    internal class Triangulo
    {
        public double A;
        public double B;
        public double C;

        public double Area() // Não são necessários dados adicionais de entrada pois a função só precisará usar os valores de A, B e C que já se encontram dentro do escopo da classe.
        {
            double p = (A + B + C) / 2.0;
            return Math.Sqrt(p * (p - A) * (p - B) * (p - C));
        }
    }
}