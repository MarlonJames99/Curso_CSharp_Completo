using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace S7_TopicosEspeciaisEmCSharpPT1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Var(); // Linha .
            SwitchCase(); // Linha .
            ExpressaoCondicionalTernaria(); // Linha .
        }

        static void Var()
        {
            // Podemos usar a palavra "var" para inicializar uma variável, e o tipo dela será inferido quando você iniciar a variável.
            // o Var é uma comodidade que facilita muitas tarefas durante o desenvolvimento,
            // porém devemos ter cuidado já que ao não declarar o tipo de uma variável de forma explícita, deixamos um possível brecha para erros.

            var X = 10; // A linguagem infere que esta variável é do tipo "int"
            var Y = 20.0; // Nesta caso ela infere que a variável é do tipo "double"
            var Z = "Maria";

            Console.WriteLine(X);
            Console.WriteLine(Y);
            Console.WriteLine(Z);
        }

        static void SwitchCase()
        {
            // Estrutura opcional a vários if-else encadeados, quando a condição envolve o teste do valor de uma variável.

            /*
            Problema exemplo:

            Criar um programa para receber um valor X e informar o dia da semana baseado neste número.
            */

            Console.Write("Informe o número do dia da semana de 1 a 7: ");
            int x = int.Parse(Console.ReadLine());

            string dia;

            // Solução utilizando if-else.

            if (x == 1)
            {
                dia = "domingo";
            }
            else if (x == 2)
            {
                dia = "Segunda-feira";
            }
            else if (x == 3)
            {
                dia = "Terça-feira";
            }
            else if (x == 4)
            {
                dia = "Quarta-feira";
            }
            else if (x == 5)
            {
                dia = "Quinta-feira";
            }
            else if (x == 6)
            {
                dia = "Sexta-feira";
            }
            else if (x == 7)
            {
                dia = "Sábado";
            }
            else
            {
                dia = "Valor inválido";
            }

            Console.WriteLine("Dia: " + dia);

            // Solução usando switch-case

            switch (x)
            {
                case 1:
                    dia = "Domingo";
                    break;
                case 2:
                    dia = "Segunda-feira";
                    break;
                case 3:
                    dia = "Terça-feira";
                    break;
                case 4:
                    dia = "Quarta-feira";
                    break;
                case 5:
                    dia = "Quinta-feira";
                    break;
                case 6:
                    dia = "Sexta-feira";
                    break;
                case 7:
                    dia = "Sábado";
                    break;
                default:
                    dia = "Valor inválido";
                    break;
            }

            Console.WriteLine("Dia: " + dia);
        }

        static void ExpressaoCondicionalTernaria()
        {
            // Extrutura opcional ao if-else quando se deseja decidir um VALOR com base em uma condição.

            /*
            Sintaxe:
            ( CONDIÇÂO ) ? Valor_Se-True : Valor_Se_False

            Exemplos: 
            ( 2 > 4 ) ? 50 : 80 -> 80
            (10 != 3) ? "Maria" : "Alex" -> Maria
            */

            // Exemplo calculando o valor de desconto com base em uma condição.

            double preco = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            double desconto;

            // solução com if-else

            if (preco < 20)
            {
                desconto = preco * 0.1;
            }
            else
            {
                desconto = preco * 0.05;
            }

            Console.WriteLine(desconto);

            // Solução com expressão condicional ternária.

            double desc = (preco < 20.0) ? preco * 0.1 : preco * 0.05;
            Console.WriteLine(desc);
        }
    }
}
