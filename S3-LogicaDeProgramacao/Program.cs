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
            EntradaDeDados(); // Linha .
            OperadoresComparativos(); // Linha .
            OperadoresLogicos(); // Linha .

            // Execução dos exercícios de fixação

            Ex1();
            Ex2();

            // Execução dos exercícios propostos 1 - Entrada de dados.

            ExP1();
            ExP2();
            ExP3();
            ExP4();
            ExP5();
            ExP6();

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

            Console.WriteLine(x);
            Console.WriteLine(n1);
            Console.WriteLine(n2);
            Console.WriteLine(n3);
            Console.WriteLine(n4);
            Console.WriteLine(completo);
            Console.WriteLine(genero);
            Console.WriteLine(letra);
            Console.WriteLine(n5);
            Console.WriteLine(n6);
            Console.WriteLine(nome);
            Console.WriteLine(obj1);

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

        static void EntradaDeDados()
        {
            /* 
            Aqui vemos a entrada de dados a partir do uso do teclado do usuário. 
            Ele lê desdo a entrada padrão a té a quebra de linha.
            Retorna os dados em formato de string. 
            */

            // Parte 1.
            string frase = Console.ReadLine();
            string x = Console.ReadLine();
            string y = Console.ReadLine();
            string z = Console.ReadLine();

            string[] v = Console.ReadLine().Split(' '); // Realiza um split entre as palavras digitadas utilizando o ' ' como ponto de separação, e armazena no vetor "v".
            string a = v[0]; // Aqui estou definindo que o dado armazenado na posição 0 do vetor "v" será armazenado na variável "a".
            string b = v[1];
            string c = v[2];

            Console.WriteLine("Você digitou: ");
            Console.WriteLine(frase);
            Console.WriteLine(x);
            Console.WriteLine(y);
            Console.WriteLine(z);
            Console.WriteLine(a);
            Console.WriteLine(b);
            Console.WriteLine(c);

            // Parte 2.

            int n1 = int.Parse(Console.ReadLine()); // int.Parse converte o dado recebido para o tipo "int".
            char ch = char.Parse(Console.ReadLine());
            double n2 = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture); // Desta forma podemos informar o número double separado por "." em lugar da ",".

            string[] vet = Console.ReadLine().Split(' ');
            string nome = vet[0];
            char sexo = char.Parse(vet[1]);
            int idade = int.Parse(vet[2]);
            double altura = double.Parse(vet[3], CultureInfo.InvariantCulture);

            Console.WriteLine("Você digitou: ");
            Console.WriteLine(n1);
            Console.WriteLine(ch);
            Console.WriteLine(n2.ToString("F2", CultureInfo.InvariantCulture)); // Fazemos com que o número double venha com o "." como separador.
            Console.WriteLine(nome);
            Console.WriteLine(sexo);
            Console.WriteLine(idade);
            Console.WriteLine(altura.ToString("F2", CultureInfo.InvariantCulture));
        }

        static void OperadoresComparativos()
        {
            /*
            > - Maior
            < - Menor
            >= - Maior ou igual
            <= - Menor ou igual
            == - Igual
            != - Diferente
            */

            int a = 10;
            bool c1 = a < 10;
            bool c2 = a < 20;
            bool c3 = a > 10;
            bool c4 = a > 5;
            bool c5 = a <= 10;
            bool c6 = a >= 10;
            bool c7 = a == 10;
            bool c8 = a != 10;

            Console.WriteLine(c1);
            Console.WriteLine(c2);
            Console.WriteLine(c3);
            Console.WriteLine(c4);
            Console.WriteLine(c5);
            Console.WriteLine(c6);
            Console.WriteLine(c7);
            Console.WriteLine(c8);
        }

        static void OperadoresLogicos()
        {
            /*
            && - E - Esta condicional só resulta em verdadeira quando ambas as condições são verdadeiras (v e v = v), em qualquer outro caso resultará em false.
            || - Ou - Esta condicional resultará em verdadeira caso ao menos 1 das condições seja verdadeira (v ou f = v), só será false caso ambas condições sejam false. 
            ! - Não

            Os operadores possuem ordem de prioridade na execução, seguindo a seguinte ordem: ! > && > ||
            Podem-se usar os () para lidar com a questão da prioridade na execução.
            */

            bool c1 = 2 > 3 && 4 != 5;
            bool c2 = 2 > 3 || 4 != 5;

            Console.WriteLine(c1);
            Console.WriteLine(c2);

            bool c3 = 2 > 3 || 4 != 5; // True
            bool c4 = !(2 > 3) && 4 != 5; // True

            Console.WriteLine(c3);
            Console.WriteLine(c4);

            bool c5 = 10 < 5; // False
            bool c6 = c3 || c4 && c5; // True
                                      // Primeiro foi resolvido o && (que deu false) depois se resolveu o || (que deu true).

            Console.WriteLine(c5);
            Console.WriteLine(c6);  
        }

        // Exercícios de fixação
        static void Ex1() // Exercício de saída de dados.
        {
            // Fazer um programa e iniciar as seguintes variáveis: 

            string produto1 = "Computador";
            string produto2 = "Mesa de escritório";

            byte idade = 24;
            int codigo = 5290;
            char genero = 'M';

            double preco1 = 2100.0;
            double preco2 = 650.50;
            double medida = 53.234567;

            // Em seguida, usando os valores das variáveis, produza a seguintes saída na tela do console:

            Console.WriteLine("Produtos:");
            Console.WriteLine($"{produto1}, cujo preço é ${preco1:F2}");
            Console.WriteLine($"{produto2}, cujo preço é ${preco2:F2}\n");
            Console.WriteLine($"Registro: {idade} anos de idade, código {codigo} e gênero: {genero}\n");
            Console.WriteLine($"Medida com oito casas decimais: {medida:F8}");
            Console.WriteLine($"Arredondado (três casas decimais): {medida:F3}");
            Console.WriteLine("Separador decimal invariant culture: " + medida.ToString("F3", CultureInfo.InvariantCulture));
        }

        static void Ex2() // Exercício de entrada de dados.
        {
            /*
            Fazer um programa para ler os dados, nome completo, quantidade de quartos, preço de algum produto além de último nome, idade e altura (estes em apenas uma linha).
            e depois mostrar os dados na tela.
            */
            
            Console.WriteLine("Entre com seu nome completo: ");
            string nome = Console.ReadLine();

            Console.WriteLine("Quantos quartos tem na sua casa? ");
            int quartos = int.Parse(Console.ReadLine());

            Console.WriteLine("Entre com o preço de um produto ");
            double preco = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.WriteLine("Entre com seu último nome, idade e altura (mesma linha): ");
            string[] v = Console.ReadLine().Split(' ');
            string ultimoNome = v[0];
            int idade = int.Parse(v[1]);
            double altura = double.Parse(v[2], CultureInfo.InvariantCulture);

            Console.WriteLine(nome);
            Console.WriteLine(quartos);
            Console.WriteLine(preco.ToString("F2", CultureInfo.InvariantCulture));
            Console.WriteLine(ultimoNome);
            Console.WriteLine(idade);
            Console.WriteLine(altura.ToString("F2", CultureInfo.InvariantCulture));
        }

        // PDF de Exercícios propostos 1 - Estrutura senquencial
        static void ExP1()
        {
            // Faça um programa para ler dois valores inteiros, e depois mostrar na tela a soma desses números com uma mensagem explicativa.

            int a, b, soma;

            Console.WriteLine("Entre com o primeiro valor: ");
            a = int.Parse(Console.ReadLine());
            Console.WriteLine("Entre com o segundo valor: ");
            b = int.Parse(Console.ReadLine());

            soma = a + b;

            Console.WriteLine("SOMA = " + soma);
        }

        static void ExP2()
        {
            // Faça um programa para ler o valor do raio de um círculo, e depois mostrar o valor da área deste círculo com quatro casas decimais.

            double R, A, PI = 3.14159;

            Console.WriteLine("Entre com o valor do raio: ");
            R = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            A = PI * Math.Pow(R, 2.0);

            Console.WriteLine("A=" + A.ToString("F4", CultureInfo.InvariantCulture));
        }

        static void ExP3()
        {
            /*
            Fazer um programa para ler quatro valores inteiros A, B, C e D. A seguir, calcule e mostre a diferença do produto 
            de A e B pelo produto de C e D segundo a fórmula: DIFERENCA = (A * B - C * D).
            */

            int A, B, C, D, diferenca;

            Console.WriteLine("Digite o primeiro valor: ");
            A = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o segundo valor: ");
            B = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o terceiro valor: ");
            C = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o quarto valor: ");
            D = int.Parse(Console.ReadLine());

            diferenca = A * B - C * D;
            Console.WriteLine("DIFERENÇA = " + diferenca);
        }

        static void ExP4()
        {
            /*
            Fazer um programa que leia o número de um funcionário, seu número de horas trabalhadas, o valor que recebe por
            hora e calcula o salário desse funcionário. A seguir, mostre o número e o salário do funcionário, com duas casas decimais. 
            */

            int idFuncionario, horasTrabalhadas;
            double salarioHora, salario;

            Console.WriteLine("Qual o ID do funcionário? ");
            idFuncionario = int.Parse(Console.ReadLine());

            Console.WriteLine("Quantas horas o funcionário trabalhou? ");
            horasTrabalhadas = int.Parse(Console.ReadLine());

            Console.WriteLine("Quanto o funcionário recebe por hora? ");
            salarioHora = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            salario = horasTrabalhadas * salarioHora;

            Console.WriteLine("ID do Funcionário: " + idFuncionario);
            Console.WriteLine("Salário: R$" + salario.ToString("F2", CultureInfo.InvariantCulture));
        }

        static void ExP5()
        {
            /*
            Fazer um programa para ler o código de uma peça 1, o número de peças 1, o valor unitário de cada peça 1, o
            código de uma peça 2, o número de peças 2 e o valor unitário de cada peça 2. Calcule e mostre o valor a ser pago.
            */

            int peca1, peca2, qtdPeca1, qtdPeca2;
            double precoPeca1, precoPeca2, valorTotal;

            Console.WriteLine("Digite o código, a quantidade e o preço da peça: ");
            string[] valores = Console.ReadLine().Split(' ');
            peca1 = int.Parse(valores[0]);
            qtdPeca1 = int.Parse(valores[1]);
            precoPeca1 = double.Parse(valores[2], CultureInfo.InvariantCulture);

            Console.WriteLine("Digite o código, a quantidade e o preço da peça: ");
            valores = Console.ReadLine().Split(' ');
            peca2 = int.Parse(valores[0]);
            qtdPeca2 = int.Parse(valores[1]);
            precoPeca2 = double.Parse(valores[2], CultureInfo.InvariantCulture);

            valorTotal = qtdPeca1 * precoPeca1 + qtdPeca2 * precoPeca2;

            Console.WriteLine("Valor a pagar: R$" + valorTotal.ToString("F2", CultureInfo.InvariantCulture));
        }

        static void ExP6()
        {
            /*
            Fazer um programa que leia três valores com ponto flutuante de dupla precisão: A, B e C. Em seguida, calcule e mostre:
            a) a área do triângulo retângulo que tem A por base e C por altura.
            b) a área do círculo de raio C. (pi = 3.14159)
            c) a área do trapézio que tem A e B por bases e C por altura.
            d) a área do quadrado que tem lado B.
            e) a área do retângulo que tem lados A e B.
            */

            double A, B , C, areaTriangulo, areaCirculo, areaTrapezio, areaQuadrado, areaRetangulo, PI = 3.14159;

            Console.WriteLine("Digite 3 valores: ");
            string[] v = Console.ReadLine().Split(' ');
            A = double.Parse(v[0], CultureInfo.InvariantCulture);
            B = double.Parse(v[1], CultureInfo.InvariantCulture);
            C = double.Parse(v[2], CultureInfo.InvariantCulture);

            areaTriangulo = A * C / 2.0;
            areaCirculo = PI * Math.Pow(C, 2.0);
            areaTrapezio = (A + B) * C / 2;
            areaQuadrado = Math.Pow(B, 2.0);
            areaRetangulo = A * B;

            Console.WriteLine("Triângulo: " + areaTriangulo.ToString("F3", CultureInfo.InvariantCulture));
            Console.WriteLine("Círculo: " + areaCirculo.ToString("F3", CultureInfo.InvariantCulture));
            Console.WriteLine("Trapézio: " + areaTrapezio.ToString("F3", CultureInfo.InvariantCulture));
            Console.WriteLine("Quadrado: " + areaQuadrado.ToString("F3", CultureInfo.InvariantCulture));
            Console.WriteLine("Retângulo: " + areaRetangulo.ToString("F3", CultureInfo.InvariantCulture));
        }
    }
}
