using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using S10_HerancaEPolimorfismo.Entities;

namespace S10_HerancaEPolimorfismo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Heranca(); // Linha .
            UpcastingEDowncasting(); // Linha .

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
    }
}
