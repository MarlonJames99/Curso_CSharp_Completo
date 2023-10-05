using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S3_LogicaDeProgramacao
{
    internal class Program
    {

        static void Main(string[] args)
        {

            TiposDeDados(); // Linha .
            SaidaDeDados(); // Linha .
            OperadoresDeAtribuicao(); // Linha .
            ConversaoImplicitaECasting(); // Linha .
            OperadoresAritmeticos(); // Linha .

            // Execução dos exercícios de fixação

            Ex1();

            Console.ReadLine();
        }

        static void TiposDeDados()
        {
            // Tipos de dados do C# - Não são todos, mas são os maios usados.

            sbyte x = 100; //Também pode ser SByte por ser a escrita usada no .Net Framework, incluido no "System". -128 a 127.
            byte n1 = 126; // não aceita número negativo. 0 a 255.
            int n2 = 1000;
            int n3 = 2147483647; // Valor máximo aceito no tipo int.
            long n4 = 2147483648L; // Permite números ainda maiores que o int, é recomendado colocar o L no final pra indicar que é do tipo long.
            bool completo = false;
            char genero = 'f'; // character deve ser colocado entre aspas simples.
            char letra = '\u0041'; // Usando código unicode podemos representar qualquer caracter existente.
            float n5 = 4.5f; // Float deve ter a letra f no final do número.
            double n6 = 4.6;
            string nome = "Maria"; // String requer uso de aspas duplas.
            object obj1 = "MJRC"; // Tipo genérico.

            // Podemos pegar o menor e o maior valor de um tipo de dado usando as propriedades MinValue e MaxValue.

            int n7 = int.MinValue;
            int n8 = int.MaxValue;
            sbyte n9 = sbyte.MinValue;
            decimal n10 = decimal.MaxValue;

            Console.WriteLine(n7);
            Console.WriteLine(n8);
            Console.WriteLine(n9);
            Console.WriteLine(n10);
        }

        static void SaidaDeDados()
        {
            char genero = 'F';
            int idade = 24;
            double saldo = 10.35679;
            string nome = "Maria";


            Console.Write("Bom dia!"); // Não pula linha ao final
            Console.WriteLine("Boa tarde!"); // Pula linha ao final
            Console.WriteLine("Boa noite!");
            Console.WriteLine(genero);
            Console.WriteLine(idade);
            Console.WriteLine(saldo);
            Console.WriteLine(nome);
            Console.WriteLine(saldo.ToString("F2")); // F2 faz com que tenha somente duas casas decimais, arredondando o valor. Se quisesse 3 casas usaria F3...
            Console.WriteLine(saldo.ToString("F2", CultureInfo.InvariantCulture)); // Faz com que os decimais sejam separados com "." e não "," pois remove a regionalização.

            // Placehoolders, concatenação e interpolação.

            Console.WriteLine("{0} tem {1} anos e tem saldo igual a {2:F2} reais.", nome, idade, saldo); // Placeholder

            Console.WriteLine($"{nome} tem {idade} anos e tem saldo igual a {saldo:F2} reais."); // Interpolação

            Console.WriteLine(nome + " tem " + idade + " anos e tem saldo igual a " + saldo.ToString("F2", CultureInfo.InvariantCulture) + " reais."); // Concatenação
        }

        static void OperadoresDeAtribuicao()
        {

            int x = 10; // isso é dizer que o "x" recebe "10". o operador "=" serve para atribuir um valor a uma variável.
            x += 2; // "x" recebe x + 2. Receberá o próprio valor de "x" somando 2. O mesmo que escrever "x = x + 2".
            x -= 2; // "x" recebe x - 2. Receberá o valor de "x" subtraindo 2. O mesmo que escrever "x = x - 2".
            x *= 2; // "x" recebe x * 2. Receberá o valor de "x" multiplicado por 2. O mesmo que escrever "x = x * 2".
            x /= 2; // "x" recebe x / 2. Receberá o valor de "x" dividido por 2. O mesmo que escrever "x = x / 2".
            x %= 3; // "x" recebe x % 3. Receberá o valor do módulo de "x". O mesmo que escrever "x = x % 3". 

            Console.WriteLine(x);

            int a = 10;
            Console.WriteLine(a);

            a += 2;
            Console.WriteLine(a);

            a *= 3;
            Console.WriteLine(a);

            string s = "ABC";
            Console.WriteLine(s);

            s += "DEF";
            Console.WriteLine(s); // Concatenação cumulativa de strings.

            int b = 10; 
            b++; // "b" recebe o valor de "b" + 1. Também podemos usar "++b" 
            Console.WriteLine(b);

            int c = 10;
            c--; // "c" recebe o valor de "c" - 1. Também podemos usar "--c"
            Console.WriteLine(c);

            // ao utilizar ++a ou a++ a unica diferença é a ordem de execução que pode ocasionar em diferenças ao atribuir este valor a outra variável, como no exemplo abaixo.

            int d = 10;
            int e = d++;
            Console.WriteLine(d);
            Console.WriteLine(e);

            /*
            A variável "d" recebe o efeito do "++" e passa a valer 11, porém a variável "e" recebe o valor de "d" antes dele ser incrementado, ficando assim com o valor "10".
            Isso não ocorreria se usássemos "++d"
            */
        }

        static void ConversaoImplicitaECasting()
        {
            float x = 4.5f;
            double y = x; /* Aqui ocorre uma conversão implícita de float para double e isso é possível porque float possui 4 bytes, e double possui 8 bytes.
                             O que significa que um conteúdo float cabe perfeitamente em uma variável do tipo double. */

            double a;
            float b;

            a = 5.1;
            b = (float)a; /* Aqui a situação contrária não funciona pois como o tipo double é maior que o tipo float e portanto um conteúdo double não encaixa em uma variável float.
            Podemos "forçar" essa conversão caso queiramos, mas corremos o risco de que se perca informação. Para isso, utilizamos o casting. isso é feito colocando o "(float)". */
            Console.WriteLine(b);

            double c;
            int d;

            c = 5.1;
            d = (int)c; /* Neste caso além da questão do tamanho em bytes de int ser menor que double, também ocorre o problema de que int não aceita número decimal, e double sim.
                           Neste caso houve perda de informação pois o valor atribuído a "d" é 5 e não 5.1 */
            Console.WriteLine(d);

            int e = 5;
            int f = 2;

            double resultado = (double)e / f;
            Console.WriteLine(resultado); /* Neste caso, sem o casting o resultado seria 2 pois ele faz a divisão apenas considerando os valores "int".
                                             Para não perdermos as casas decimais no resultado devemos usar o casting. */
        }

        static void OperadoresAritmeticos()
        {
            /* 
            Adição (+)
            Subtração (-)
            Multiplicação (*)
            Divisão (/)
            Resto da divisão, também chamado de mod (%)

            Assim como na matemática tradicional, a *, / e % possuem prioridade na ordem do cálculo em relação à + e -.
            Se quisermos dar prioridade a uma determinada operação devemos colocar entre ().
            */

            int n1 = 3 + 4 * 2;
            int n2 = (3 + 4) * 2;

            Console.WriteLine(n1);
            Console.WriteLine(n2);

            int n3 = 17 % 3; // 17/3 é igual a 5 e sobram 2. O resto da divisão é 2.
            Console.WriteLine(n3);

            /* 
            Se realizarmos uma operação entre números inteiros e o resultado for um número com casas decimais, o compilador só irá retornar o resultado inteiro.
            Isso ocorre pois como ambos números são inteiros ele entende que queremos realizar uma operação do tipo inteiro.
            Para resolver isso podemos utilizar o casting ou formatar um dos números com casas decimais
            */

            double n4 = 10 / 8;
            double n5 = 10.0 / 8; // No mínimo um dos dois números deve ter casas decimais (.0), não é obrigatório que ambos tenham.
            double n6 = (double) 10 / 8;

            Console.WriteLine(n4);
            Console.WriteLine(n5);
            Console.WriteLine(n6);

            // Cálculo da fórmula de Bhaskara

            double a = 1.0, b = -3.0, c = -4.0;

            double delta = Math.Pow(b, 2.0) - 4.0 * a * c; // A função "Math.Pow" é usada para cálculo de potência, no qual o primeiro número é a base e o segundo é o expoente.

            double x1 = (-b + Math.Sqrt(delta)) / (2.0 * a); // A função "Math.Sqrt" é usada para extrair a raiz quadrada de algo.
            double x2 = (-b - Math.Sqrt(delta)) / (2.0 * a);

            Console.WriteLine(delta);
            Console.WriteLine(x1);
            Console.WriteLine(x2);
        }

        // Exercícios de fixação
        static void Ex1() // Exercício de saída de dados.
        {
            string produto1 = "Computador";
            string produto2 = "Mesa de escritório";

            byte idade = 24;
            int codigo = 5290;
            char genero = 'M';

            double preco1 = 2100.0;
            double preco2 = 650.50;
            double medida = 53.234567;

            Console.WriteLine("Produtos:");
            Console.WriteLine($"{produto1}, cujo preço é ${preco1:F2}");
            Console.WriteLine($"{produto2}, cujo preço é ${preco2:F2}\n");
            Console.WriteLine($"Registro: {idade} anos de idade, código {codigo} e gênero: {genero}\n");
            Console.WriteLine($"Medida com oito casas decimais: {medida:F8}");
            Console.WriteLine($"Arredondado (três casas decimais): {medida:F3}");
            Console.WriteLine("Separador decimal invariant culture: " + medida.ToString("F3", CultureInfo.InvariantCulture));
        }
    }
}
