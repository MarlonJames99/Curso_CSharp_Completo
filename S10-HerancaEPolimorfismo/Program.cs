using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S10_HerancaEPolimorfismo.Entities;
using S10_HerancaEPolimorfismo.Entities.Enums;
using System.Globalization;
using System.Diagnostics.Eventing.Reader;

namespace S10_HerancaEPolimorfismo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            Heranca(); // Linha .
            UpcastingEDowncasting(); // Linha .
            Sobreposicao(); // Linha .
            ClasseEMetodosSelados(); // Linha .
            Polimorfismo(); // Linha .
            ClassesAbstratas(); // Linha .
            MetodosAbstratos(); // Linha .

            // Exercícios

            Ex1(); // Linha .
            Ex2(); // Linha .

            Console.ReadLine();
        }

        static void Heranca()
        {
            /*
            - É um tipo de associação que permite que uma classe herde dados e comportamentos de outra.

            Definições importantes:
              - Relação "é-um"
              - Generalização/especialização
              - Superclasse (classe base) / subclasse (classe derivada)
              - Herança / extensão
              - Herança é uma associação entre classes (e não entre objetos)

            Vantagens: 
              - Reuso
              - Polimorfismo

            Sintaxe:
              - : (estende)
              - base (referência para a superclasse)
            */

            /*
            Exemplo:
            
            Suponha um negócio de banco que possui uma conta comum e uma conta para empresas, sendo que a conta para empresas possui todos os membros da conta comum,
            mais um limite de empréstimo e uma operação de realizar empréstimo.
            */

            BusinessAccount account = new BusinessAccount(8010, "Marlon James", 100.0, 500);

            Console.WriteLine(account.Balance);
        }

        static void UpcastingEDowncasting()
        {
            /*
            Upcasting:
              - Casting da subclasse para a superclasse
              - uso comum: Polimorfismo

            Downcasting:
              - Casting da superclasse para a subclasse
              - Palavra as
              - Palavra is
              - Uso comum: Métodos que recebem parâmetros genéricos (ex: Equals)
            */

            Account acc = new Account(1001, "Alex", 0);
            BusinessAccount bacc = new BusinessAccount(1002, "Maria", 0.0, 500.0);

            // UPCASTING

            Account acc1 = bacc;
            Account acc2 = new BusinessAccount(1003, "Bob", 0.0, 200.0);
            Account acc3 = new SavingsAccount(1004, "Ana", 0.0, 0.01);

            // DOWNCASTING

            BusinessAccount acc4 = (BusinessAccount)acc2;
            acc4.Loan(100.0);

            // BusinessAccount acc5 = (BusinessAccount)acc3; // Aqui, apesar do compilador não detectar um erro,
                                                          // ao executar o código, dará um erro por estar convertendo um conteúdo do tipo "Savings Account" para "Business Account".

            // Testando previamente se o conteúdo é ou não do tipo que você deseja:

            if(acc3 is BusinessAccount)
            {
                BusinessAccount acc5 = (BusinessAccount)acc3;
                acc5.Loan(200.0);
                Console.WriteLine("Loan!");
            }

            if(acc3 is SavingsAccount)
            {
                SavingsAccount acc5 = acc3 as SavingsAccount; // Sintaxe alternativa de fazer o Downcasting, usando "as".
                acc5.UpdateBalance();
                Console.WriteLine("Update!");
            }
        }

        static void Sobreposicao()
        {
            /*
            É a implementação de um método de uma superclasse na subclasse

            Para que um método comum (não abstrato) possa ser sobreposto, deve ser incluído nele o prefixo "virtual"

            Ao sobrescrever um método, devemos incluir nele o prefixo "Override".

            Palavra "base"

            É possível chamar a implementação da superclase usando a palavra base.

            Exemplo:

            Suponha as seguintes regras para saque:
              - Conta comum: é cobrada uma taxa no valor de 5.00
              - Conta poupança: realizar o saque normalmente da superclasse (Account), e depois descontar mais 7.0.

            Como resolver isso?

            Resposta: Sobrescrevendo o método withdraw na subclasse SavingsAccount.
            */

            Account acc1 = new Account(1001, "Alex", 500.0);
            Account acc2 = new SavingsAccount(1002, "Maria", 500.0, 0.01);

            acc1.Withdraw(10.0);
            acc2.Withdraw(10.0);

            Console.WriteLine(acc1.Balance);
            Console.WriteLine(acc2.Balance);
        }

        static void ClasseEMetodosSelados()
        {
            /*
            Classes e Métodos selados

            Palavra chave: sealed

            - Classe: Evita que a classe seja herdada
              - Nota: Ainda é possível extender a funcionalidade de uma classe selada usando "extension methods".

            - Método: Evita que um método sobreposto possa ser sobreposto novamente
              - Só pode ser aplicado a métodos sobrepostos.

            Aplicados na classe "SavingsAccount" selando tanto a classe para não poder ser herdada, 
            como selando o método já sobreposto "Withdraw" para não ter como ser novamente sobreposto.

            Pra quê?

            - Segurança: dependendo das regras do negócio, as vezes é desejável garantir que uma classe não seja herdada, ou que um método não seja sobreposto.
              - Geralmente convém selar métodos sobrepostos, pois sobreposições múltiplas podem ser uma porta de entrada para incosistências.

            - Performance: atributos de tipo de uma classe selada são analisados de forma mais rápida em tempo de execução.
              - Exemplo clássico: string
            */
        }

        static void Polimorfismo()
        {
            /*
            Em programação Orientada à objetos, polimorfismo é um recurso que permite que variáveis de um mesmo tipo mais genérico,
            possam apontar para objetos de tipos específicos diferentes, tendo assim comportamentos diferentes conforme cada tipo específico.

            Importante entender:

            - A associação do tipo específico com o tipo genérico é feita em tempo de execução (upcasting).

            - O compilador não sabe para qual tipo específico a chamada do método Withdraw está sendo feita (ele só sabe que são duas variáveis tipo Account).
            */

            Account acc1 = new Account(1001, "Alex", 500.0);
            Account acc2 = new SavingsAccount(1002, "Anna", 500.0, 0.01);

            acc1.Withdraw(10.0);
            acc2.Withdraw(10.0);

            Console.WriteLine(acc1.Balance);
            Console.WriteLine(acc2.Balance);
        }

        static void ClassesAbstratas()
        {
            /*
            São classes que não podem ser instanciadas
            É uma forma de garantir herança total: somente subclasses não abstratas podem ser instanciadas, mas nunca a superclasse abstrata.

            Exemplo:

            Suponha que em um negócio relacionado a banco, apenas contas poupança e contas para empresas são permitidas. Não existe conta comum.

            Para garantir que contas comuns não possam ser instanciadas, basta acrescentarmos a palavra "abstract" na declaração da classe.

            Notação UML: itálico
            */

            // Mesmo que declaremos a classe "Account" como Abstract, ela seguirá nos servindo para utilização de polimorfismo e herança.

            List<Account> list = new List<Account>();

            list.Add(new SavingsAccount(1001, "Alex", 500.0, 0.01));
            list.Add(new BusinessAccount(1002, "Maria", 500.0, 400.0));
            list.Add(new SavingsAccount(1003, "Bob", 500.0, 0.01));
            list.Add(new BusinessAccount(1002, "Anna", 500.0, 500.0));

            double sum = 0;

            foreach (Account acc in list)
            {
                sum += acc.Balance;
            }

            Console.WriteLine("Saldo Total: " + sum.ToString("F2", CultureInfo.InvariantCulture));

            foreach (Account acc in list)
            {
                acc.Withdraw(10.0);
            }

            foreach (Account acc in list)
            {
                Console.WriteLine("Saldo atualizado para a conta" + acc.Number + ": " + acc.Balance.ToString("F2", CultureInfo.InvariantCulture));
            }
        }

        static void MetodosAbstratos()
        {
            /*
            São Métodos que não possuem implementação

            Métodos precisam ser abstratos quando a classe é genérica demais para conter sua implementação.

            Se uma classe possuir pelo menos um método abstrato, então esta classe também é abstrata.

            Notação UML: Itálico

            Fazer um programa para ler os dados de N figuras (N fornecido pelo usuário), e depois mostrar as áreas destas figuras na mesma ordem em que foram digitadas.
            */

            List<Shape> list = new List<Shape>();

            Console.Write("Entre com o número de figuras: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Dados da figura #{i}");
                Console.Write("Retângulo ou círculo (r/c)? ");
                char ch = char.Parse(Console.ReadLine());

                Console.Write("Cor (Black/Blue/Red): ");
                Color color = (Color)Enum.Parse(typeof(Color), Console.ReadLine());

                if(ch == 'r')
                {
                    Console.Write("Largura: ");
                    double width = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                    Console.Write("Altura: ");
                    double height = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                    list.Add(new Rectangle(width, height, color));
                }
                else
                {
                    Console.Write("Raio: ");
                    double radius = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                    list.Add(new Circle(radius, color));
                }
            }
            Console.WriteLine();
            Console.WriteLine("Área das figuras:");

            foreach (Shape shape in list)
            {
                Console.WriteLine(shape.Area().ToString("F2", CultureInfo.InvariantCulture));
            }
        }

        // Exercícios

        static void Ex1()
        {
            /*
            Uma empresa possui funcionários próprios e terceirizados. Para cada funcionário, deseja-se registrar nome, horas trabalhadas e valor por hora.
            Funcionários terceirizados possuem ainda uma despesa adicional.

            O pagamento dos funcionários corresponde ao valor da hora multiplicado pelas horas trabalhadas, 
            sendo que os funcionários terceirizados ainda recebem um bônus correspondente a 110% de sua despesa adicional.

            Fazer um programa para ler os dados de N funcionários (N fornecido pelo usuário) e armazená-los em uma lista. 
            Depois de ler todos os dados, mostrar nome e pagamento de cada funcionário na mesma ordem em que foram digitados.
            */

            List<Employee> list = new List<Employee>();

            Console.Write("Entre com o número de funcionários: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Dados do funcionário #{i}");
                Console.Write("Terceirizado? (y/n) ");
                char ch = char.Parse(Console.ReadLine());

                Console.Write("Nome: ");
                string name = Console.ReadLine();

                Console.Write("Horas: ");
                int hours = int.Parse(Console.ReadLine());

                Console.Write("valor por hora: ");
                double valuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                if(ch == 'y')
                {
                    Console.Write("Custo adicional: ");
                    double additionalCharge = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                    list.Add(new OutsourcedEmployee(name, hours, valuePerHour, additionalCharge));
                }
                else
                {
                    list.Add(new Employee(name, hours, valuePerHour));
                }
            }

            Console.WriteLine();
            Console.WriteLine("Pagamentos: ");

            foreach (Employee emp in list)
            {
                Console.WriteLine(emp.Name + " - $" + emp.Payment().ToString("F2", CultureInfo.InvariantCulture));
            }
        }

        static void Ex2()
        {
            /*
            Fazer um programa para ler os dados de N produtos (N fornecido pelo usuário). 
            Ao final, mostrar a etiqueta de preço de cada produto na mesma ordem em que foram digitados.
            
            Todo Produto possui nome e preço. Produtos importados possuem uma taxa de alfândega, e produtos usados possuem data de fabricação.
            Estes dados específicos devem ser acrescentados na etiqueta de preço conforme exemplo. 
            Para produtos importados, a taxa de alfândega deve ser acrescentada ao preço final do produto.
            */

            List<Product> list = new List<Product>();

            Console.Write("Entre com a quantidade de produtos: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Dados do produto #{i}: ");

                Console.Write("Comum, usado ou importado (c/u/i)? ");
                string ch = Console.ReadLine();

                Console.Write("nome: ");
                string name = Console.ReadLine();

                Console.Write("Preço: ");
                double price = double.Parse(Console.ReadLine() , CultureInfo.InvariantCulture);

                if (ch == "u" || ch == "U")
                {
                    Console.Write("Data de fabricação (DD/MM/YYYY): ");
                    DateTime manufactureDate = DateTime.Parse(Console.ReadLine());

                    list.Add(new UsedProduct(name, price, manufactureDate));
                }
                else if (ch == "i" || ch == "I")
                {
                    Console.Write("Taxa de alfândega: ");
                    double customsFee = double.Parse(Console.ReadLine() ,CultureInfo.InvariantCulture);

                    list.Add(new ImportedProduct(name, price, customsFee));
                }
                else
                {
                    list.Add(new Product(name, price));
                }
            }

            Console.WriteLine();
            Console.WriteLine("Etiquetas de preço:");

            foreach (Product prod in list)
            {
                Console.WriteLine(prod.PriceTag());
            }
        }
    }
}
