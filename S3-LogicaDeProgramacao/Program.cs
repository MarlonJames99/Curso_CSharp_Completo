using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Net;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace S3_LogicaDeProgramacao
{
    internal class Program
    {

        static void Main(string[] args)
        {
            
            TiposDeDados(); // Linha 79.
            SaidaDeDados(); // Linha 122.
            OperadoresDeAtribuicao(); // Linha 149.
            ConversaoImplicitaECasting(); // Linha 197.
            OperadoresAritmeticos(); // Linha 227.
            EntradaDeDados(); // Linha 277.
            OperadoresComparativos(); // Linha 327.
            OperadoresLogicos(); // Linha 358.
            EstruturasCondicionais(); // Linha 389.
            Escopo(); // Linha 441. 
            Funcoes(); // Linha 459.
            Debbuging(); // Linha 507.
            While(); // Linha 540.
            For(); // Linha 564.

            // Execução dos exercícios de fixação

            Ex1(); // Linha 591.
            Ex2(); // Linha 617.

            // Execução dos exercícios propostos 1 - Estrutura sequencial.

            ExP1(); // Linha 648.
            ExP2(); // Linha 664.
            ExP3(); // Linha 678.
            ExP4(); // Linha 703.
            ExP5(); // Linha 728.
            ExP6(); // Linha 755.

            // Execução dos exercícios propostos 2 - Estrutura condicional.

            ExP7(); // Linha 788.
            ExP8(); // Linha 805.
            ExP9(); // Linha 822.
            ExP10(); // Linha 844.
            ExP11(); // Linha 870.
            ExP12(); // Linha 914.
            ExP13(); // Linha 946.
            ExP14(); // Linha 992.

            // Execução dos exercícios propostos 3 - Estrutura de repetição "while".

            ExP15(); // Linha 1042.
            ExP16(); // Linha 1064.
            ExP17(); // Linha 1103.

            // Execução dos exercícios propostos 4 - Estrutura de repetição "for".

            ExP18(); // Linha 1154.
            ExP19(); // Linha 1167.
            ExP20(); // Linha 1199.
            ExP21(); // Linha 1224.
            ExP22(); // Linha 1254.
            ExP23(); // Linha 1274.
            ExP24(); // Linha 1290.

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

        static void EstruturasCondicionais()
        {
            /*
            if (condição) { comandos } - Uma condição que se for verdadeira executará os comandos em sequência.
            else if (condição 2/3/4...) { comandos } - Caso queiramos dar outras possibilidades (encadeamento) podemos criar outras condições com o comando "else if".
            else { comandos } - Este pode ser colocado ao final e basicamente será executado em caso de que nenhuma das condicionais anteriores tenha sido executada.

            Se o bloco condicional possuir apenas 1 comando a ser executado, o uso das {} se torna opcional.
            */

            // Simples

            int a = 10;

            if (a == 10)
            {
                Console.WriteLine("A variável vale 10!");
            }

            //Composta

            Console.WriteLine("Entre com um número inteiro: ");
            int x = int.Parse(Console.ReadLine());

            if (x % 2 == 0)
            {
                Console.WriteLine("Par!");
            }
            else
            {
                Console.WriteLine("Ímpar!");
            }

            // Encadeamentos

            Console.WriteLine("Qual a hora atual?");
            int hora = int.Parse(Console.ReadLine());

            if (hora < 12)
            {
                Console.WriteLine("Bom dia!");
            }
            else if (hora < 18)
            {
                Console.WriteLine("Boa tarde!");
            }
            else
            {
                Console.WriteLine("Boa noite!");
            }
        }

        static void Escopo()
        {
            /*
            O Escopo de uma variável é a região do programa onde a variável é válida, ou seja, onde ela pode ser referenciada.
            Uma variável não pode ser usada se não for iniciada.
            */ 

            double preco = double.Parse(Console.ReadLine());
            double desconto = 0.0;

            if (preco == 100.0)
            {
                desconto = preco * 0.1; // Aqui podemos utilizar as variáveis preco e desconto porque elas foram iniciadas no escopo maior (escopo da função).
            }                           

            Console.WriteLine(desconto); // Se elas houvessem sido iniciadas apenas dentro do if, não poderiamos exibi-la aqui no escopo principal.
        }

        static void Funcoes()
        {
            /*
            Representam um processamento que possui um significado.
            Math.Sqrt(double) - Usada para calcular a raiz quadrada de um número

            Vantagens: Modularização, delegação e reaproveitamento.

            Dados de entrada e saída:
            Funções podem receber dados de entrada (parâmetros ou argumentos)
            Funções podem ou não retornar uma saída.

            Em orientação à objetos, funções em classes recebem o nome de "métodos".
            */

            Console.WriteLine("Digite três números:");
            int n1 = int.Parse(Console.ReadLine());
            int n2 = int.Parse(Console.ReadLine());
            int n3 = int.Parse(Console.ReadLine());

            double resultado = Maior(n1, n2, n3);

            Console.WriteLine("Maior = " + resultado);            
        }

        static int Maior(int a, int b, int c) // Exercício atrelado ao conteúdos de "Funções" acima.
        {                                     // Aqui nós delegamos uma tarefa a uma função separada e apenas chamamos ela no "programa principal".
            
            // Fazer um programa para ler três números inteiros e mostrar na tela o maior deles.            

            int m;

            if (a > b && a > c)
            {
                m = a;
            }
            else if (b > c)
            {
                m = b;
            }
            else
            {
                m = c;
            }

            return m;
        }

        static void Debbuging() // No Visual Studio.
        {
            /*
            Com ele conseguimos acompanhar a execução do nosso programa indo passo a passo.
            Isso ajuda em situações em que nosso programa tenha um erro, ou esteja difícil de compreender. 
            
            Teclas:
            F9 - marcar/desmarcar breakpoint
            f5 - iniciar/continuar o debug
            f10 - Executar um passo (pula função)
            f11 - Executar um passo (entra na função)
            SHIFT+F11 - Sair do método em execução
            SHIFT+F5 - Parar debug

            Janelas: 
            Watch (expressões personalizadas)
            Autos (expressões "interessantes" detectadas pelo Visual Studio)
            Locals (variáveis locais)
            */

            Console.WriteLine("Digite um número"); // Apertar F9 para marcar o breakpoint e F10 para iniciar o debug
            int a = int.Parse(Console.ReadLine());
            
            if (a >= 0)
            {
                Console.WriteLine("O número é positivo");            
            }
            else
            {
                Console.WriteLine("O número é negativo");
            }
        }

        static void While() // Estrutura de repetição "enquanto".
        {
            // while ( condição ) { comandos } - A execução dos comandos seguirá se repetindo enquanto a condição resultar em verdadeira.

            /*
            Digitar um número e mostrar sua raiz quadrada com três casas decimais, depois repetir o procedimento.
            Quando o usuário digitar um número negativo (podendo inclusive ser na primeira vez), mostrar uma mensagem "número negativo" e terminar o programa.
            */

            Console.Write("Digite um número:");
            double a = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            while (a >= 0.000)
            {
                double raiz = Math.Sqrt(a);
                Console.WriteLine(raiz.ToString("F3", CultureInfo.InvariantCulture));

                Console.Write("Digite outro número:");
                a = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            }

            Console.WriteLine("Número negativo!");
        }

        static void For() // Estrutura de repetição "para".
        {
            // for  ( início; condição; incremento ) { comandos } - A execução dos comandos seguirá se repetindo enquanto a condição resultar em verdadeira.

            /*
            Utilizada principalmente quando você sabe quantas vezes os comandos precisarão serem repetidos, ou quando há uma contagem.
            Caso não se saiba quantas repetições serão necessárias, costuma ser melhor utilizar o "while".
            */

            // Digitar um número N e depois N valores inteiros. Mostrar a soma dos N valores digitados.

            Console.Write("Quantos números inteiros você vai digitar?");
            int N = int.Parse(Console.ReadLine());

            int soma = 0;

            for (int i = 1; i <= N; i++)
            {
                Console.Write("Valor #{0}: ", i);
                int valor = int.Parse(Console.ReadLine());
                soma += valor;
            }

            Console.WriteLine("Soma = " + soma);
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

        // PDF de Exercícios propostos 2 - Estrutura condicional
        static void ExP7()
        {
            // Fazer um programa para ler um número inteiro, e depois dizer se este número é negativo ou não.

            Console.WriteLine("Digite um número inteiro: ");
            int a = int.Parse(Console.ReadLine());

            if (a < 0)
            {
                Console.WriteLine("Negativo");
            }
            else
            {
                Console.WriteLine("Não negativo");
            }
        }

        static void ExP8()
        {
            // Fazer um programa para ler um número inteiro e dizer se este número é par ou ímpar

            Console.WriteLine("Digite um número inteiro:");
            int a = int.Parse(Console.ReadLine());

            if (a % 2 == 0)
            {
                Console.WriteLine("Par");
            }
            else 
            {
                Console.WriteLine("Ímpar");
            }
        }

        static void ExP9()
        {
            /*
            Leia 2 valores inteiros (A e B). Após, o programa deve mostrar uma mensagem "são multiplos" ou "não são multiplos", indicando se os valores lidos são múltiplos entre si.
            Os números devem poder ser digitados em ordem crescente ou decrescente.
            */

            Console.WriteLine("Digite dois valores:");
            string[] valores = Console.ReadLine().Split(' ');
            int A = int.Parse(valores[0]);
            int B = int.Parse(valores[1]);

            if (A % B == 0 || B % A == 0)
            {
                Console.WriteLine("São múltiplos");
            }
            else
            {
                Console.WriteLine("Não são múltiplos");
            }
        }

        static void ExP10()
        {
            /*
            Leia a hora inicial e a hora final de um jogo.
            A seguir calcule a duração do jogo, sabendo que o mesmo pode começar em um dia e terminar em outro, tendo uma duração mínima de 1 hora e máxima de 24 horas.
            */

            Console.WriteLine("Digite a hora inicial e final do jogo:");
            string[] hora = Console.ReadLine().Split(' ');
            int horaInicial = int.Parse(hora[0]);
            int horaFinal = int.Parse(hora[1]);

            int duracao;

            if (horaInicial < horaFinal)
            {
                duracao = horaFinal - horaInicial;
            }
            else
            {
                duracao = 24 - horaInicial + horaFinal;
            }

            Console.WriteLine($"O jogo durou {duracao} hora(s)");
        }

        static void ExP11()
        {
            /*
            Com base na tabela abaixo, escreva um programa que leia o código de um item e quantidade deste item. A seguir, calcule e mostre o valor da conta a pagar.

            Código          -            Especificação           -           Preço
              1                         Cachorro quente                      R$4.00
              2                            X-Salada                          R$4.50
              3                            X-Bacon                           R$5.00
              4                         Torrada simples                      R$2.00
              5                           Refrigerante                       R$1.50
            */

            Console.WriteLine("Digite o código e a quantidade do item:");
            string[] valores = Console.ReadLine().Split(' ');
            int codigo = int.Parse(valores[0]);
            int quantidade = int.Parse(valores[1]);

            double preco;

            if (codigo == 1)
            {
                preco = quantidade * 4.00;
            }
            else if (codigo == 2)
            {
                preco = quantidade * 4.50;
            }
            else if (codigo == 3)
            {
                preco = quantidade * 5.00;
            }
            else if (codigo == 4)
            {
                preco = quantidade * 2.00;
            }
            else
            {
                preco = quantidade * 1.50;
            }

            Console.WriteLine($"Total: R${preco.ToString("F2", CultureInfo.InvariantCulture)}");
        }

        static void ExP12()
        {
            /*
            Você deve fazer um programa que leia um valor qualquer e apresente uma mensagem dizendo em qual dos seguintes intervalos ([0,25], [25,50], [50,75], [75,100]) este valor está.
            Obviamente se o valor não estiver em nenhum destes intervalos, deverá ser impressa a mensagem "Fora do intervalo".
            */

            Console.WriteLine("Insira um valor:");
            double valor = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            if (valor < 0.00 || valor > 100.00)
            {
                Console.WriteLine("Fora de intervalo");
            }
            else if (valor <= 25)
            {
                Console.WriteLine("Intervalo [0,25]");
            }
            else if (valor <= 50)
            {
                Console.WriteLine("Intervalo [25,50]");
            }
            else if (valor <= 75)
            {
                Console.WriteLine("Intervalo [50,75]");
            }
            else
            {
                Console.WriteLine("Intervalo [75,100]");
            }
        }

        static void ExP13()
        {
            /*
            Leia 2 valores com uma casa decimal (x e y), que devem representar as coordenadas de um ponto em um plano. 
            A seguir, determine qual o quadrante ao qual pertence o ponto, ou se está sobre um dos eixos cartesianos ou na origem (x = y = 0).

            Se o ponto estiver na origem, escreva a mensagem "origem".

            Se o ponto estiver sobre um dos eixos escreve "Eixo X" ou "Eixo Y", conforme for a situação.
            */

            Console.WriteLine("Digite o valor de x e de y:");
            string[] valores = Console.ReadLine().Split(' ');
            double x = double.Parse(valores[0], CultureInfo.InvariantCulture);
            double y = double.Parse(valores[1], CultureInfo.InvariantCulture);

            if (x == 0 && y == 0)
            {
                Console.WriteLine("Origem");
            }
            else if (x == 0)
            {
                Console.WriteLine("Eixo Y");
            }
            else if (y == 0)
            {
                Console.WriteLine("Eixo X");
            }
            else if (x > 0 && y > 0)
            {
                Console.WriteLine("Q1");
            }
            else if (x < 0 && y > 0)
            {
                Console.WriteLine("Q2");
            }
            else if (x < 0 && y < 0)
            {
                Console.WriteLine("Q3");
            }
            else
            {
                Console.WriteLine("Q4");
            }
        }

        static void ExP14()
        {
            /*
            Em um país imaginário denominado Lisarb, todos os habitantes ficam felizes em pagar seus impostos, 
            pois sabem que nele não existem políticos corruptos e os recursos arrecadados são utilizados em benefício da população, sem qualquer desvio.
            A moeda deste páis é o Rombus, cujo símbolo é o R$.

            Leia um valor com duas casas decimais, equivalente ao salário de uma pessoa de Lisarb. 
            Em seguida, calcule e mostre o valor que esta pessoa deve pagar de Imposto de Renda, segundo a tabela abaixo.

                    Renda           -          Álíquota do Imposto
              de R$0.00 a R$2000.00                   Isento
            de R$2000.01 a R$3000.00                    8%
            de R$3000.01 a R$4500.00                    18%
               acima de R$4500.00                       28%
            */

            Console.WriteLine("Digite seu salário:");
            double salario = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            double imposto;

            if (salario <= 2000.00)
            {
                imposto = 0.00;
            }
            else if (salario <= 3000.00)
            {
                imposto = (salario - 2000.00) * 0.08;
            }
            else if (salario <= 4500.00)
            {
                imposto = (salario - 3000.00) * 0.18 + 1000.00 * 0.08;
            }
            else
            {
                imposto = (salario - 4500.00) * 0.28 + 1500.00 * 0.18 + 1000.00 * 0.08;
            }

            if (imposto == 0)
            {
                Console.WriteLine("Isento");
            }
            else
            {
                Console.WriteLine("R$" + imposto.ToString("F2", CultureInfo.InvariantCulture));
            }
        }

        // PDF de Exercícios propostos 3 - Estrutura de repetição "while"
        static void ExP15()
        {
            /*
            Escreva um programa que repita a leitura de uma senha até que ela seja válida.
            Para cada leitura de senha incorreta informada, escrever mensagem "Senha inválida". 
            Quando a senha for informada corretamente deve ser impressa a mensagem "Acesso permitido" e o algoritmo encerrado.
            Considere a senha correta como "2002".
            */

            Console.WriteLine("Digite a senha:");
            int senha = int.Parse(Console.ReadLine());

            while (senha != 2002)
            {
                Console.WriteLine("Senha inválida.");
                Console.WriteLine("Digite a senha novamente:");
                senha = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("Acesso permitido");
        }

        static void ExP16()
        {
            /*
            escreva um programa para ler as coordenadas (X,Y) de uma quantidade indeterminada de pontos no sistema cartesiano.
            Para cada ponto escrever o quadrante a que ele pertence. 
            O algoritmo será encerrado quando pelo menos uma de duas coordenadas for NULA (nesta situação sem escrever mensagem alguma).
            */

            Console.WriteLine("Digite o valor de X e Y:");
            string[] valores = Console.ReadLine().Split(' ');
            int x = int.Parse(valores[0]);
            int y = int.Parse(valores[1]);

            while (x != 0 && y != 0)
            {
                if (x > 0 && y > 0)
                {
                    Console.WriteLine("Primeiro");
                }
                else if (x < 0 && y > 0)
                {
                    Console.WriteLine("Segundo");
                }
                else if (x < 0 && y < 0)
                {
                    Console.WriteLine("Terceiro");
                }
                else
                {
                    Console.WriteLine("Quarto");
                }

                Console.WriteLine("Digite o valor de X e Y");
                valores = Console.ReadLine().Split(' ');
                x = int.Parse(valores[0]);
                y = int.Parse(valores[1]);
            }
        }

        static void ExP17()
        {
            /*
            Um posto de combustíveis deseja determinar qual de seus produtos tem a preferência de seus clientes.
            Escreva um algoritmo para ler o tipo de combustível abastecido (codificado da senguinte forma: 1.Álcool 2.Gasolina 3.Diesel 4.Fim).
            Caso o usuário informa um código inválido (fora da faixa de 1 a 4) deve ser solicitado um novo código (até que seja válido).
            O programa será encerrado quando o código informado for o número 4. 
            Deve ser escrito a mensagem: "Muito obrigado" e a quantidade de clientes que abasteceram cada tipo de combustível.
            */

            Console.WriteLine("Digite o código do produto:");
            int produto = int.Parse(Console.ReadLine());

            int alcool = 0;
            int gasolina = 0;
            int diesel = 0;

            while (produto != 4)
            {
                if (produto == 1)
                {
                    Console.WriteLine("Registrado!");
                    alcool += 1;
                }
                else if (produto == 2)
                {
                    Console.WriteLine("Registrado!");
                    gasolina += 1;
                }
                else if (produto == 3)
                {
                    Console.WriteLine("Registrado!");
                    diesel += 1;
                }

                if (produto < 1 || produto > 4)
                {
                    Console.WriteLine("Código inválido.");
                }

                Console.WriteLine("Digite o próximo código:");
                produto = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("Muito obrigado!");
            Console.WriteLine("Álcool: " + alcool);
            Console.WriteLine("Gasolina: " + gasolina);
            Console.WriteLine("Diesel: " + diesel);
        }

        // PDF de Exercícios propostos 4 - Estrutura de repetição "for"
        static void ExP18()
        {
            // Leia um valor inteiro X (1 <= X <= 1000). Em seguida mostre os ímpares de 1 até X, um valor por linha, inclusive o X, se for o caso.

            Console.WriteLine("Digite um valor:");
            int x = int.Parse(Console.ReadLine());

            for (int i = 1; i <= x; i += 2)
            {
                Console.WriteLine(i);
            }
        }

        static void ExP19()
        {
            /*
            Leia um valor inteiro N. Este valor será a quantidade de valores inteiros X que serão lidos em seguida.
            Mostre quantos destes valores X estão dentro do intervalo [10,20] e quantos estão fora do intervalo, 
            mostrando essas informações conforme exemplo (use a palavra "in" para dentro do intervalo, e "out" para fora do intervalo).
            */

            Console.WriteLine("Digite um a quantidade de números a serem lidos:");
            int N = int.Parse(Console.ReadLine());

            int In = 0;
            int Out = 0;

            for (int i = 1; i <= N; i++)
            {
                Console.WriteLine("Digite o próximo número");
                int x = int.Parse(Console.ReadLine());
                if (x >= 10 && x <= 20)
                {
                    In += 1;
                }
                else
                {
                    Out += 1;
                }
            }

            Console.WriteLine(In + " in");
            Console.WriteLine(Out + " out");
        }

        static void ExP20()
        {
            /*
            Leia 1 valor inteiro N, que representa o número de casos de teste que vem a seguir. 
            Cada caso de teste consiste de 3 valores reais, cada um deles com uma casa decimal.
            Apresente a média ponderada para cada um destes conjuntos de 3 valores, sendo que o primeiro valor tem peso 2, o segundo valor tem peso 3 e o terceiro valor tem peso 5.
            */

            Console.WriteLine("Digite a quantidade de casos de teste:");
            int N = int.Parse(Console.ReadLine());

            for (int i = 0; i < N; i++)
            {
                Console.WriteLine("Digite três valores reais");
                string[] valores = Console.ReadLine().Split(' ');
                double n1 = double.Parse(valores[0], CultureInfo.InvariantCulture);
                double n2 = double.Parse(valores[1], CultureInfo.InvariantCulture);
                double n3 = double.Parse(valores[2], CultureInfo.InvariantCulture);

                double media = (n1 * 2.0 + n2 * 3.0 + n3 * 5.0) / 10.0;

                Console.WriteLine("Média ponderada = " + media.ToString("F1", CultureInfo.InvariantCulture));
            }
        }

        static void ExP21()
        {
            /*
            Fazer um programa para ler um número N.
            Depois leia N pares de números e mostre a divisão do primeiro pelo segundo.
            Se o denominador for igual a zero, mostrar a mensagem "divisão impossível".
            */

            Console.WriteLine("Digite a quantidade de pares: ");
            int N = int.Parse(Console.ReadLine());

            for (int i = 0; i < N; i++)
            {
                Console.WriteLine("Digite dois valores: ");
                string[] valores = Console.ReadLine().Split(' ');
                int n1 = int.Parse(valores[0]);
                int n2 = int.Parse(valores[1]);

                if (n2 == 0)
                {
                    Console.WriteLine("Divisão impossível");
                }
                else
                {
                    double divisao = (double)n1 / n2;
                    Console.WriteLine(divisao.ToString("F1", CultureInfo.InvariantCulture));
                }
            }
        }

        static void ExP22()
        {
            /*
            Ler um valor N. Calcular e escrever seu respectivo fatorial. 
            Fatorial de N = N * (N-1) * (N-2) * (N-3) * ... * 1.;
            Lembrando que, por definição, fatorial de 0 é 1.
            */

            Console.WriteLine("Digite um valor");
            int N = int.Parse(Console.ReadLine());
            int fat = 1;

            for (int i = 1; i <= N; i++)
            {
                fat *= i;
            }

            Console.WriteLine("fatorial = " + fat);
        }

        static void ExP23()
        {
            // Ler um número inteiro N e calcular todos os seus divisores.

            Console.WriteLine("Digite um número inteiro:");
            int N = int.Parse(Console.ReadLine());

            for (int i = 1; i <= N; i++ )
            {
                if (N % i == 0)
                {
                    Console.WriteLine(i);
                }
            }
        }

        static void ExP24()
        {
            /*
            Fazer um programa para ler um número inteiro positivo N. O programa deve então mostrar na tela N linhas, começando de 1 até N. 
            Para cada linha, mostrar o número da linha, depois o quadrado e o cubo do valor.
            */

            Console.WriteLine("Digite um valor:");
            int N = int.Parse(Console.ReadLine());

            for (int i = 1; i <= N; i++)
            {
                int primeiro = i;
                int segundo = i * i;
                int terceiro = i * i * i;
                Console.WriteLine($"{primeiro} {segundo} {terceiro}");
            }
                
        }
    }
}
