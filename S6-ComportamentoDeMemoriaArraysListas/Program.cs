using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Net.Http.Headers;
using System.Xml;
using System.Collections.Specialized;

namespace S6_ComportamentoDeMemoriaArraysListas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            TipoReferenciaEValor(); // Linha .
            DesalocacaoDeMemoria(); // Linha .
            Nullable(); // Linha .
            Vetores(); // Linha .
            
            // Exercícios de fixação

            Ex1(); // Linha .

            Console.ReadLine();
        }

        static void TipoReferenciaEValor()
        {
            /*
            Classes são tipos referência

            Variáveis cujo tipo são classes não devem ser entendidas como caixas, mas sim "tentáculos" (ponteiros) para caixas.

            Ex: Product p1, p2;

            Quando criamos variáveis dessa forma nós criamos uma referência no "stack" da nossa memória, que, quando estanciarmos objeto: 
            p1 = new Product("TV", 900.00, 0);

            Criamos então um registro no "heap" da memória com os valores instanciados, 
            e a variável criada anteriormente armazenará apenas um "endereço" que aponta para este local de memória.

            Valor "null"

            Tipos referência aceitam o valor "null", que indica que a variável aponta pra ninguém.
            */

            /*
            Structs são tipos valor

            A linguagem C# possui também tipos valor, que são os "structs". Structs são caixas e não ponteiros.

            Ex: double x, y;

            os tipos valor no C# são os tipos básicos da linguagem, como int, float, double, bool, etc.

            Nota: Enquanto os tipo referência criam um registro de memória que aponta para a caixa que realmente contém o valor. 
            O tipo valor cria diretamente essa caixa e armazena o valor atribuido a ela.

            Nós podemos criar nossos próprios tipo valor, exemplo na classe "point.cs".

            Valores padrão

            Quando alocamos (new) qualquer tipo estruturado (classe, struct, array), são atribuídos valores padrão aos seus elementos.
            - números: 0
            - bool: false
            - char: caractere código 0
            - objeto: null

            Lembrando: uma variável apenas declarada, mas não instanciada, inicia em estado "não atribuída", e o próprio compilador não permite que ela seja acessada.
            */

            Point p;
            p.X = 10;
            p.Y = 20;

            Console.WriteLine(p);

            p = new Point();

            Console.WriteLine(p);
        }

        static void DesalocacaoDeMemoria()
        {
            /*
            Garbage collector:

            - É um processo que automatiza o gerenciamento de memória de um programa em execução.
            - O garbage collector monitora os objetos alocados dinamicamente pelo programa (no heap), desalocando aqueles que não estão mais sendo utilizados.

            Desalocação por escopo:

            - Quando a execução do programa entra em um novo escopo, como de um "if" ou um "while", ele aloca as variáveis presentes nesse escopo na mémória, 
            porém quando a execução do programa sai daquele escopo, automaticamente esses valores são desalocados da memória.

            Resumindo:
            - Objetos alocados dinamicamente, quando não possuem mais referência para eles, serão desalocados pelo garbage collector.
            - Variáveis locais são desalocadas imediatamente assim que seu escopo sai de execução.
            */

            // Exemplo de uso do garbage collector

            Point p1, p2;

            p1.X = 10;
            p1.Y = 20;

            p2.X = 30;
            p2.Y = 40;

            /*
            Aqui ele criou o objeto "p1" tendo os valores 10 e 20.
            E logo o objeto "p2" tendo os valores 30 e 40.

            esses dois objetos são criados no Heap da memória com uma referência para si no Stack sendo elas "p1" e "p2".
            */

            p1 = p2;

            /*
            Aqui ele faz com que o "p1" passe a apontar agora para o objeto com valores 30 e 40 e não mais para o objeto com valores 10 e 20, 
            sendo assim este objeto já não possui mais nenhuma referência e por isso ele será desalocado da memória pelo garbage collector futuramente.
            */

            // Exemplo de desalocação por escopo

            void method1()
            {
                int x = 10;
                if (x > 0)
                {
                    int y = 20;
                    Console.WriteLine(y);
                }
                Console.WriteLine(x);
            }
            method1();

            // Neste exemplo o valor de y = 20 só será alocado na memória durante a execução do "if", após essa execução, será novamente desalocado.

            // Exemplo 2

            void method2()
            {
                Point P1 = method3();
                Console.WriteLine(P1.X + P1.Y);
            }

            Point method3()
            {
                Point P2 = new Point();
                P2.X = 10;
                P2.Y = 20;
                return P2;
            }

            method2();

            /*
            Neste exemplo, ao executar o "method3()", será criado um objeto com os valores declarados no Heap da memória com a referência "P2" no Stack.
            Ao terminar sua execução a referência "P2" será desalocada e a referência "P1" passará a apontar para o objeto que foi criado e retornado pelo "method3()"
            */
        }

        static void Nullable()
        {
            /*
            É um recurso do C# para que dados de tipo valor (structs) possam receber o valor null.

            Uso comum:
            - Campos de banco de dados que podem valer nulo (data de nascimento, algum valor numérico, etc.).
            - Dados e parâmetros opcionais.

            Operações padrão do Nullable

            Métodos: 
            - GetValueOrDefault
            - HasValue
            - Value (lança uma exceção se não houver valor)

            Um nullable não pode ser atribuído para um struct comum.
            */

            double? x = null; // É o mesmo que "Nullable<double> x = null;"
            double? y = 10.0;

            Console.WriteLine(x.GetValueOrDefault()); // Traz o valor da variável, e se não existir, traz o valor padrão do seu tipo.
            Console.WriteLine(y.GetValueOrDefault());

            Console.WriteLine(x.HasValue); // Traz resposta true ou false para indicar se tem ou não um valor.
            Console.WriteLine(y.HasValue);

            if (x.HasValue) // Com essa condição controlamos para que só execute o código abaixo caso o valor de "x" não seja nulo.
            {
                Console.WriteLine(x.Value); // Ao chamar o "value" de uma variável com valor nulo, recebemos um exception (erro).
            }
            else
            {
                Console.WriteLine("X is null");
            }

            if (y.HasValue) 
            {
                Console.WriteLine(y.Value); 
            }
            else
            {
                Console.WriteLine("Y is null");
            }

            // Operador de coalescência nula

            double? a = null;
            double b = a ?? 10.0; // O que isso faz é, caso o valor de "a" não for nulo, joga seu valor para "b", caso ele seja nulo, então joga o outro valor, neste caso "10.0".

            Console.WriteLine(b);
        }

        static void Vetores() // Arrays
        {
            /*
            Em programação, "vetor" é o nome dado a arranjos unidimensionais.

            Arranjo (array) é uma estrutura de dados:
            - Homogênea (dados do mesmo tipo)
            - Ordenada (elementos acessados por meio de posições)
            - Alocada de uma vez só, em um bloco contíguo de memória

            Vantagens:
            - Acesso imediato aos elementos pela sua posição

            Desvantagens:
            - Tamanho fixo
            - Dificuldade para se realizar inserções e delegações
            */

            /*
            Problema exemplo 1

            Fazer um programa para ler um número inteiro N e a altura de N pessoas.
            Armazene as N alturas em um vetor. Em seguida, mostrar a altura média dessas pessoas.
            */
            
            Console.WriteLine("Vamos calcular a altura média de quantas pessoas?");
            int n = int.Parse(Console.ReadLine());

            double[] alturas = new double[n]; // Vetor de struct

            for (int i = 0; i < n; i++) // usamos o "i" como o "index" do vetor fazendo com que ele adicione os valores selecionados na posição correta dentro do vetor.
            {
                Console.Write("Digite a altura da próxima pessoa: ");
                alturas[i] = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            }

            double soma = 0.0;

            for (int i = 0; i < n; i++)
            {
                soma += alturas[i];
            }

            double avg = soma / n;

            Console.WriteLine("Altura média = " + avg.ToString("F2", CultureInfo.InvariantCulture));
            
            /*
            Problema exemplo 2

            Fazer um programa para ler um número inteiro N e os dados (nome e preço) de N produtos. Armazene os N produtos em um vetor.
            Em seguida, mostrar o preço médio dos produtos.
            */

            Console.WriteLine("Quantos produtos iremos registrar?");
            int N = int.Parse(Console.ReadLine());

            Produto[] vect = new Produto[N]; // Vetor de classe 

            for (int i = 0; i < N; i++)
            {
                Console.Write("Digite o nome do produto: ");
                string nome = Console.ReadLine();
                Console.Write("Digite o preço do produto: ");
                double preco = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                vect[i] = new Produto { Nome = nome, Preco = preco }; // Recebemos os valores digitados pelo usuário e depois instanciamos um produto com estes valores.
            }                                                         // Armazenando-o dentro do vetor na posição "i".

            double sum = 0.0;

            for ( int i = 0; i < N; ++i )
            {
                sum += vect[i].Preco;
            }

            double media = sum / N;
            Console.WriteLine("Preço médio = " + media.ToString("F2", CultureInfo.InvariantCulture));
        }

        // Exercícios de fixação

        static void Ex1()
        {
            /*
            A dona de um pensionato possui dez quartos para alugar para estudantes, sendo esses quartos identificados pelos números 0 a 9.

            Fazer um programa que inicie com todos os dez quartos vazios, 
            e depois leia uma quantidade N representando o número de estudantes que vão alugar quartos (N pode ser de 1 a 10).
            Em seguida, registre o aluguel dos N estudantes. Para cada registro de aluguel, informar o nome e email do estudante, 
            bem como qual dos quartos ele escolheu (de 0 a 9). Suponha que seja escolhido um quarto vago. 
            Ao final, seu programa deve imprimir um relatório de todas as ocupações do pensionato, por ordem de quarto.
            */

            Quarto[] quartos = new Quarto[10];

            Console.Write("Quantos quartos serão alugados? ");
            int N = int.Parse(Console.ReadLine());

            for (int i = 1; i <= N; ++i)
            {
                Console.WriteLine();
                Console.WriteLine($"Aluguel #{i}:");
                Console.Write("Nome: ");
                string nome = Console.ReadLine();
                Console.Write("Email: ");
                string email = Console.ReadLine();
                Console.Write("Quarto: ");
                int quarto = int.Parse(Console.ReadLine());
                quartos[quarto] = new Quarto { Email = email, Nome = nome };
            }

            Console.WriteLine();
            Console.WriteLine("Quartos ocupados:");

            for (int i = 0; i < 10; i++)
            {
                if (quartos[i] != null)
                {
                    Console.WriteLine(i + ": " + quartos[i]);
                }
            }
        }
    }
}
