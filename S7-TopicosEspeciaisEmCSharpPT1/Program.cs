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
            FuncoesInteressantesStrings(); // Linha .
            FuncaoDateTime(); // Linha .
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

        static void FuncoesInteressantesStrings()
        {
            // Funções que podemos utilizar com strings.

            string original = "abcde FGHIJ ABC abc DEFG     ";

            string s1 = original.ToUpper(); // Converte toda a string para maíusculas.
            string s2 = original.ToLower(); // Converte toda a string para minúsculas.
            string s3 = original.Trim(); // Apaga espaços vazios tanto antes quanto depois da string.

            int n1 = original.IndexOf("bc"); // Busca o index de onde inicia a primeira ocorrência do trecho citado dentro da string em questão.
            int n2 = original.LastIndexOf("bc"); // Busca o index de onde inicia a última ocorrência do trecho citado dentro da string em questão.

            string s4 = original.Substring(3); // Recorta a string a partir do index informado, nesse caso, a partir do index 3.
                                               // Também podemos informar o tamanho que queremos que ele recorte.

            string s5 = original.Substring(3, 5); // Recorta a partir do index 3, apenas 5 elementos.

            string s6 = original.Replace('a', 'x'); // Substitui o primeiro elemento pelo segundo, nesse caso, todo caracter 'a' por 'x'.
            string s7 = original.Replace("abc", "xy"); // Mostra que o substituto não precisa necessariamente ter o mesmo tamanho.

            bool b1 = string.IsNullOrEmpty(original); // Testa se o conteúdo é vazio ou nulo.
            bool b2 = string.IsNullOrWhiteSpace(original); // Testa se o conteúdo é nulo ou vários espaços em branco.

            Console.WriteLine("Original: - " + original + "-");
            Console.WriteLine("ToUpper: - " + s1 + "-");
            Console.WriteLine("ToLower: - " + s2 + "-");
            Console.WriteLine("Trim: - " + s3 + "-");
            Console.WriteLine("IndexOf ('bc'): - " + n1 + "-");
            Console.WriteLine("LastIndexOf ('bc'): - " + n2 + "-");
            Console.WriteLine("Substring(3): -" + s4 + "-");
            Console.WriteLine("Substring(3, 5): -" + s5 + "-");
            Console.WriteLine("Replace('a', 'x'): -" + s6 + "-");
            Console.WriteLine("Replace('abc', 'xy'): -" + s7 + "-");
            Console.WriteLine("IsNullOrEmpty: " + b1);
            Console.WriteLine("IsNullOrWhiteSpace: " + b2);

            /*
            Além das mencionadas acima, temos outras que já vimos no decorrer do curso, como:

            - str.Split
            - int x = int.Parse(str)
            - str = x.ToString("F2")
            */
        }

        static void FuncaoDateTime()
        {
            /*
            Representa um instante.
            É um tipo valor (struct).

            Representação Interna
            - Um objeto DateTime internamente armazena:
              * O número de "ticks" (100 nanosegundos) desde a meia noite do dia 1 de janeiro do ano 1 da era comum.
            */

            DateTime d1 = DateTime.Now; // Pega o horário atual do sistema.

            Console.WriteLine(d1);
            Console.WriteLine(d1.Ticks); // Quantidade de ticks que passaram até o momento atual.

            /*
            Instanciação

            Construtores:
            - DateTime(ano, mes, dia)
            - DateTime(ano, mes, dia, hora, minuto, segundo)
            - DateTime(ano, mes, dia, hora, minuto, segundo, milissegundo)


            Builders:
            - DateTime.Now
            - DateTime.UtcNow
            - DateTime.Today
            - DateTime.Parse(string)
            - DateTime.ParseExact(string, string)
            */

            DateTime d2 = new DateTime(2018, 11, 25); // Instanciamos um DateTime do dia 25/11/2018 às 00:00.
            DateTime d3 = new DateTime(2018, 11, 25, 20, 45, 03); // Instanciamos um DateTime do dia 25/11/2018 às 20:45:03.
            DateTime d4 = new DateTime(2018, 11, 25, 20, 45, 03, 500); // Instanciamos um DateTime do dia 25/11/2018 às 20:45:03 (os milissegundos não são mostrados na formatação padrão).

            DateTime d5 = DateTime.Now; // Horário atual do sistema.
            DateTime d6 = DateTime.Today; // Data de hoje às 00:00.
            DateTime d7 = DateTime.UtcNow; // Igual ao .Now porém pegando o horário padrão GMT (de Greenwich).

            DateTime d8 = DateTime.Parse("2000-08-15"); // Converte uma string para data.
            DateTime d9 = DateTime.Parse("2000-08-15 13:05:58"); // Converte uma string para data.

            DateTime d10 = DateTime.Parse("15-08-2000"); // No formato do Brasil.
            DateTime d11 = DateTime.Parse("15-08-2000 13:05:58"); // No formato do Brasil.

            DateTime d12 = DateTime.ParseExact("2000-08-15", "yyyy-mm-dd", CultureInfo.InvariantCulture); // Este nos permite escolher qual formato exatamente nós queremos utilizar.
            DateTime d13 = DateTime.ParseExact("15/08/2000 13:05:58", "dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture); // Testando em outro formato.

            Console.WriteLine(d2);
            Console.WriteLine(d3);
            Console.WriteLine(d4);
            Console.WriteLine(d5);
            Console.WriteLine(d6);
            Console.WriteLine(d7);
            Console.WriteLine(d8);
            Console.WriteLine(d9);
            Console.WriteLine(d10);
            Console.WriteLine(d11);
            Console.WriteLine(d12);
            Console.WriteLine(d13);
        }
    }
}
