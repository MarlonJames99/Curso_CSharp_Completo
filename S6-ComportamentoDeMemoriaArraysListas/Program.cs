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
            
            TipoReferenciaEValor(); // Linha 38.
            DesalocacaoDeMemoria(); // Linha 94.
            Nullable(); // Linha 176.
            Vetores(); // Linha 230.
            ModificadorDeParametrosParams(); // Linha 309.
            ModificadorDeParametrosRefOut(); // Linha 317.
            BoxingUnboxing(); // Linha 341.
            LaçoForEach(); // Linha 356.
            Listas(); // Linha 369.
            Matrizes(); // Linha 466.

            // Exercícios de fixação

            Ex1(); // Linha 556.
            Ex2(); // Linha 598.
            Ex3(); // Linha 661.

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

        static void ModificadorDeParametrosParams()
        {
            // Params é utilizado para que possamos definir o vetor para que possa receber um número variável de elementos, adaptando-se a qualquer caso.

            int S1 = Calculadora.Sum(2, 3);
            int S2 = Calculadora.Sum(2, 4, 3);
        }

        static void ModificadorDeParametrosRefOut()
        {
            /*
            O Parâmetro "ref" é utilizado para indicar que o valor de uma variável dentro de uma função/método será apenas uma referência a variável no programa principal.
            Dessa forma, ao executarmos alguma ação com a variável na classe por exemplo,
            em lugar de armazenar esse valor na memória dentro do escopo do método, ele irá modificar o valor na variável do programa principal,
            já que o primeiro é somente uma referência que aponta pro segundo.
            */

            int a = 10;
            Calculadora.Triple(ref a); // Ao utilizar o "ref" aqui, e também no parâmetro do método na classe "Calculadora", ele entende que um deve fazer referência ao outro.
            Console.WriteLine(a);

            // O modificador de parâmetro "out" é parecido ao "ref" a diferença é que ele não exige que a variável seja iniciada.

            int b = 10;
            int triple;
            Calculadora.Triple2(b, out triple);
            Console.WriteLine(triple);

            // Ambos são muito similares, mas o "ref" é uma maneira de obrigar o usuário a iniciar a variável.
            // Ambos são considerados "code smells" (design ruins) e devem ser evitados.
        }

        static void BoxingUnboxing()
        {
            // Boxing é o processo de conversão de um objeto tipo valor para um objeto tipo referência compatível.
            
            int x = 20;

            object obj = x;
            Console.WriteLine(obj);

            // Unboxing é o processo de conversão de um objeto tipo referência para um objeto tipo valor compatível.

            int y = (int) obj;
            Console.WriteLine(y);
        }

        static void LaçoForEach()
        {
            // Sintaxe opcional e simplificada para percorrer coleções.
            // Leitura: "Para cada objeto 'obj' contido em vect, faça:"

            string[] vect = new string[] { "Maria", "Bob", "Alex" };

            foreach (string obj in vect)
            {
                Console.WriteLine(obj);
            }
        }

        static void Listas()
        {
            /*
            Lista é uma estrutura de dados:
            - Homogênea (dados do mesmo tipo)
            - Ordenada (elementos acessador por meio de posições)
            - Inicia vazia, e seus elementos são alocados sob demanda
            - Cada elemento ocupa um "nó" (ou nodo) da lista

            Classe: List
            Namespace: System.Collections.Generic

            Vantagens:
            - Tamanho variável
            - Facilidade para se realizar inserções e deleções

            Desvantagens:
            - Acesso sequencial aos elementos
            */

            List<string> list = new List<string>();

            List<string> list2 = new List<string> { "Maria", "Alex", "Bob" };

            /*
            Demo:

            Inserir elemento na lista: Add, Insert
            Tamando da lista: Count
            Enontrar primeiro ou último elemento da lista que satisfaça um predicado: list.Find, list.FindLast
            Encontrar primeira ou última posição de elemento da lista que satisfaça um predicado: list.FindIndex, list.FindLastIndex
            Filtrar a lista com base em um predicado: list.FindAll
            remover elementos da lista: Remove, RemoveAll, RemoveAt, RemoveRange
            */

            list.Add("Ronaldo"); // O "Add" por padrão insere o valor no final da lista.
            list.Add("Romário");
            list.Add("Rivaldo");
            list.Add("Rivelino");

            list.Insert(2, "Roberto"); // O "Insert" permite que você escolha em qual posição da lista você quer inserir o elemento.

            foreach (string obj in list)
            {
                Console.WriteLine(obj);
            }

            Console.WriteLine("list.Count: " + list.Count);

            string S1 = list.Find(x => x[0] == 'R');
            Console.WriteLine("First R: " + S1);

            string S2 = list.FindLast(x => x[0] == 'R');
            Console.WriteLine("Last R: " + S2);

            int Pos1 = list.FindIndex(x => x[0] == 'R');
            Console.WriteLine("First Position 'R': " + Pos1);

            int Pos2 = list.FindLastIndex(x => x[0] == 'R');
            Console.WriteLine("Last Position 'R': " + Pos2);

            List<string> list3 = list.FindAll(x => x.Length == 8); // Filtra somente os elementos que possuam 8 caracteres e retorna seu valor para a nova lista "list3".
            Console.WriteLine("--------------------------");
            foreach (string obj in list3)
            {
                Console.WriteLine(obj);
            }

            Console.WriteLine("--------------------------");
            list.Remove("Romário");
            foreach (string obj in list)
            {
                Console.WriteLine(obj);
            }

            Console.WriteLine("--------------------------");
            list.RemoveAll(x => x.Length == 8);
            foreach (string obj in list)
            {
                Console.WriteLine(obj);
            }

            Console.WriteLine("--------------------------");
            list.RemoveAt(1);
            foreach (string obj in list)
            {
                Console.WriteLine(obj);
            }

            Console.WriteLine("--------------------------");
            list.RemoveRange(0, 1); // Ele pede um index onde iniciará a remoção, e uma contagem de quantos elementos devem ser removidas apartir dali.
            foreach (string obj in list)
            {
                Console.WriteLine(obj);
            }
        }

        static void Matrizes()
        {
            /*
            Em programação, "matriz" é o nome dado a arranjos bidimensionais.

            Arranjo é uma estrutura de dados:
            - Homogênea (dados do mesmo tipo)
            - Ordenada (elementos acessador por meio de posições)
            - Alocada de uma vez só, em um bloco contíguo de memória

            Vantagens:
            - Acesso imediato aos elemtnos pela sua posição

            Desvantagens: 
            - Tamanho fixo
            - Dificuldade para se realizar inserções e deleções

                       C O L U N A S

                 |  0  |  1  |  2  |  3  | 
         L     ---------------------------
         I     0 | 3.5 | 7.0 | 8.2 | 2.3 |
         N     ---------------------------
         H     1 | 4.1 | 6.2 | 7.5 | 2.9 |
         A     ---------------------------
         S     2 | 1.0 | 9.5 | 4.8 | 2.1 |
               ---------------------------

            */

            double[,] mat = new double[2, 3]; // Ao instanciar a matriz indicamos quantas linhas e colunas queremos que ela tenha (2, 3).

            Console.WriteLine(mat.Length); // Indica quantos elementos essa matriz possui.

            Console.WriteLine(mat.Rank); // Nos indica quantas linhas a matriz possui.

            Console.WriteLine(mat.GetLength(0)); // Nos indica o tamanho da primeira dimensão da matriz (linhas).

            Console.WriteLine(mat.GetLength(1)); // Nos indica o tamanho da segunda dimensão da matriz (colunas).

            /*
            Problema exemplo:

            Fazer um programa para ler um número inteiro N e uma matriz de ordem N contendo números inteiros. 
            Em seguida, mostrar a diagonal principal e a quantidade de valores negativos da matriz.

            OBS: Matriz de ordem N é uma matriz que possui N linhas e N colunas, ou seja, é uma matriz quadrada.
            */

            Console.Write("Quantas linhas e colunas esta matriz terá? ");
            int N = int.Parse(Console.ReadLine());

            int[,] MatQuad  = new int[N, N];

            for (int i = 0; i < N; i++)
            {
                string[] values = Console.ReadLine().Split(' '); // Crio um vetor para armazenar os valores de cada linha, usando o split para separar cada elemento.

                for (int j = 0; j < N; j++)
                {
                    MatQuad[i,j] = int.Parse(values[j]);
                }
            }

            Console.WriteLine("Diagonal principal: ");

            for (int i = 0; i < N; i++)
            {
                Console.WriteLine(MatQuad[i, i] + " ");
            }

            Console.WriteLine();

            int count = 0;
            for (int i = 0; i < N; i++) // For para percorrer cada linha.
            {
                for (int j = 0; j < N; j++) // For para percorrer cada coluna em cada linha.
                {
                    if (MatQuad[i,j] < 0)
                    {
                        count++;
                    }
                }
            }

            Console.WriteLine("Números negativos: " + count);
        }

        // Exercícios de fixação

        static void Ex1() // Vetores
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

        static void Ex2() // Listas
        {
            /*
            Fazer um programa para ler um número inteiro N e depois os dados (id, nome e salario) de N funcionários. Não deve haver repetição de id.

            Em seguida, efetuar o aumento de X por cento no salário de um determinado funcionário. Para isso, o programa de ler um id e o valor X. 
            Se o id informado não existir, mostrar uma mensagem e abortar a operação. Ao final, mostrar a listagem atualizada dos funcionários, conforme exemplos.

            Lembre-se de aplicar a técnica de encapsulamento para não permitir que o salário possa ser mudado livremente. 
            Um salário só pode ser aumentado com base em uma operação de aumento por porcentagem dada.

                              Funcionario
            ----------------------------------------------
            - id : Integer
            - nome : String
            - salario : Double
            ----------------------------------------------
            + AumentarSalario(porcentagem : double) : void
            ----------------------------------------------
            */

            Console.Write("Quantos funcionários serão registrados? ");
            int N = int.Parse(Console.ReadLine());

            List<Funcionario> list = new List<Funcionario>();

            for (int i = 1; i <= N;  ++i)
            {
                Console.WriteLine("Funcionário #" + i + ":");
                Console.Write("Id: ");
                int id = int.Parse(Console.ReadLine());
                Console.Write("Nome: ");
                string nome = Console.ReadLine();
                Console.Write("Salário: ");
                double salario = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                list.Add(new Funcionario(id, nome, salario));
                Console.WriteLine();
            }

            Console.Write("Entre com o ID do funcionário que receberá um aumento de salário: ");
            int searchId = int.Parse(Console.ReadLine());

            Funcionario func = list.Find(x => x.Id == searchId);
            if (func != null)
            {
                Console.Write("Entre com a porcentagem de aumento: ");
                double porcentagem = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                func.AumentarSalario(porcentagem);
            }
            else
            {
                Console.WriteLine("Este ID não existe!");
            }

            Console.WriteLine();
            Console.WriteLine("Lista atualizada de funcionários:");

            foreach (Funcionario obj in list)
            {
                Console.WriteLine(obj);
            }
        }

        static void Ex3() // Matrizes
        {
            /*
            Fazer um programa para ler dois números inteiros M e N, e depois ler uma matriz de M linhas por N colunas contendo números inteiros, podendo haver repetições.
            Em seguida, ler um número inteiro X que pertence à matriz. 
            Para cada ocorrência de X, mostrar os valores à esquerda, acima, à direita e abaixo de X, quando houver, conforme exemplo.
            */

            Console.Write("Digite a quantidade de linhas da matriz: ");
            int N = int.Parse(Console.ReadLine());

            Console.Write("Digite a quantidade de colunas da matriz: ");
            int M = int.Parse(Console.ReadLine()); 
            
            int[,] mat = new int[N, M];

            for (int i = 0; i < N; i++)
            {
                Console.Write("Digite os valores da próxima linha: ");
                string[] values = Console.ReadLine().Split(' ');

                for (int j = 0; j < M; j++)
                {
                    mat[i, j] = int.Parse(values[j]);
                }
            }

            Console.Write("Digite um número inteiro: ");
            int X = int.Parse(Console.ReadLine());

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < M; j++)
                {
                    if (mat[i, j] == X)
                    {
                        Console.WriteLine("Posição: " + i + "," + j + ":");

                        if (j > 0)
                        {
                            Console.WriteLine("Esquerda: " + mat[i, j - 1]);
                        }

                        if (i > 0)
                        {
                            Console.WriteLine("Acima: " + mat[i - 1, j]);
                        }

                        if (j < N - 1)
                        {
                            Console.WriteLine("Direita: " + mat[i, j + 1]);
                        }

                        if (i < M - 1)
                        {
                            Console.WriteLine("Abaixo: " + mat[i + 1, j]);
                        }
                    }
                }
            }
        }

    }
}
