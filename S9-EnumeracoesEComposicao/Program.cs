using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.Net.NetworkInformation;
using S9_EnumeracoesEComposicao.Entities;
using S9_EnumeracoesEComposicao.Entities.Enums;


namespace S9_EnumeracoesEComposicao
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Enumeracoes(); // Linha 29.
            // Composicao(); // Linha 78.

            // Exercícios

            // Ex1(); // Linha 112.
            // Ex2(); // Linha 160.
            Ex3(); // Linha 195.

            Console.ReadLine();
        }

        static void Enumeracoes()
        {
            /*
            É um tipo especial que serve para especificar de forma literal um conjunto de constantes relacionadas.

            Palavra chave em C#: enum
              * Nota: enum é um tipo valor
            
            Vantagem: melhor semântica, código mais legível e auxiliado pelo compilador.
            */

            // Diagrama de máquina de estado: é usado na UML para representar o ciclo de vida de uma entidade. 

            // Criar um ciclo de vida de uma entidade "order" usando enum:

            Order order = new Order
            {
                Id = 1080,
                Moment = DateTime.Now,
                Status = OrderStatus.AguardandoPagamento
            };

            Console.WriteLine(order);

            // Conversão de enum para string

            string txt = OrderStatus.AguardandoPagamento.ToString();
            Console.WriteLine(txt);

            // Conversão de string para enum

            OrderStatus os = (OrderStatus)Enum.Parse(typeof(OrderStatus), "Entregue");
            Console.WriteLine(os);

            /*
            Notação UML

            |----------------------------------|
            |             <<enum>>             |
            |            OrderStatus           |
            |----------------------------------|
            | - PENDING_PAYMENT : int = 0      |
            | - PROCESSING : int = 1           |
            | - SHIPPED : int = 2              |
            | - DELIVERED : int = 3            |
            |----------------------------------|
            */
        }

        static void Composicao()
        {
            /*
            Antes de iniciar o conteúdo de composição, vamos falar um pouco sobre Design:
            
            Categorias de classes

            * Em um  sistema orientado à objetos, de modo geral "tudo" é objeto.
             
            * Por questões de design tais como organização, flexibilidade, reuso, delegação, etc., há várias categorias de classes:
            
            Views; Controllers; Entities; Services; Repositories...
            */

            /*
            Composição 

            - É um tipo de associação que permite que um objeto contenha outro

            - Relação "tem-um" ou "tem-vários"

            - Vantagens: 
              - Organização: divisão de responsabilidades
              - Coesão
              - Flexibilidade
              - Reuso

            - Nota: Embora o símbolo UML para composição (todo-parte) seja o diamante preto, 
            neste contexto estamos chamando de composição qualquer associação tipo "tem-um" e "tem-vários".
            */
        }

        // Exercícios de fixação

        static void Ex1()
        {
            // Ler os dados de um trabalhador com N contratos (N fornecido pelo usuário). Depois, solicitar do usuário um mês e mostrar qual foi o salário do funcionário nesse mês.

            Console.Write("Entre o nome do departamento: ");
            string deptName = Console.ReadLine();

            Console.WriteLine("Entre com os dados do trabalhador: ");
            Console.Write("Nome: ");
            string name = Console.ReadLine();

            Console.Write("Nível (Junior/MidLevel/Senior): ");
            WorkerLevel level = (WorkerLevel)Enum.Parse(typeof(WorkerLevel), Console.ReadLine());

            Console.Write("Salário base: ");
            double baseSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Department dept = new Department(deptName);
            Worker worker = new Worker(name, level, baseSalary, dept);

            Console.Write("Quantos contratos para este funcionário? ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Entre com os dados do contrato #{i}: ");
                Console.Write("Data (DD/MM/YYYY): ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.Write("Valor por hora: ");
                double valuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Duração (horas): ");
                int hours = int.Parse(Console.ReadLine());

                HourContract contract = new HourContract(date, valuePerHour, hours);
                worker.AddContract(contract);
            }

            Console.WriteLine();
            Console.Write("Entre com mês e ano para calcular o salário (MM/YYYY): ");
            string monthAndYear = Console.ReadLine();
            int month = int.Parse(monthAndYear.Substring(0, 2));
            int year = int.Parse(monthAndYear.Substring(3));

            Console.WriteLine("Nome: " + worker.Name);
            Console.WriteLine("Departamento: " + worker.Department.Name);
            Console.WriteLine("Salário para " + monthAndYear + ": " + worker.Income(year, month).ToString("F2", CultureInfo.InvariantCulture));
        }

        static void Ex2() // Usando StringBuilder
        {
            // Instancie manualmente os objetos mostrados e mostre-os na tela do terminal.

            Comments c1 = new Comments("Tenha uma boa viagem!");
            Comments c2 = new Comments("Uau, isso é ótimo!");

            Post p1 = new Post(
                DateTime.Parse("21/06/2018 13:05:44"),
                "Viajando para a Nova Zelândia",
                "Estou indo visitar esse país incrível",
                12
                );

            p1.AddComment(c1);
            p1.AddComment(c2);

            Comments c3 = new Comments("Boa noite");
            Comments c4 = new Comments("Que a força esteja com você");

            Post p2 = new Post(
                DateTime.Parse("28/07/2018 23:14:19"),
                "Boa noite pessoal",
                "Nos vemos amanhã",
                5
                );

            p2.AddComment(c3);
            p2.AddComment(c4);

            Console.WriteLine(p1);
            Console.WriteLine(p2);
        }

        static void Ex3()
        {
            /*
            Ler os dados de um pedido com N itens (N fornecido pelo usuário). Depois, mostrar um sumário do pedido. 

            Nota: O instante do pedido deve ser o instante do sistema: DateTime.Now
            */

            Console.WriteLine("Entre com os dados do cliente: ");
            Console.WriteLine();

            Console.Write("Nome: ");
            string nome = Console.ReadLine();

            Console.Write("Email: ");
            string email = Console.ReadLine();

            Console.Write("Data de nascimento: ");
            DateTime nascimento = DateTime.Parse(Console.ReadLine());

            Client cliente = new Client(nome, email, nascimento);

            Console.WriteLine();
            Console.WriteLine("Entre com os dados do pedido: ");
            Console.WriteLine();
            Console.Write("Status: ");
            OrderStatus status = (OrderStatus)Enum.Parse(typeof(OrderStatus), Console.ReadLine());

            Order pedido = new Order(1, DateTime.Now, status, cliente); 

            Console.WriteLine();
            Console.Write("Quantos itens serão incluídos no pedido? ");
            int N = int.Parse(Console.ReadLine());
            Console.WriteLine();

            for (int i = 1; i <= N; i++)
            {
                Console.WriteLine($"Entre com os dados do item #{i}: ");
                Console.WriteLine();

                Console.Write("Nome do produto: ");
                string nomeProd = Console.ReadLine();

                Console.Write("Preço do produto: ");
                double precoProd = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                Console.Write("Quantidade: ");
                int quantidadeProd = int.Parse(Console.ReadLine());

                Product produto = new Product(nomeProd, precoProd);
                OrderItem item = new OrderItem(quantidadeProd, precoProd, produto);
                pedido.AddItem(item);

                Console.WriteLine();
            }
            Console.WriteLine(pedido);

        }
    }
}